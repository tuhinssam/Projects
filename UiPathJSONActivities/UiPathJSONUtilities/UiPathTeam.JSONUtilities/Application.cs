using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UiPathTeam.JSONUtilities.Enums;
using UiPathTeam.JSONUtilities.Properties;
using UiPathTeam.JSONUtilities.Tools;
using static UiPathTeam.JSONUtilities.Enums.TokenSource;
using static UiPathTeam.JSONUtilities.Enums.AuthScheme;

namespace UiPathTeam.JSONUtilities
{
    /// <summary>
    /// The Application class holds an HTTP Client and list of API calls shared amongst the scope and child activities.
    /// </summary>
    public class Application : IAsyncInitialization
    {
        #region Properties

        private HttpClient Client { get; set; }
        private string Username { get; }
        private string Password { get; }
        private string URL { get; }

        private DateTime? AuthTimestamp { get; set; }
        private AuthenticationHeaderValue AuthHeader { get; set; }

        ///////////////////////////////////////////////////////////////////////
        /*START HERE: Choose how the client should authenticate its API calls*/
        ///////////////////////////////////////////////////////////////////////
        private const AuthScheme AuthScheme = None;
        private const string LoginExtension = "/login";
        private const TokenSource TokenSource = Body;
        private const string TokenKey = "token";
        private const int TokenTimeout = 30;

        #endregion


        #region Constructors

		// Creates a new, blank Application
		public Application() { }

        // Creates a new Application using the provided credentials
        public Application(string username, string password, string url)
        {
            Username = username;
            Password = password;
            URL = url.TrimEnd('/') + "/";
        }

        // Allows Initialization (the step right after constructor runs) to be asynchronous
        public Task Initialization => InitializeAsync();

        // Asynchronously creates an authenticated client to make all API calls
        private async Task InitializeAsync()
        {
            // a. Uncomment one of the Auth schemes below or create your own
            switch (AuthScheme)
            {
                case None:
                    break;
                case Bearer:
                    await BearerAuthentication(LoginExtension, TokenKey, TokenSource);
                    break;
                case Basic:
                    BasicAuthentication();
                    break;
                default:
                    throw new CustomException(string.Format(Resources.Application_InitializeAsync_UnknownAuthSchemeException, AuthScheme.ToString()));
            }

            // b. Create a reusable HTTP Client to make all the API calls
            CreateClient();

            // c. Get everything else you want from the API here
        }

        // Once authentication is complete, creates a reusable HTTP Client
        private void CreateClient()
        {
	        if (URL == null) return;

            var cookies = new CookieContainer();
            var handler = new HttpClientHandler { CookieContainer = cookies };

            try
            {
                Client = new HttpClient(handler) {BaseAddress = new Uri(URL)};
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (AuthScheme != None) Client.DefaultRequestHeaders.Authorization = AuthHeader;
            }
            catch (UriFormatException eq)
            {
                throw new CustomException(Resources.Application_CreateClient_InvalidURLException, eq);
            }
            catch (AggregateException ev)
            {
                throw new CustomException(Resources.Application_CreateClient_ServerUnreachableException, ev);
            }
        }

        #endregion


        #region Authentication

        // Retrieves a bearer token and adds it to the Client's headers
        private async Task BearerAuthentication(string loginExtension, string tokenKey, TokenSource tokenSource=Body)
        {
            var cookies = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookies })
            using (var authClient = new HttpClient(handler))
            {
                try
                {
                    // a. Construct the endpoint that returns an auth token
                    var loginUri = new Uri(URL + loginExtension);

                    // b. Add all required parameters to the request body
                    var body = new Dictionary<string, string>
                    {
                        {"username", Username}, {"password", Password}, {"redirect", "false"}
                    };

                    // c. Convert the body to JSON and Post to the authentication endpoint
                    var res = await authClient.PostAsync(loginUri, new FormUrlEncodedContent(body));

                    // d. Catch any bad responses
                    HTTPMagic.CheckStatus(res);

                    // e. Create token variable and use one of the options below
                    var token = "";

                    switch (tokenSource)
                    {
                        // e1. Get token from the response BODY
                        case Body:
                            var content = await res.Content.ReadAsStringAsync();
                            token = JObject.Parse(content)[tokenKey]?.Value<string>();
                            break;

                        // e2. Get token from the response COOKIES
                        case Cookies:
                            token = cookies.GetCookies(loginUri).Cast<Cookie>()
                                                                .First(c => c.Name.Equals(tokenKey))?
                                                                .Value;
                            break;

                        // e3. Get token from the response HEADER
                        case Header:
                            if (res.Headers.TryGetValues(tokenKey, out var values))
                                token = values.First();
                            break;
                    }

                    
                    // f. Save Auth header used by the Client
                    AuthHeader = new AuthenticationHeaderValue("Bearer", token);

                    // g. Timestamp the returned token to know when it has to be refreshed
                    AuthTimestamp = DateTime.Now;
                }
                catch (UriFormatException)
                {
                    throw new CustomException(Resources.Application_BearerAuthentication_InvalidURLException);
                }
                catch (AggregateException ae)
                {
                    ae.Handle((x) => throw new CustomException(Resources.Application_BearerAuthentication_SomethingWrongException, x));
                }
                catch (Exception e) when (e is HttpRequestException || e is WebException || e is ArgumentNullException || e is InvalidOperationException)
                {
                    throw new CustomException(Resources.Application_BearerAuthentication_ServerUnreachableException);
                }
            }
        }

        // Creates a basic token and adds it to the Client's headers
        private void BasicAuthentication()
        {
            // a. Encode the token
            var token = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Username}:{Password}"));

            // b. Save Auth header used by the Client
            AuthHeader = new AuthenticationHeaderValue("Basic", token);

            // c. Set max timeout since token never needs to be refreshed
            AuthTimestamp = DateTime.MaxValue;
        }

        #endregion


        #region Info Calls
        #endregion


        #region Action Calls

        public Task<int> SumValues(int firstValue, int secondValue)
        {
            return Task.FromResult(firstValue + secondValue);
        }

        #endregion


        #region Helpers

        // Checks if the token has expired and refreshes it if so
        public async Task<bool> CheckConnection()
        {
            if (Client != null && (AuthTimestamp ?? DateTime.MinValue) <= DateTime.Now.Subtract(TimeSpan.FromMinutes(TokenTimeout)))
            {
                await InitializeAsync();
                return true;
            }
            return false;
        }

        // Compares new credentials to those used by the Client
        public bool CompareCredentials(string username, string password, string url)
        {
            return (username == Username) && (password == Password) && (url == URL);
        }
        
        #endregion
    }
}

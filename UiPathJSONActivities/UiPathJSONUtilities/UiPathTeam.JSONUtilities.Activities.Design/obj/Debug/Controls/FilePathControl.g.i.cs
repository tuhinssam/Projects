﻿#pragma checksum "..\..\..\Controls\FilePathControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52CFFB86840F4A4486B75EC22FB9E93846CB6ED3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Activities.Presentation.View;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace UiPath.Activities.Presentation {
    
    
    /// <summary>
    /// FilePathControl
    /// </summary>
    public partial class FilePathControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Controls\FilePathControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UiPath.Activities.Presentation.FilePathControl FilePath;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Controls\FilePathControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Controls\FilePathControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Activities.Presentation.View.ExpressionTextBox FileNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UiPathTeam.JSONUtilities.Activities.Design;component/controls/filepathcontrol.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\FilePathControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FilePath = ((UiPath.Activities.Presentation.FilePathControl)(target));
            return;
            case 2:
            this.LoadButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Controls\FilePathControl.xaml"
            this.LoadButton.Click += new System.Windows.RoutedEventHandler(this.LoadButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FileNameTextBox = ((System.Activities.Presentation.View.ExpressionTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


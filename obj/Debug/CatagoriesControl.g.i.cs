﻿#pragma checksum "..\..\CatagoriesControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55830AA2F944C4D0300FB53B4017EEB1CE06AE27503939F2614A8E6857EE8C40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Counter_Wpf;
using System;
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


namespace Counter_Wpf {
    
    
    /// <summary>
    /// CatagoriesControl
    /// </summary>
    public partial class CatagoriesControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CatagoriesControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle catagoryRect;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CatagoriesControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse colorCircle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\CatagoriesControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\CatagoriesControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label catagoryLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CatagoriesControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox countTextbox;
        
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
            System.Uri resourceLocater = new System.Uri("/Counter_Wpf;component/catagoriescontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CatagoriesControl.xaml"
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
            this.catagoryRect = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 10 "..\..\CatagoriesControl.xaml"
            this.catagoryRect.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.catagoryRect_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.colorCircle = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\CatagoriesControl.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.catagoryLabel = ((System.Windows.Controls.Label)(target));
            
            #line 23 "..\..\CatagoriesControl.xaml"
            this.catagoryLabel.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.catagoryLabel_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.countTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\CatagoriesControl.xaml"
            this.countTextbox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.countTextbox_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 24 "..\..\CatagoriesControl.xaml"
            this.countTextbox.MouseLeave += new System.Windows.Input.MouseEventHandler(this.countTextbox_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


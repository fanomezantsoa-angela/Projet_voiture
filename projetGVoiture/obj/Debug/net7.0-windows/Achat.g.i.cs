﻿#pragma checksum "..\..\..\Achat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C57FD87674A8ACDDC05A1B4F72B2AED959EB582C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using projetGVoiture;


namespace projetGVoiture {
    
    
    /// <summary>
    /// Achat
    /// </summary>
    public partial class Achat : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 30 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navvoiture;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navfacture;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navachat;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button navarchive;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logout;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ajoutachat;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Clients;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NUMEROACHAT;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgridachat;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RECHERCHE;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\Achat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button recherchevoiture;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projetGVoiture;component/achat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Achat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.navvoiture = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Achat.xaml"
            this.navvoiture.Click += new System.Windows.RoutedEventHandler(this.navvoiture_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.navfacture = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Achat.xaml"
            this.navfacture.Click += new System.Windows.RoutedEventHandler(this.navfacture_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.navachat = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Achat.xaml"
            this.navachat.Click += new System.Windows.RoutedEventHandler(this.navachat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.navarchive = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Achat.xaml"
            this.navarchive.Click += new System.Windows.RoutedEventHandler(this.navarchive_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.logout = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Achat.xaml"
            this.logout.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ajoutachat = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\Achat.xaml"
            this.ajoutachat.Click += new System.Windows.RoutedEventHandler(this.ajoutachat_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Clients = ((System.Windows.Controls.ComboBox)(target));
            
            #line 111 "..\..\..\Achat.xaml"
            this.Clients.Initialized += new System.EventHandler(this.Clients_Initialized);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NUMEROACHAT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.dtgridachat = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.RECHERCHE = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.recherchevoiture = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\Achat.xaml"
            this.recherchevoiture.Click += new System.Windows.RoutedEventHandler(this.recherchevoiture_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 143 "..\..\..\Achat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ecr_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 182 "..\..\..\Achat.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.bout_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


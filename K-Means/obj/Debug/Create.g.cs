﻿#pragma checksum "..\..\Create.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17D012C80FE0E632A9FD9303CFF368656B291532"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using K_Means;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace K_Means {
    
    
    /// <summary>
    /// Create
    /// </summary>
    public partial class Create : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Create.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Create.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textNum_Of_Objects;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Create.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Create.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textNum_Of_Params;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Create.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
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
            System.Uri resourceLocater = new System.Uri("/K-Means;component/create.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Create.xaml"
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
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.textNum_Of_Objects = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\Create.xaml"
            this.textNum_Of_Objects.KeyUp += new System.Windows.Input.KeyEventHandler(this.textNum_Of_Objects_KeyUp);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Create.xaml"
            this.textNum_Of_Objects.GotFocus += new System.Windows.RoutedEventHandler(this.textNum_Of_Objects_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.textNum_Of_Params = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\Create.xaml"
            this.textNum_Of_Params.KeyUp += new System.Windows.Input.KeyEventHandler(this.textNum_Of_Params_KeyUp);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Create.xaml"
            this.textNum_Of_Params.GotFocus += new System.Windows.RoutedEventHandler(this.textNum_Of_Params_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Create.xaml"
            this.button.GotFocus += new System.Windows.RoutedEventHandler(this.button_GotFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


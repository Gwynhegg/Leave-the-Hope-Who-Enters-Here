﻿#pragma checksum "..\..\ResultWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5B4CBBAF1C0990DAC833CCC961C80D83B875B72A"
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
using System.Windows.Forms;
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
    /// ResultWindow
    /// </summary>
    public partial class ResultWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Graph;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid outputTable;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox boxFirstDim;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox boxSecondDim;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid clustersAverage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost w_host;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost average_host;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
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
            System.Uri resourceLocater = new System.Uri("/K-Means;component/resultwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ResultWindow.xaml"
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
            this.Graph = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.outputTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.boxFirstDim = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\ResultWindow.xaml"
            this.boxFirstDim.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.boxFirstDim_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.boxSecondDim = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\ResultWindow.xaml"
            this.boxSecondDim.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.boxSecondDim_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.clustersAverage = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.w_host = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 7:
            this.average_host = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 8:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


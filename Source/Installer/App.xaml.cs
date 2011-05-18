﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;
using System.Reflection;
using System.Management.Automation;
using System.ComponentModel;
using PsGet.Installer.Models;
using System.Windows.Navigation;

namespace PsGet.Installer {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public static new App Current { get { return (App)Application.Current; } }

        public PowerShell Shell { get; private set; }
        public bool DesignTimeMode { get; private set; }

        public NavigationService NavigationService {
            get {
                return ((NavigationWindow)MainWindow).NavigationService;
            }
        }

        public App() : base() {
            DesignTimeMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

            Shell = PowerShell.Create();

            if (!DesignTimeMode) {
                AppDomain.CurrentDomain.AssemblyResolve += (_, args) => {
                    string resourceName = String.Format("PsGet.Installer.{0}.dll", args.Name);
                    using (Stream strm = typeof(App).Assembly.GetManifestResourceStream(resourceName)) {
                        if (strm != null) {
                            byte[] asm = new byte[strm.Length];
                            strm.Read(asm, 0, asm.Length);
                            return Assembly.Load(asm);
                        }
                    }
                    return null;
                };
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using PsGet.Hosting;
using NuGet;
using PsGet.Commands;
using Moq;
using Xunit;
using PsGet.Facts.TestDoubles;
using System.IO;

namespace PsGet.Facts
{
    public static class CmdletExtensions
    {
        public static T AutoConfigure<T>(this T self) where T : PsGetCommandBase
        {
            self.HostEnvironment = new TestHostEnvironment();
            self.CommandRuntime = new TestCommandRuntime();
            self.Session = new TestSessionStore();
            return self;
        }

        public static CommandOutput Execute<T>(this T self) where T : PsGetCommandBase
        {
            // Assume the configuration has already been established (properties are set, etc.) and do a
            // single item run of the pipeline
            return self.Execute(new Action<T>[] { (_) => {} });
        }

        public static CommandOutput Execute<T>(this T self, IEnumerable<Action<T>> inputConfigurations) where T : PsGetCommandBase
        {
            TestCommandRuntime runtime = new TestCommandRuntime();
            self.CommandRuntime = runtime;
            self.BeginProcessingCore();
            foreach (Action<T> configs in inputConfigurations)
            {
                configs(self);
                self.ProcessRecordCore();
            }
            self.EndProcessingCore();
            return runtime.Output;
        }

        public static TestCommandInvoker AttachInvoker(this PsGetCommandBase self)
        {
            return self.AttachInvoker(autoHandle: true);
        }

        public static TestCommandInvoker AttachInvoker(this PsGetCommandBase self, bool autoHandle)
        {
            TestCommandInvoker invoker = new TestCommandInvoker(autoHandle);
            self.Invoker = invoker;
            return invoker;
        }

        public static TestSessionStore AttachSession(this PsGetCommandBase self)
        {
            TestSessionStore store = new TestSessionStore();
            self.Session = store;
            return store;
        }

        public static Mock<IPackageManager> AttachPackageManager(this PackageManagementCommand self) {
            Mock<IPackageManager> mock = new Mock<IPackageManager>();
            self.PackageManagerFactory = (source, destination) => mock.Object;
            return mock;
        }

        public static void AttachPathService(this PsGetCommandBase self, string currentPath, string resolvePrefix)
        {
            Mock<IPathService> mockPathService = new Mock<IPathService>();
            mockPathService.Setup(s => s.CurrentPath).Returns(currentPath);
            mockPathService.Setup(s => s.ResolvePath(It.IsAny<string>())).Returns<string>(s => String.Concat(resolvePrefix, s));
            self.PathService = mockPathService.Object;
        }
    }
}

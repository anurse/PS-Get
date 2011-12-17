﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using NuGet;
using Moq;
using PsGet.Cmdlets;
using PsGet.Facts.TestDoubles;

namespace PsGet.Facts.Commands
{
    public class PsGetCmdletFacts
    {
        [Fact]
        public void ConstructorUsesDefaultRepositoryFactory()
        {
            Assert.Same(PackageRepositoryFactory.Default, new Mock<PsGetCmdlet>() { CallBase = true }.Object.RepositoryFactory);
        }

        [Fact]
        public void BeginProcessingInitializesSettingsAndCallsCoreProcessor()
        {
            // Arrange
            PsGetCmdlet cmdlet = new Mock<PsGetCmdlet>() { CallBase = true }.Object;
            cmdlet.HostEnvironment = new TestHostEnvironment(@"C:\Foo");
            
            // Act
            cmdlet.BeginProcessingCore();

            // Assert
            Assert.Equal(@"C:\", cmdlet.Settings.InstallationRoot);
            Assert.Equal(Settings.TheDefaultSource, cmdlet.Settings.DefaultSource);
        }

        [Fact]
        public void OpenRepositoryUsesRepositoryFactory()
        {
            // Arrange
            Mock<IPackageRepositoryFactory> mockFactory = new Mock<IPackageRepositoryFactory>();
            PsGetCmdlet cmdlet = new Mock<PsGetCmdlet>() { CallBase = true }.Object;
            cmdlet.RepositoryFactory = mockFactory.Object;
            IPackageRepository expected = new Mock<IPackageRepository>().Object;
            mockFactory.Setup(f => f.CreateRepository("foo")).Returns(expected);

            // Act
            IPackageRepository actual = cmdlet.OpenRepository("foo");

            // Assert
            Assert.Same(expected, actual);
        }

        [Fact]
        public void CreatePackageManagerUsesProvidedOverrides()
        {
            // Arrange
            Mock<IPackageRepositoryFactory> mockFactory = new Mock<IPackageRepositoryFactory>();
            Mock<PsGetCmdlet> mockCmdlet = new Mock<PsGetCmdlet>() { CallBase = true };
            mockCmdlet.Object.RepositoryFactory = mockFactory.Object;
            IPackageRepository expected = new Mock<IPackageRepository>().Object;
            mockFactory.Setup(f => f.CreateRepository("foo")).Returns(expected);
            
            // Act
            IPackageManager manager = mockCmdlet.Object.CreatePackageManager("foo", @"D:\");

            // Assert
            PhysicalFileSystem fs = Assert.IsType<PhysicalFileSystem>(manager.FileSystem);
            DefaultPackagePathResolver resolver = Assert.IsType<DefaultPackagePathResolver>(manager.PathResolver);
            Assert.Same(expected, manager.SourceRepository);
            Assert.Equal(@"D:\", fs.Root);
            Assert.Equal(@"foo", resolver.GetPackageDirectory("foo", new Version(1, 0, 0, 0)));
        }
    }
}

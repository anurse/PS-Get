﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using NuGet;
using PsGet.Commands;

namespace PsGet.Cmdlets {
    [Cmdlet(VerbsCommon.Remove, "Package")]
    public class RemovePackageCommand : PackageManagerCmdletWithSource {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter RemoveDependencies { get; set; }

        protected internal override void ProcessRecordCore() {
            IPackageManager manager = CreatePackageManager(Source, Destination);
            manager.UninstallPackage(Id, null, Force.IsPresent, RemoveDependencies.IsPresent);
        }
    }
}

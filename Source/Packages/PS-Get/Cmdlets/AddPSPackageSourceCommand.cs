﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using PsGet.Abstractions;
using PsGet.Sources;

namespace PsGet.Cmdlets
{
    [Cmdlet(VerbsCommon.Add, "PSPackageSource")]
    public class AddPSPackageSourceCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string Source { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Tag { get; set; }

        [Parameter(Mandatory = false)]
        public PackageSourceListScope Scope { get; set; }

        public AddPSPackageSourceCommand()
        {
            Scope = PackageSourceListScope.User;
        }

        protected override void ProcessRecord()
        {
            PsPackageSourceList list = PsPackageSourceList.GetList(Scope, new PSVariableSessionStorage(SessionState.PSVariable));
            list.Sources.Add(new PsPackageSource(Source, Tag));
            list.Save();
        }
    }
}

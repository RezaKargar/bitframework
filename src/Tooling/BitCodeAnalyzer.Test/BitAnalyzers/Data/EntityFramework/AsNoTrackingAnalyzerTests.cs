﻿using Bit.Tooling.CodeAnalyzer.BitAnalyzers.Data.EntityFramework;
using Bit.Tooling.CodeAnalyzer.Test.Helpers;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Tooling.CodeAnalyzer.Test.BitAnalyzers.Data.EntityFramework
{
    [TestClass]
    public class AsNoTrackingAnalyzerTests : DiagnosticVerifier
    {
        [TestMethod]
        [TestCategory("Analyzer")]
        public async Task AsNoTrackingMustBeCalledBeforeAllOtherMethodCallsOfDbQueryAndDbSqlQuery()
        {
            DiagnosticResult notCalledAsNoTracking1 = new DiagnosticResult
            {
                Id = nameof(AsNoTrackingAnalyzer),
                Message = AsNoTrackingAnalyzer.Message,
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] { new DiagnosticResultLocation(Path.Combine(basePath, @"Program.cs"), 13, 33) }
            };

            DiagnosticResult notCalledAsNoTracking2 = new DiagnosticResult
            {
                Id = nameof(AsNoTrackingAnalyzer),
                Message = AsNoTrackingAnalyzer.Message,
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] { new DiagnosticResultLocation(Path.Combine(basePath, @"Program.cs"), 15, 33) }
            };

            DiagnosticResult notCalledAsNoTracking3 = new DiagnosticResult
            {
                Id = nameof(AsNoTrackingAnalyzer),
                Message = AsNoTrackingAnalyzer.Message,
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] { new DiagnosticResultLocation(Path.Combine(basePath, @"Program.cs"), 17, 42) }
            };

            await VerifyCSharpDiagnostic(notCalledAsNoTracking1, notCalledAsNoTracking2, notCalledAsNoTracking3);
        }

        private readonly string basePath = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, @"..\..\..\BitAnalyzers\Data\EntityFramework\TestSolution")).FullName;

        public override async Task<Project> CreateProject(string[] sources, string language = LanguageNames.CSharp)
        {
            if (!MSBuildLocator.IsRegistered)
                MSBuildLocator.RegisterDefaults();

            MSBuildWorkspace workspace = MSBuildWorkspace.Create(new Dictionary<string, string>()
            {
                { "TargetFramework", "netcoreapp3.1" }
            });

            await workspace.OpenSolutionAsync(Path.Combine(basePath, "EntityFrameworkFullAsNoTrackingCallTests.sln"));

            return workspace.CurrentSolution.Projects.Single();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new AsNoTrackingAnalyzer();
        }
    }
}

// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Project;
using NUnit.Framework;
using ICSharpCode.UnitTesting;
using UnitTesting.Tests.Utils;

namespace UnitTesting.Tests.Frameworks
{
	/// <summary>
	/// If the project explicitly targets 32 bit (x86) architecture then nunit-console-x86.exe should be 
	/// used. Otherwise the normal nunit-console.exe is used.
	/// </summary>
	[TestFixture]
	public class NUnitConsoleExeSelectedTestFixture
	{
		string oldRootPath;
		
		[TestFixtureSetUp]
		public void SetUpFixture()
		{
			oldRootPath = FileUtility.ApplicationRootPath;
			FileUtility.ApplicationRootPath = @"D:\SharpDevelop";
		}
		
		[TestFixtureTearDown]
		public void TearDownFixture()
		{
			FileUtility.ApplicationRootPath = oldRootPath;
		}
		
		[Test]
		public void NothingSpecified()
		{
			MockCSharpProject project = new MockCSharpProject();
			SelectedTests selectedTests = new SelectedTests(project);
			NUnitConsoleApplication app = new NUnitConsoleApplication(selectedTests);
			Assert.AreEqual(@"D:\SharpDevelop\bin\Tools\NUnit\nunit-console-x86.exe", app.FileName);
		}
		
		[Test]
		public void TargetCpuAnyCPUDotnet2()
		{
			MockCSharpProject project = new MockCSharpProject();
			project.ActiveConfiguration = "Debug";
			project.ActivePlatform = "AnyCPU";
			project.SetProperty("PlatformTarget", "AnyCPU");
			project.SetProperty("TargetFrameworkVersion", "v3.5");
			
			SelectedTests selectedTests = new SelectedTests(project);
			NUnitConsoleApplication app = new NUnitConsoleApplication(selectedTests);
			Assert.AreEqual(@"D:\SharpDevelop\bin\Tools\NUnit\nunit-console-dotnet2.exe", app.FileName);
		}
		
		[Test]
		public void NUnitConsole32BitUsedWhenTargetCpuIs32BitDotnet2()
		{
			MockCSharpProject project = new MockCSharpProject();
			project.ActiveConfiguration = "Debug";
			project.ActivePlatform = "AnyCPU";
			project.SetProperty("PlatformTarget", "x86");
			project.SetProperty("TargetFrameworkVersion", "v3.5");
			
			SelectedTests selectedTests = new SelectedTests(project);
			NUnitConsoleApplication app = new NUnitConsoleApplication(selectedTests);
			Assert.AreEqual(@"D:\SharpDevelop\bin\Tools\NUnit\nunit-console-dotnet2-x86.exe", app.FileName);
		}
		
		[Test]
		public void NUnitConsole32BitUsedWhenTargetCpuIs32Bit()
		{
			MockCSharpProject project = new MockCSharpProject();
			project.ActiveConfiguration = "Debug";
			project.ActivePlatform = "AnyCPU";
			project.SetProperty("PlatformTarget", "x86");
				
			SelectedTests selectedTests = new SelectedTests(project);
			NUnitConsoleApplication app = new NUnitConsoleApplication(selectedTests);
			Assert.AreEqual(@"D:\SharpDevelop\bin\Tools\NUnit\nunit-console-x86.exe", app.FileName);			
		}
		
		[Test]
		public void NotMSBuildBasedProject()
		{
			MissingProject project = new MissingProject(@"C:\Projects\Test.proj", "Test");
			SelectedTests selectedTests = new SelectedTests(project);
			NUnitConsoleApplication app = new NUnitConsoleApplication(selectedTests);
			
			Assert.AreEqual(project.GetType().BaseType, typeof(AbstractProject), "MissingProject should be derived from AbstractProject.");
			Assert.AreEqual(@"D:\SharpDevelop\bin\Tools\NUnit\nunit-console.exe", app.FileName);			
		}
	}
}

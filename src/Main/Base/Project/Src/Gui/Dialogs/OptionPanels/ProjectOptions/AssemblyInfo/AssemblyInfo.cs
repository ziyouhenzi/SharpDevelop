// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;

namespace ICSharpCode.SharpDevelop.Gui.OptionPanels
{
	/// <summary>
	/// Assembly info parameters model
	/// </summary>
	public class AssemblyInfo
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public string Company { get; set; }

		public string Product { get; set; }

		public string Copyright { get; set; }

		public string Trademark { get; set; }

		public string DefaultAlias { get; set; }

		public Version AssemblyVersion { get; set; }

		public Version AssemblyFileVersion { get; set; }

		public Version InformationalVersion { get; set; }

		public Guid? Guid { get; set; }

		public string NeutralLanguage { get; set; }

		public bool ComVisible { get; set; }

		public bool ClsCompliant { get; set; }

		public bool JitOptimization { get; set; }

		public bool JitTracking { get; set; }
	}
}
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if SINGLE_PRECISION
[assembly: AssemblyTitle("ODE.NET - Single Precision")]
#elif DOUBLE_PRECISION
[assembly: AssemblyTitle("ODE.NET - Double Precision")]
#else
#error You must define SINGLE_PRECISION or DOUBLE_PRECISION
#endif
[assembly: AssemblyDescription("A .NET interface for the popular ODE physics engine.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Gonçalo Lopes")]
[assembly: AssemblyProduct("Ode.Net")]
[assembly: AssemblyCopyright("Copyright © Gonçalo Lopes 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("cc5a8400-6ab3-4b2c-8fe2-30b09522a9d0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.4")]

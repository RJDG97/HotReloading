using System;
using System.Reflection;

using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace ConsoleApp1
{
    class Application
    {
        static MethodInfo prntmethod;
        static MethodInfo compilemethod;
        static Object obj;

        static void GetDLL()
        {
            string file = @"C:\Users\Renzo\source\repos\HotReloading\HotReloading.dll";
            Assembly assembly = Assembly.LoadFile(file);

            Type type = assembly.GetType("HotReloading.Program");

            obj = Activator.CreateInstance(type);

            prntmethod = type.GetMethod("Print");
            compilemethod = type.GetMethod("CompileDLL");
        }
        public static void CompileDLL()
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" }, "test");
            // Set compilation output to dll (true = exe, false = dll)
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "HotReloading2.dll";
            // Save as dll
            parameters.GenerateInMemory = true;
            // Generate DLL
            var result = provider.CompileAssemblyFromFile(parameters, new string[] { @"C:\Users\Renzo\source\repos\HotReloading\Program.cs", @"C:\Users\Renzo\source\repos\HotReloading\test\check.cs" });

            if (result.Errors.Count != 0)
            {
                foreach (CompilerError error in result.Errors)
                    Console.WriteLine(error.ErrorText);
            }
        }
        static void Main(string[] args)
        {
            GetDLL();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Backspace)
                {
                    GetDLL();
                    Console.WriteLine("Get DLL");
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    compilemethod.Invoke(obj, new object[] { });
                    Console.WriteLine("Compile DLL");
                }
                if (key.Key == ConsoleKey.Spacebar)
                    prntmethod.Invoke(obj, new object[] { });
                if (key.Key == ConsoleKey.Escape)
                    break;
            };
        }
    }
}

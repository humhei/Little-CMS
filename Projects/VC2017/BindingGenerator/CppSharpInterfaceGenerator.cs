using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CppSharp;
using CppSharp.AST;
using System.IO;
using CppSharp.Generators;

namespace BindingGenerator
{
    static class Extensions
    {
        public static string GetParentDirectoryText(this string path)
        {
            return Directory.GetParent(path).FullName;
        }
    }

    class CppSharpInterfaceGenerator : ILibrary
    {
        void ILibrary.Setup(Driver driver)
        {
            var solutionDirectory =
                Directory.GetCurrentDirectory()
                    .GetParentDirectoryText()
                    .GetParentDirectoryText()
                    .GetParentDirectoryText()
                    .GetParentDirectoryText();

            var clibraryName = "icms2_clr";
            var headerFile = "icms2_clr.h";
            var moduleName = clibraryName;
            var clibraryOutputDll = Path.Combine(solutionDirectory, "Debug", clibraryName + ".dll");
            var clibraryOutputLib = Path.Combine(solutionDirectory, "Debug", clibraryName + ".lib");

            var addtionalIncludeDir =
                Path.Combine(
                    solutionDirectory
                        .GetParentDirectoryText()
                        .GetParentDirectoryText(), "include");




            var options = driver.Options;
            options.GeneratorKind = GeneratorKind.CSharp;
            options.OutputDir = solutionDirectory;

            var module = options.AddModule(moduleName);
            module.IncludeDirs.Add(Path.Combine(solutionDirectory, clibraryName));
            module.IncludeDirs.Add(addtionalIncludeDir);
            module.Headers.Add(headerFile);
            module.LibraryDirs.Add(Path.GetDirectoryName(clibraryOutputLib));

            module.Libraries.Add(Path.GetFileName(clibraryOutputLib));
        }

        public void SetupPasses(Driver driver)
        {
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.GenerateEnumFromMacros("Format", "TYPE_*");
            ctx.GenerateEnumFromMacros("Indent", "INTENT_*");
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }
    }
}
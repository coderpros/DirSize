using System;
using System.IO;
using System.Linq;

namespace CoderPro.DirSize
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                string path = args[0];
                var desiredSizeUnit = SizeUnits.GB;

                if (args.Contains("/?"))
                {
                    PrintHelp();

                    return;
                }

                if (args.Contains("/MB"))
                {
                    desiredSizeUnit = SizeUnits.MB;
                }

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Console.WriteLine($"ERROR: {args[0]} - Directory does not exist.");
                }
                else
                {
                    if (path.EndsWith("\""))
                    {
                        path = path.Substring(0, path.Length - 1);
                    }

                    Console.WriteLine($"{ DirSize(new DirectoryInfo(path), args.Contains("/v"), desiredSizeUnit).ToSize(desiredSizeUnit) } {desiredSizeUnit.ToString() } | {new DirectoryInfo(path).EnumerateFiles("*", SearchOption.AllDirectories).LongCount().ToString("N0")} files- {path}");
                }
            }
            else
            {
                PrintHelp();
            }
        }

        static private long DirSize(DirectoryInfo d, bool verbose, SizeUnits desiredSizeUnit)
        {
            long size = 0;
            long fileCount = 0;

            // Add file sizes.
            var fis = d.EnumerateFiles();
            foreach (var fi in fis)
            {
                size += fi.Length;
                fileCount += 1;
            }

            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                long currentDirectorySize = DirSize(di, verbose, desiredSizeUnit);
                size += currentDirectorySize;

                if (verbose)
                {
                    Console.WriteLine($"{ currentDirectorySize.ToSize(desiredSizeUnit) } {desiredSizeUnit.ToString()} | {fileCount.ToString("N0")} files - { di.FullName }");
                }
            }

            return size;
        }

        static private void PrintHelp()
        {
            Console.WriteLine("Displays the complete size of a directory and optionally its children.\n");
            Console.WriteLine(
               $"{AppDomain.CurrentDomain.FriendlyName} [drive:][path] [/v] \n");
            Console.WriteLine("\t/v\t\t\t Verbose. Recursive breakdown of each directory.");
            Console.WriteLine("\t/?\t\t\t This help file.");
        }

        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        // TODO: Convert to extension function.
        private static string ToSize(this Int64 value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit)).ToString("0.00");
        }
    }
}

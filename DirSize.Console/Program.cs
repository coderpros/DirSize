namespace CoderPro.DirSize
{
    using System;
    using System.IO;
    using System.Linq;

    internal static class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                var desiredSizeUnit = SizeUnits.GB;
                string path = args[0];
                long directorySize = 0;
                long fileCount = 0;

                if (args.Contains("/?"))
                {
                    PrintHelp();

                    return;
                }

                if (args.Contains("/mb"))
                {
                    desiredSizeUnit = SizeUnits.MB;
                }

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Console.WriteLine($"ERROR: {args[0]} - Directory does not exist.");
                }
                else
                {
                    var d = new DirectoryInfo(path);

                    if (path.EndsWith("\""))
                    {
                        path = path.Substring(0, path.Length - 1);
                    }

                    try
                    {
                        directorySize = DirSize(d, args.Contains("/v"), desiredSizeUnit);
                        fileCount = new DirectoryInfo(path).EnumerateFiles("*", SearchOption.AllDirectories).LongCount();


                        Console.WriteLine($"{ directorySize.ToSize(desiredSizeUnit) } {desiredSizeUnit} | {fileCount.ToString("N0")} files - {path}");
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, d);
                        Console.WriteLine($"BEST GUESS: { directorySize.ToSize(desiredSizeUnit) } {desiredSizeUnit} - {path}");
                    }

                }
            }
            else
            {
                PrintHelp();
            }
        }

        private static long DirSize(DirectoryInfo d, bool verbose, SizeUnits desiredSizeUnit)
        {
            long size = 0;
            long fileCount = 0;

            // Add file sizes.
            try
            {
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

            }
            catch (Exception ex)
            {
                HandleException(ex, d);

            }

            return size;
        }

        private static void HandleException(Exception ex, DirectoryInfo d)
        {
            switch (ex.HResult)
            {
                case -2147024891:
                    Console.WriteLine($"ERROR: Insufficient Priviledges to access directory ({d.FullName})");
                    break;
                default:
                    Console.WriteLine($"ERROR: UNEXPECTED ERROR: {ex.HResult} - {ex.Message}");
                    break;
            }
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

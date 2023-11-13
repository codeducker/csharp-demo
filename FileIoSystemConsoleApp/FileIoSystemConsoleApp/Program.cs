using System;
using System.IO;
namespace FileIoSystemConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enumerateFiles = Directory.EnumerateFiles(@"C:\Users\PCSW015--PC\Desktop","ta*",SearchOption.AllDirectories);
            foreach (var file in enumerateFiles)
            {
                Console.WriteLine(file);
            }
            // var enumerateDirectories = Directory.EnumerateDirectories(@"C:\Users\PCSW015--PC\Desktop","*");
            // foreach (var directory in enumerateDirectories)
            // {
            //     Console.WriteLine(directory);
            // }

            // File.AppendAllLines(Path.Combine(@"C:\Users\PCSW015--PC\Desktop", @"testWrite.txt"), new string[] { "Append Line" });

            // File.WriteAllLines(Path.Combine(@"C:\Users\PCSW015--PC\Desktop", @"testWrite.txt"),new string[]{"new Line"});

            // ReadFileLines(Path.Combine(@"C:\Users\PCSW015--PC\Desktop", @"testWrite.txt"),false);

            // PrintFileInfo(Path.Combine(@"C:\Users\PCSW015--PC\Desktop", @"testWrite.txt"));

            // WriteFile(Path.Combine(@"C:\Users\PCSW015--PC\Desktop", @"testWrite.txt"),"Hello World File");

            // GetDocumentsFolder();

            // Console.WriteLine(Path.Combine(@"c:","readme.txt"));

            // CopyFile(@"C:\Users\PCSW015--PC\Desktop\testWrite.txt", @"C:\Users\PCSW015--PC\Desktop\copyTestWrite.txt",false);
            // CopyFile(@"C:\Users\PCSW015--PC\Desktop\testWrite.txt", @"C:\Users\PCSW015--PC\Desktop\copyTestWrite.txt",true);

            // ListDriverInfos();
        }

        private static void ReadFileLines(string fileName,bool isHoldFile)
        {
            IEnumerable<string> readAllLines;

            if (isHoldFile)
            {
                readAllLines = File.ReadAllLines(fileName);
            }
            else
            {
                readAllLines = File.ReadLines(fileName);
            }

            foreach (var readAllLine in readAllLines)
            {
                Console.WriteLine(readAllLine);
            }
        }

        private static void WriteFile(string fileName,string content)
        {
            var combine = Path.Combine(fileName);
            File.WriteAllText(combine, content);
        }

        private static void PrintFileInfo(string fileName)
        {
            var file = new FileInfo(fileName);
            Console.WriteLine($"Name: {file.Name}");
            Console.WriteLine($"Directory: {file.DirectoryName}");
            Console.WriteLine($"Read only: {file.IsReadOnly}");
            Console.WriteLine($"Extension: {file.Extension}");
            Console.WriteLine($"Length: {file.Length}");
            Console.WriteLine($"Creation time: {file.CreationTime:F}");
            Console.WriteLine($"Access time: {file.LastAccessTime:F}");
            Console.WriteLine($"File attributes: {file.Attributes}");
        }

        private static void CopyFile(string sourceFile,string targetFile,bool staticMethod)
        {
            if (staticMethod)
            {
                File.Copy(sourceFile, targetFile);
            }
            else
            {
                var fileInfo = new FileInfo(sourceFile);
                fileInfo.CopyTo(targetFile);
            }
        }

        private static void ListDriverInfos()
        {
            var driveInfos = DriveInfo.GetDrives();
            foreach (var driveInfo in driveInfos)
            {
                if (driveInfo.IsReady)
                {
                    Console.WriteLine(driveInfo.Name);
                    Console.WriteLine($"Format: {driveInfo.DriveFormat}");
                    Console.WriteLine($"Type: {driveInfo.DriveType}");
                    Console.WriteLine($"Root directory: {driveInfo.RootDirectory}");
                    Console.WriteLine($"Volume label: {driveInfo.VolumeLabel}");
                    Console.WriteLine($"Free space: {driveInfo.TotalFreeSpace}");
                    Console.WriteLine($"Available space: {driveInfo.AvailableFreeSpace}");
                    Console.WriteLine($"Total size: {driveInfo.TotalSize}");
                }
            }
        }

        private static string GetDocumentsFolder()
        {
#if NET46
          return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
#else
            string? drive = Environment.GetEnvironmentVariable("HOMEDRIVE");
            string? path = Environment.GetEnvironmentVariable("HOMEPATH");
            return Path.Combine(drive??"", path??"", "documents");
#endif
        }
    }
}
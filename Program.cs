using System;
using System.IO;
using System.Threading.Tasks;
using LibVLCSharp.Shared;

namespace LibVLCSharp_Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var inDir = @""; //Path to folder containg a large amount of videos

            Core.Initialize();
            
            double time = 0;

            using var libVLC = new LibVLC();

            foreach (var file in Directory.EnumerateFiles(inDir)){

                using (var media = new Media(libVLC, new Uri(file))){

                    Console.WriteLine(file);
                    await media.Parse(MediaParseOptions.ParseLocal, 0);

                    time += media.Duration;   
                }
            }

            Console.WriteLine($"Total video time {time / 1000} seconds");
        }
    }
}

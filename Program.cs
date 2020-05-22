using CommandLine;
using ImageMagick;
using System;
using System.IO;

namespace ResizeMagick.NET
{
    class Program
    {
        class Options
        {
            [Option('i', "input", Required = true, HelpText = "path to the input file")]
            public string InputFile { get; set; }

            [Option('o', "output", Required = true, HelpText = "path to the output file.")]
            public string OutputFile { get; set; }
        }
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    Console.WriteLine($"Converting {o.InputFile} to {o.OutputFile}");

                    using (Stream stream = new FileStream(o.InputFile, FileMode.Open))
                    {
                        ConvertToPNG(stream, o.OutputFile, out decimal width, out decimal height);
                            Console.WriteLine($"{o.OutputFile} is of size {width} x {height}");
                    }
                });
        }

        static bool ConvertToPNG(Stream imageStream, string targetFilePath, out decimal width, out decimal height)
        {
            bool success = false;
            width = height = -1;

            if (imageStream != null)
            {
                imageStream.Position = 0;
                try
                {
                    int newWidth = 1984, newHeight = 1984;

                    using (MagickImage image = new MagickImage(imageStream))
                    {
                        image.Resize(newWidth, newHeight);
                        image.Write(targetFilePath);
                        success = true;

                        width = image.Width;
                        height = image.Height;
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("ConvertToPNG: SVG Manipulation failed", ex);
                }
            }
            else
                Console.Error.WriteLine("ConvertToPNG: Empty SVG string. Will fail.");
            return success;
        }
    }
}

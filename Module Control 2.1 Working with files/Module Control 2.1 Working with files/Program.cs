using System;
using System.IO;

namespace Module_Control_2._1_Working_with_files
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sourceText = @"Text:file.txt(6B);Some string content
            //                Image:img.bmp(19MB);1920x1080
            //                Text:data.txt(12B);Another string
            //                Text:data1.txt(7B);Yet another string
            //                Movie:logan.2017.mkv(19GB);1920x1080;2h12m
            //                Movie:Matrix.2000.avi(16GB);1280x720;1h59m
            //                Image:MyImage.jpg(10MB);800x600";
            string readPath = @"D:\Downloads\\C#\IT Cloud Academy\Module-Control\Module Control 2.1 Working with files\Input Text.txt";
            string writePath = @"D:\Downloads\\C#\IT Cloud Academy\Module-Control\Module Control 2.1 Working with files\Output Text.txt";
            //File.WriteAllText(readPath, sourceText);

            // read from file to a variable 'text'
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string[] substrins = text.Split('\n');
            var files = new BaseFile[substrins.Length];

            for (int i = 0; i < substrins.Length; i++)
            {
                if (substrins[i].Contains("Text:"))
                {
                    substrins[i] = substrins[i].Remove(0, substrins[i].IndexOf(':'));
                    string[] attributes = substrins[i].Split(';');
                    attributes[0] = attributes[0].TrimEnd(')', 'B', 'M');
                    files[i] = new TextFile
                    {
                        Name = attributes[0].Substring(attributes[0].IndexOf(':') + 1, attributes[0].IndexOf('(') - 1),
                        Extension = attributes[0].Substring(attributes[0].IndexOf('(') - 3, 3),
                        Size = int.Parse(attributes[0].Substring(attributes[0].IndexOf('(') + 1)),
                        Content = attributes[1].TrimEnd()
                    };
                }
                else if (substrins[i].Contains("Movie:"))
                {
                    substrins[i] = substrins[i].Remove(0, substrins[i].IndexOf(':'));
                    string[] attributes = substrins[i].Split(';');
                    attributes[0] = attributes[0].TrimEnd(')', 'B', 'M', 'G');
                    files[i] = new Movie
                    {
                        Name = attributes[0].Substring(attributes[0].IndexOf(':') + 1, attributes[0].IndexOf('(') - 1),
                        Extension = attributes[0].Substring(attributes[0].IndexOf('(') - 3, 3),
                        Size = int.Parse(attributes[0].Substring(attributes[0].IndexOf('(') + 1)),
                        Resolution = attributes[1],
                        Length = attributes[2]
                    };
                }
                else if (substrins[i].Contains("Image:"))
                {
                    substrins[i] = substrins[i].Remove(0, substrins[i].IndexOf(':'));
                    string[] attributes = substrins[i].Split(';');
                    attributes[0] = attributes[0].TrimEnd(')', 'B', 'M');
                    files[i] = new Image
                    {
                        Name = attributes[0].Substring(attributes[0].IndexOf(':') + 1, attributes[0].IndexOf('(') - 1),
                        Extension = attributes[0].Substring(attributes[0].IndexOf('(') - 3, 3),
                        Size = int.Parse(attributes[0].Substring(attributes[0].IndexOf('(') + 1)),
                        Resolution = attributes[1]
                    };
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                for (int j = i; j < files.Length; j++)
                {
                    if (files[i].Size > files[j].Size)
                    {
                        var temp = files[i];
                        files[i] = files[j];
                        files[j] = temp;
                    }
                }
            }

            // write to file output text
            // false => rewrite file
            StreamWriter sw = new StreamWriter(writePath, false);
            Console.Write("Text files:\n");
            sw.WriteLine("Text files:\n");
            foreach (var file in files)
            {
                if (file is TextFile)
                {
                    Console.WriteLine($"\t{file}");
                    sw.WriteLine($"\t{file}");
                }
            }

            Console.Write("Movies:\n");
            sw.WriteLine("Movies:\n");
            foreach (var file in files)
            {
                if (file is Movie)
                {
                    Console.WriteLine($"\t{file}");
                    sw.WriteLine($"\t{file}");
                }
            }

            Console.Write("Images:\n");
            sw.WriteLine("Images:\n");
            foreach (var file in files)
            {
                if (file is Image)
                {
                    Console.WriteLine($"\t{file}");
                    sw.WriteLine($"\t{file}");
                }
            }
            sw.Close();
       
            Console.ReadKey();
        }
    }
}

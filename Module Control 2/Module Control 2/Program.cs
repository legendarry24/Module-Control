using System;

namespace Module_Control_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Text:file.txt(6B);Some string content
                            Image:img.bmp(19MB);1920x1080
                            Text:data.txt(12B);Another string
                            Text:data1.txt(7B);Yet another string
                            Movie:logan.2017.mkv(19GB);1920x1080;2h12m
                            Movie:Matrix.2000.avi(16GB);1280x720;1h59m
                            Image:MyImage.jpg(10MB);800x600";          
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

            Console.Write("Text files:\n");
            foreach (var file in files)
            {
                if (file is TextFile)
                {
                    Console.WriteLine($"\t{file}");
                }
            }

            Console.Write("Movies:\n");
            foreach (var file in files)
            {
                if (file is Movie)
                {
                    Console.WriteLine($"\t{file}");
                }
            }

            Console.Write("Images:\n");
            foreach (var file in files)
            {
                if (file is Image)
                {
                    Console.WriteLine($"\t{file}");
                }
            }

            Console.ReadKey();
        }
    }
}

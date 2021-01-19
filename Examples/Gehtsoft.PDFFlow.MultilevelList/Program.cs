using System;

namespace Gehtsoft.PDFFlow.MultilevelList.ConsoleDemos
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Gehtsoft.PDFFlow.Demos");
            Console.WriteLine("----------------------");
            Console.WriteLine("MultilevelList");
            Console.WriteLine("----------------------");
            GenerateExample();
            Console.WriteLine("");
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }        
        private static void GenerateExample() => MultilevelListExample.GenerateExample();
    }
}
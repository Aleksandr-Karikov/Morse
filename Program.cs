using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace morse_code
{
   
    class Program
    {
        delegate string tr(string input,string language);
        static void Main(string[] args)
        {
            tr translater;
            string Path_read = @"C:\Users\Александр\Desktop\testread.txt";
            string Path_write = @"C:\Users\Александр\Desktop\testwrite.txt";
            Console.WriteLine("1 - translate from morse");
            Console.WriteLine("2 - translate to morse");
            string key = Console.ReadLine();
            if (key == "1")
            {
                translater = Morse.TranslateFromMorse;
            }
            else
            {
                if (key == "2")
                {
                    translater = Morse.TranslateToMorse;
                }else
                {
                    return;
                }
            }
            string language="";
            Console.WriteLine("1 - rus");
            Console.WriteLine("2 - eng");
            key = Console.ReadLine();
            if (key == "1")
            {
                language = "rus";
            }
            else
            {
                if (key == "2")
                {
                    language = "eng";
                }
                else
                {
                    return;
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(Path_read))
                {
                    string line;
                         while ( (line = sr.ReadLine()) != null )
                         {
                        
                                 using (StreamWriter sw = new StreamWriter(Path_write, true, System.Text.Encoding.Default))
                                 {
                                     sw.WriteLine(translater(line,language));
                                 }
                         }
                    Console.WriteLine("Запись завершена");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

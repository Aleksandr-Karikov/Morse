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
        delegate string tr(string input);
        static void Main(string[] args)
        {
           // tr translater;
            bool to; // перевод из или в азбукук морзе
            string Path_read = @"C:\Users\Александр\Desktop\testread.txt"; //откуда читаем
            string Path_write = @"C:\Users\Александр\Desktop\testwrite.txt"; //куда читаем
            string Path_write2 = @"C:\Users\Александр\Desktop\testwrite2.txt";
            Console.WriteLine("1 - translate from morse"); //из азбуки или в азбуку
            Console.WriteLine("2 - translate to morse");
            string key = Console.ReadLine(); //в зависимости от выбора присваем делегату нужный метод и булевой переменной нужное значение
            if (key == "1")
            {
               // translater = Morse.TranslateFromMorse;
                to = false;
            }
            else
            {
                if (key == "2")
                {
               //   translater = Morse.TranslateToMorse;
                    to = true;
                }else
                {
                    return;
                }
            }
            string language=""; //язык
            Console.WriteLine("1 - rus");
            Console.WriteLine("2 - eng");
            key = Console.ReadLine(); //определяемся с языком
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
                Morse abc = new Morse(language, to); //вызываем конструктор для определения языка и превода из либо в азбуку морза
                using (StreamReader sr = new StreamReader(Path_read)) //поток чтения из файла
                {
                    string line; //строка для счтывания
                         while ( (line = sr.ReadLine()) != null )
                         {
                            
                                 using (StreamWriter sw = new StreamWriter(Path_write, true, System.Text.Encoding.Default))  //поток записи
                                 {
                                     sw.WriteLine(abc.TranslateToMorse(line)); //записываем в файл результат перевода строки
                                 }
                         }
            
          
                        Console.WriteLine("Запись завершена");
                }
           
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Morse abc2 = new Morse(language, !to);
                using (StreamReader sr = new StreamReader(Path_write)) //поток чтения из файла
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        using (StreamWriter sw = new StreamWriter(Path_write2, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(abc2.TranslateFromMorse(line));
                        }
                    }
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

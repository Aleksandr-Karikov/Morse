using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace morse_code
{
    class Morse
    {
        private static Dictionary<string, string> lang = new Dictionary<string, string> { [""] = "" }; // словарь для азбуки

        public Morse(string language,bool to) //конструктор с определением языка и определением первода из азбуки морза или в азбуку морзе
        {
            string Path_read; //путь к файлу с языками 
            if (language == "rus")  //в зависимости от языка определяем путь
            {
                Path_read = @"C:\Users\Александр\source\repos\ConsoleApp8\dic_2_rus.txt";
            }
            else
            {
                Path_read = @"C:\Users\Александр\source\repos\ConsoleApp8\dic_1_eng.txt";
            }
           try
           {
               using (StreamReader sr = new StreamReader(Path_read)) // создаем поток чтения
               {
                   string key="", ch="",line; //key - ключ ch - то что лежит в словаре по данному ключу, в line считываем строчку с файла
                   while ((line = sr.ReadLine()) != null) //пока считывает строку
                   {
                        line += '\n'; //добавляем перенос строки
                       int i = 0; //счетчик 
                       while (line[i]!=' ') //пока не встретим пробел
                       {
                           if (to)              //в зависимости от превод из азбуки морза или в азбуку морза
                           {                    // считываем ключ либо значение
                               ch += line[i];
                           } else
                           {
                               key += line[i];
                           }
                            i++;
                       }
                        i++;
                       while(line[i] != '\n') //пока е дойдем до конца строки
                       {
                           if (to)                        //в зависимости от превод из азбуки морза или в азбуку морза
                            {                              // считываем ключ  либо значение
                               key += line[i];
                           }
                           else
                           {
                               ch += line[i];
                           }
                            i++;
                       }
                        lang.Add(key, ch); // добавляем элемент в словарь
                        key = "";       //чистим 
                        ch = "";
                   }
               }
            }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }
           
        }
        public static string TranslateFromMorse(string input) //перевод из азбуки морза
        { 
            string output = ""; //строка на выход
            string temp = ""; // копирование
            input += ' '; // искуственно добавляем пробел в конец строки
            int i = 0; //счетчик
                while (i < input.Length) // пока не дойдем до конца строки
                {
                    if (input[i] == ' ' && i + 1 < input.Length) //проверка на два пробела (чтобы отделять слова друг от друга)
                    {
                        if (input[i + 1] == ' ' && temp != "")
                        {
                            try
                            {
                                output += lang[temp]; //пытаемя считать со словаря
                            }                         //если такого элемента нет в словаре записываем строку не изменной
                            catch (Exception)
                            {
                                output += temp;
                            }
                            output += input[i]; //добавляем пробел для разделения слов
                            temp = ""; //чистим temp
                            i += 2; // пропускаем 2 пробела
                            continue;
                        }
                    }

                    if (input[i] == ' ' && temp != "") // если встречаем пробел и temp не пуст
                    {
                        output += lang[temp]; // переводим с помощью словаря и записываем к выходной строке
                        temp = "";  //чистим temp
                        i++;
                        continue;
                    }
                    if (input[i] != ' ') //если элемент это не пробел
                        temp += input[i]; // записываем в temp
                    i++;
                }
                return output; //возвращаеем выходную строку
        }
        public static string TranslateToMorse(string input) //перевод в азбуку морза
        {
            string output = ""; //выходня строка 
            int i = 0; // счетчик
                while (i < input.Length) //пока не дойдем до конца строки
                {
                    if (input[i] == ' ') //если встечаем пробел добавляем пробел на выход для разделения строк
                    {
                        output += ' ';
                    }
                    if (input[i] != ' ') //если не пробел
                    {
                    try
                    {
                        output += lang[input[i].ToString()]; //попытаться считать со словаря
                    }
                    catch (Exception)
                    {
                        output += input[i].ToString(); //если такого элемента нет в словаре то записываем без изменений
                    }
                    output += ' '; //добавляем пробел
                    }
                    i++;
                }
            return output; //возвращаем выходную строку
        }
    }
}

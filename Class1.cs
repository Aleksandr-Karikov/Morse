using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morse_code
{
    class Morse
    {
        public static Exception incorrect = new Exception("incorrect text");
        private static Dictionary<string, string> m_c_1ENG = new Dictionary<string, string>(36)
        {
            ["*-"] = "A",
            ["-***"] = "B",
            ["-*-*"] = "C",
            ["-**"] = "D",
            ["*"] = "E",
            ["**-*"] = "F",
            ["--*"] = "G",
            ["****"] = "H",
            ["**"] = "I",
            ["*---"] = "J",
            ["-*-"] = "K",
            ["*-**"] = "L",
            ["--"] = "M",
            ["-*"] = "N",
            ["---"] = "O",
            ["*--*"] = "P",
            ["--*-"] = "Q",
            ["*-*"] = "R",
            ["***"] = "S",
            ["-"] = "T",
            ["**-"] = "U",
            ["***-"] = "V",
            ["*--"] = "W",
            ["-**-"] = "X",
            ["-*--"] = "Y",
            ["--**"] = "Z",
            ["*----"] = "1",
            ["**---"] = "2",
            ["***--"] = "3",
            ["****-"] = "4",
            ["*****"] = "5",
            ["-****"] = "6",
            ["--***"] = "7",
            ["---**"] = "8",
            ["----*"] = "9",
            ["-----"] = "0"
        };
        private static Dictionary<string, string> m_c_1RUS = new Dictionary<string, string>(36)
        {
            ["*-"] = "А",
            ["-***"] = "Б",
            ["*--"] = "В",
            ["--*"] = "Г",
            ["-**"] = "Д",
            ["*"] = "Е",
            ["***-"] = "Ж",
            ["--**"] = "З",
            ["**"] = "И",
            ["*---"] = "Й",
            ["-*-"] = "К",
            ["*-**"] = "Л",
            ["--"] = "М",
            ["-*"] = "Н",
            ["---"] = "О",
            ["*--*"] = "П",
            ["*-*"] = "Р",
            ["***"] = "С",
            ["-"] = "Т",
            ["**-"] = "У",
            ["**-*"] = "Ф",
            ["****"] = "Х",
            ["-*-*"] = "Ц",
            ["---*"] = "Ч",
            ["----"] = "Ш",
            ["--*-"] = "Щ",
            ["*--*-*"] = "Ъ",
            ["-*--"] = "Ы",
            ["-**-"] = "Ь",
            ["***-***"] = "Э",
            ["**--"] = "Ю",
            ["*-*-"] = "Я",
            ["*----"] = "1",
            ["**---"] = "2",
            ["***--"] = "3",
            ["****-"] = "4",
            ["*****"] = "5",
            ["-****"] = "6",
            ["--***"] = "7",
            ["---**"] = "8",
            ["----*"] = "9",
            ["-----"] = "0"
        };
        private static Dictionary<string, string> m_c_2ENG = new Dictionary<string, string>(36)
        {
            ["A"] = "*-",
            ["B"] = "-***",
            ["C"] = "-*-*",
            ["D"] = "-**",
            ["E"] = "*",
            ["F"] = "**-*",
            ["G"] = "--*",
            ["H"] = "****",
            ["I"] = "**",
            ["J"] = "*---",
            ["K"] = "-*-",
            ["L"] = "*-**",
            ["M"] = "--",
            ["N"] = "-*",
            ["O"] = "---",
            ["P"] = "*--*",
            ["Q"] = "--*-",
            ["R"] = "*-*",
            ["S"] = "***",
            ["T"] = "-",
            ["U"] = "**-",
            ["V"] = "***-",
            ["W"] = "*--",
            ["X"] = "-**-",
            ["Y"] = "-*--",
            ["Z"] = "--**",
            ["1"] = "*----",
            ["2"] = "**---",
            ["3"] = "***--",
            ["4"] = "****-",
            ["5"] = "*****",
            ["6"] = "-****",
            ["7"] = "--***",
            ["8"] = "---**",
            ["9"] = "----*",
            ["0"] = "-----"
        };
        private static Dictionary<string, string> m_c_2RUS = new Dictionary<string, string>(36)
        {
            ["*-А"] = "*-",
            ["Б"] = "-***",
            ["В"] = "*--",
            ["Г"] = "--*",
            ["Д"] = "-**",
            ["Е"] = "*",
            ["Ж"] = "***-",
            ["З"] = "--**",
            ["И"] = "**",
            ["Й"] = "*---",
            ["К"] = "-*-",
            ["Л"] = "*-**",
            ["М"] = "--",
            ["Н"] = "-*",
            ["О"] = "---",
            ["П"] = "*--*",
            ["Р"] = "*-*",
            ["С"] = "***",
            ["Т"] = "-",
            ["У"] = "**-",
            ["Ф"] = "**-*",
            ["Х"] = "****",
            ["Ц"] = "-*-*",
            ["Ч"] = "---*",
            ["Ш"] = "----",
            ["Щ"] = "--*-",
            ["Ъ"] = "*--*-*",
            ["Ы"] = "-*--",
            ["Ь"] = "-**-",
            ["Э"] = "***-***",
            ["Ю"] = "**--",
            ["Я"] = "*-*-",
            ["1"] = "*----",
            ["2"] = "**---",
            ["3"] = "***--",
            ["4"] = "****-",
            ["5"] = "*****",
            ["6"] = "-****",
            ["7"] = "--***",
            ["8"] = "---**",
            ["9"] = "----*",
            ["0"] = "-----"
        };
        private static Dictionary<string, string> copy = new Dictionary<string, string> { [""] = "" };
        public static string TranslateFromMorse(string input,string language)
        {
            if (language=="rus")
            {
                     copy = m_c_1RUS;
            } else
            {
                if (language == "eng")
                {
                    copy = m_c_1ENG;
                }
            }
            try
            {
                string temp = "";
                string output = "";
                input += ' ';
                int i = 0;
                while (i < input.Length)
                {
                    if (input[i] == ' ' && i+1<input.Length )
                    {
                        if (input[i + 1] == ' ' && temp != "")
                        {
                            output += copy[temp];
                            output += input[i];
                            temp = "";
                            i += 2;
                            continue;
                        }
                    }
                   
                    if (input[i] == ' ' && temp != "")
                        {
                            output += copy[temp];
                            temp = "";
                            i++;
                            continue;
                        }
                   if (input[i] != ' ')
                       temp += input[i];
                    i++;
                }
                return output;
            }
            catch(Exception)
            {
                throw incorrect;
            }
        }
        public static string TranslateToMorse(string input, string language)
        {
            if (language == "rus")
            {
                copy = m_c_2RUS;
            }
            else
            {
                if (language == "eng")
                {
                    copy = m_c_2ENG;
                }
            }
            try
            {
                string output = "";
                int i = 0;
                while (i < input.Length)
                {
                    if (input[i]==' ')
                    {
                        output += ' ';
                    }
                    if (input[i] != ' ')
                    {
                        output += copy[input[i].ToString()];
                        output += ' ';
                    }
                    i++;
                }
                return output;
            } 
            catch(Exception)
            {
                throw incorrect;
            }
        }
    }
}

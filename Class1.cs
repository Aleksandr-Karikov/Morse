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
        private static Dictionary<string, string> m_c_1 = new Dictionary<string, string>(36)
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
        private static Dictionary<string, string> m_c_2 = new Dictionary<string, string>(36)
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
        public static string TranslateFromMorse(string input)
        {
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
                            output += m_c_1[temp];
                            output += input[i];
                            temp = "";
                            i += 2;
                            continue;
                        }
                    }
                   
                    if (input[i] == ' ' && temp != "")
                        {
                            output += m_c_1[temp];
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
        public static string TranslateToMorse(string input)
        {
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
                        output += m_c_2[input[i].ToString()];
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

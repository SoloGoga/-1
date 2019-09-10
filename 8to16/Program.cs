using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8to16
{
    class Program
    {
        static String hexa = "0123456789ABCDEF";  //"алфавит" шестнадцатиричной системы

        static void Main(string[] args)
        {
            String temp = "";
            String output = "";

            int a, fir = 0, sec = 0, thi = 0, fou = 0;

            //чтение файла
            using (StreamReader sr = new StreamReader(@"D:\input.txt"))
            {
                Console.WriteLine("Происходит считывание числа.");
                try
                {
                    a = Convert.ToInt32(sr.ReadLine());
                    Console.WriteLine("Перевод '" + a + "' в шеснадцатиричную систему, проверьте файл вывода.");
                    //разбивание числа на отдельные цифры
                    fou = a % 10;
                    thi = a / 10 % 10;
                    sec = a / 100 % 10;
                    fir = a / 1000 % 10;

                        if (fir != 8 && fir != 9 && sec != 8 && sec != 9 && thi != 8 && thi != 9 && fou != 8 && fou != 9)
                        {
                        //Перевод из восмеричной системы в десятичную
                        a = Convert.ToInt32((fir * Math.Pow(8,3)) + (sec * Math.Pow(8,2)) + (thi * Math.Pow(8,1)) + fou);
                            sr.Close();
                            Console.Read();
                        }
                        else
                        {
                        //Проверка на правильность записи числа
                            Console.WriteLine("В восьмеричной системе счисления нет цифр 8,9, проверьте своё число.");
                            Console.Read();
                            a = 0;
                        }
                }
                catch 
                {
                    //Если в файле будут не только цифры, произойдет ошибка и в файл запишется "0"
                    Console.WriteLine("Упс, что-то пошло не так...");
                    Console.Read();
                    a = 0;
                }

                    while (true)
                {
                    //Перевод из десятичной в шеснадцатиричную
                    if (a > 15)
                    {
                        int b = a % 16;
                        temp += hexa[b];
                        a /= 16;
                    }
                    else
                    {
                        temp += hexa[a];
                        break;
                    }
                }

                //Разворот
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    output += temp[i];
                }

                //Запись
                using (StreamWriter sw = new StreamWriter(@"D:\output.txt"))
                {
                    sw.Write(output);
                    sw.Close();
                }
            }

        }
    }
}



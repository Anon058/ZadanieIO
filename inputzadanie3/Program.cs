using System;
using System.IO;

namespace inputzadanie3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"input.csv";
            string path2 = @"output.csv";

            using (StreamWriter writer = new StreamWriter(path2))
            using (StreamReader reader = new StreamReader(path1))
            {

                string output = "";
                var count = 0;
                string text = "Error";
                int sum = 0;
                bool error = false;
                for (int i = 0; !reader.EndOfStream; i++)
                {
                    string line = reader.ReadLine();
                    string[] value = line.Split(';');

                    for (int j = 0; j < value.Length; j++) // Цикл перебора строки
                    {
                        if (int.TryParse(value[j], out int res)) // Проверка на наличие текст
                        {
                            count++;
                            sum += res;
                        }
                        else if (value[j] == string.Empty) //Проверка на наличие пустых ячеек
                        {
                            continue;

                        }
                        else // Исход, если будет текст в ячейках
                        {
                            count++;
                            error = true;
                        }
                    }
                    if (error == true) //Запись результатов в файл, если была найден текст
                    {
                        try
                        {
                            output = $"{count};{text}";
                            writer.WriteLine(output);
                            Console.WriteLine(output);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка записи данных в файл: " + ex.Message);
                        }

                    }

                    else
                    {
                        output = $"{count};{sum}";
                        writer.WriteLine(output);
                        Console.WriteLine(output);
                    }
                    // Обновление счётчиков
                    count = 0;
                    error = false;
                    sum = 0;
                }
            }
            Console.ReadKey();
        }
    }
}

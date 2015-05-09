using PADIMapNoReduceServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMapper
{
    public class Mapper : IMapper
    {
        public IList<KeyValuePair<string, string>> Map(string fileLine)
        {
            //string path = Directory.GetCurrentDirectory();
            //Environment.CurrentDirectory = @"..\..\..\..\files\";
            IList<KeyValuePair<string, string>> words_map = new List<KeyValuePair<string, string>>();
            try
            {
                Console.WriteLine("Entrou no MAP: " + fileLine);
                //Thread.Sleep(2*1000);
                string[] reader_file;
                char[] delimiters = new Char[] { ' ', ',', '.', ':', ';', '!', '?', '\t' };
                if (File.Exists(fileLine))
                {
                    reader_file = File.ReadAllLines(fileLine);
                }
                else {
                    System.Console.WriteLine("2-Ficheiro não existe: " + fileLine);
                    return null;
                }

                reader_file = File.ReadAllLines(fileLine);
                int number_lines = reader_file.Length;
                Hashtable hash_map_words = new Hashtable();

                foreach (string line in reader_file)
                {
                    string[] words = line.Split(delimiters);
                    foreach (string word in words)
                    {
                        if (hash_map_words.ContainsKey(word))
                        {
                            hash_map_words[word] = (int)hash_map_words[word] + 1;
                        }
                        else
                        {
                            hash_map_words[word] = 1;
                        }
                    }
                }
                foreach (DictionaryEntry pair in hash_map_words)
                {
                    words_map.Add(new KeyValuePair<string, string>(Convert.ToString(pair.Key), Convert.ToString(pair.Value)));
                }
                System.Console.WriteLine(fileLine + " - Finish mapping: " + words_map.Count);

            }
            catch (Exception e)
            {
                Console.WriteLine("LibMapper-Exception Message: {0}", e.Message);
                Console.WriteLine("LibMapper-Exception Trace: {0}", e.ToString());
                return null;
            }
            //Environment.CurrentDirectory = path;
            return words_map;
        }
    }
}


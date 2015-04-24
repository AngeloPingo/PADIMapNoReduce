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
        public IList<KeyValuePair<string, string>> Map(string splited_file_path)
        {
            System.Console.WriteLine("IList: " + splited_file_path);
            IList<KeyValuePair<string, string>> words_map = new List<KeyValuePair<string, string>>();
            string[] reader_file = File.ReadAllLines(splited_file_path);
            char[] delimiters = new Char[] { ' ', ',', '.', ':', ';', '!', '?', '\t' };
            int number_lines = reader_file.Length;
            System.Console.WriteLine("number_lines: " + number_lines);
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
            System.Console.WriteLine(words_map.Count);
            Thread.Sleep(10000);
            return words_map;
        }
    }
}


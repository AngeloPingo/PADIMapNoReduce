using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using PADIMapNoReduceServices;
using System.IO;
using System.Collections;

namespace Worker
{
    public class Worker
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            init(args);
            connectPuppetMaster(args[0], args[1], args[2]);
        }

        private static void connectPuppetMaster(string id, string puppet_master_url, string worker_url)
        {
            System.Console.WriteLine("Enter: void connectPuppetMaster(string id, string puppet_master_url, string worker_url)");
            int id_worker = Convert.ToInt32(id);
            IPuppetMaster newPuppetMaster =
                (IPuppetMaster)Activator.GetObject(
                       typeof(IPuppetMaster), puppet_master_url);
            System.Console.WriteLine("connectPuppetMaster!");

            try
            {
                newPuppetMaster.RegisterWorker(id_worker, worker_url);
                System.Console.WriteLine("Connect and registerd in PuppetMaster!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Fail! " + e.Message);
            }

            
            System.Console.ReadLine();
        }

        private static void init(string[] args)
        {
            System.Console.WriteLine("Enter: void init(string[] args)");
            int id = Convert.ToInt32(args[0]);
            String puppet_master_url = args[1];
            String service_url = args[2];
            if (args.Length == 4)
            {
                String entry_url = args[3];
            }            

            char[] delimiter = { '/', ':' };
            String[] url_splited = service_url.Split(delimiter);
            int port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(WorkerServices), service,
                WellKnownObjectMode.Singleton);
            System.Console.WriteLine("Service URL: " + service_url);
            System.Console.WriteLine("Connnected in port: " + port);
            System.Console.WriteLine("Service: " + service);
            System.Console.WriteLine("Press <enter> to terminate chat server...");
        }
    }

    class WorkerServices : MarshalByRefObject, IWorker, IMapper
    {
        List<IPuppetMaster> clients;

        WorkerServices()
        {
            clients = new List<IPuppetMaster>();

        }

        public IList<KeyValuePair<string, string>> DoJob(string splited_file_path) 
        {
            return Map(splited_file_path);
        }


        public void SlowW(int secs)
        {
            throw new NotImplementedException();
        }

        public void FreezeW()
        {
            throw new NotImplementedException();
        }

        public void UnFreezeW()
        {
            throw new NotImplementedException();
        }

        public void FreezeC()
        {
            throw new NotImplementedException();
        }

        public void UnFreezeC()
        {
            throw new NotImplementedException();
        }

        public IList<KeyValuePair<string, string>> Map(string splited_file_path)
        {
            System.Console.WriteLine("IList: " + splited_file_path);
            IList<KeyValuePair<string, string>> words_map = new List<KeyValuePair<string, string>>();
            string[] reader_file = File.ReadAllLines(splited_file_path);
            char[] delimiters = new Char [] {' ', ',', '.', ':', ';', '!', '?', '\t'};
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
                    
                    words_map.Add(new KeyValuePair<string, string>( Convert.ToString(pair.Key), Convert.ToString(pair.Value) ));
                }

            return words_map;
        }
    }
}

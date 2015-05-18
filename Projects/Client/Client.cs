using PADIMapNoReduceServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{
    public class Client 
    {

        public delegate IList<KeyValuePair<string, string>> RemoteAsyncDelegate(byte[] code, string className, string path_file_splited);
        public static Hashtable files_splited = new Hashtable();
        public static List<IList<KeyValuePair<string, string>>> words_mapped;
        //public static Hashtable workers_url;
        //public static List<IWorker> workers = new List<IWorker>();
        private static IWorker newIWorker;
        private static IJobTracker jobTracker;
        //static string path_files = Path.Combine(@"..\..\..\..\files\");
        static string path_files = Path.Combine(@"D:\Code\PADIMapNoReduce\files\");
        static string path_dlls = Path.Combine(@"..\..\..\..\dlls\");
        private static string client_name = "C";
        private static string url_tcp = "tcp://localhost:";
        private static string client_service;
        private static string output_path;

        public static void OurRemoteAsyncCallBack(IAsyncResult ar)
        {
            RemoteAsyncDelegate del = (RemoteAsyncDelegate)((AsyncResult)ar).AsyncDelegate;
            System.Console.WriteLine("SUCCESS: Result of the remote AsyncCallBack - " + del.EndInvoke(ar).Count);
            words_mapped.Add(del.EndInvoke(ar));
            
            //foreach (KeyValuePair<string, string> pair in del.EndInvoke(ar))
            //{
            //    System.Console.WriteLine(pair.Key + "  -  " + pair.Value);
            //}
            return;
        }

        private static Hashtable getHastable()
        {
            return files_splited;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string entry_url = args[0];
            string file = path_files + args[1];
            string output_path = path_files + args[2];
            int num_splits = Convert.ToInt32(args[3]);
            string imap_name_class = args[4];
            string dll = args[5];
            files_splited = splitFile(file, num_splits);
            init(args);
            connectIWorker(dll, imap_name_class, entry_url, num_splits);
            System.Console.ReadLine();
        }

        private static void connectIWorker(string dll, string imap_name_class, string entry_url, int num_splits)
        {
            string path = Directory.GetCurrentDirectory();
            Environment.CurrentDirectory = path_dlls;
            try
            {
                byte[] code = File.ReadAllBytes(dll);
                Console.WriteLine("Created code");
                newIWorker = (IWorker)Activator.GetObject(typeof(IWorker), entry_url);
                Console.WriteLine("Created connection to newIWorker");
                Hashtable jobTrackerUrls =newIWorker.getJobTrackerUrls();
                foreach (DictionaryEntry pair in jobTrackerUrls)
                {
                    try
                    {
                        Console.WriteLine("Trying jobTracker: " + pair.Value);
                        jobTracker = (IJobTracker)Activator.GetObject(typeof(IJobTracker), (string)pair.Value);
                        Console.WriteLine("Created connection to jobTracker");
                        jobTracker.spreadJobs(code, imap_name_class, num_splits, client_service);
                        Console.WriteLine("spreadJobs(code, {0}, Jobs={1})", imap_name_class, files_splited.Count);
                        break;
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("JT invalido, tentando novo JT: " + e.Message + "\nType: " + e.GetType());
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Client-Exception Message: {0}", e.Message);
                Console.WriteLine("Client-Exception Message: {0}", e.Source);
                Console.WriteLine("Client-Exception Trace: {0}", e.ToString());
            }
            Environment.CurrentDirectory = path;
        }

        private static void init(string[] args)
        {
            Random rnd = new Random();
            int port = 10001 + rnd.Next(19999 - 10001);
            client_service = url_tcp + port + "/" + client_name;
            String entry_url = args[0];
            String path_file = args[1];
            output_path = args[2];
            int num_splits = Convert.ToInt32(args[3]); 
            char[] delimiter = { '/', ':' };
            String[] url_splited = entry_url.Split(delimiter);
            // int port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);
            ClientServices servicos = new ClientServices(files_splited, output_path);

            RemotingServices.Marshal(servicos, client_name, typeof(ClientServices));

            System.Console.WriteLine("Entry URL: " + entry_url);
            System.Console.WriteLine("Connnected in port: " + port);
            System.Console.WriteLine("Client service: " + client_service);
            System.Console.WriteLine("Press <enter> to terminate chat server...");
        }

        public static Hashtable splitFile(String file, int num_splits_string)
        {
            Hashtable files_splited = getHastable();
            System.Console.WriteLine("Enter: splitFile({0}, {1})", file, num_splits_string);
            if (!File.Exists(file))
            {
                System.Console.WriteLine("1-Ficheiro não existe: " + file);
                return null;
            }
            string[] reader_file = File.ReadAllLines(file);
            int num_lines = reader_file.Length;
            int num_lines_by_split = num_lines / num_splits_string;

            System.Console.WriteLine();
            int j = 0;
            for (int i = 1; i <= num_splits_string; i++)
            {
                string path_file_temp = path_files + i + ".in";
                StreamWriter file_temp = new StreamWriter(path_file_temp);                
                while (j < num_lines_by_split * i || (i == num_splits_string && j < num_lines)) {
                    file_temp.WriteLine(reader_file[j++]);
                }
                file_temp.Close();
                files_splited[i] = path_file_temp;
                System.Console.WriteLine("{0}  -> Write File: {1}", i, files_splited[i]);
            }
            return files_splited;
        }


    }

    public class ClientServices : MarshalByRefObject, IClient
    {
        Hashtable files_splited = null;
        string output_path;
        static string path_files = Path.Combine(@"D:\Code\PADIMapNoReduce\files\");
        string JobsSended = "";

        public ClientServices(Hashtable files_split, string output)
        {
            this.files_splited = files_split;
            this.output_path = output;
        }

        public void SendSplitResults(IList<KeyValuePair<string, string>> result, string file_name)
        {
            string result_to_file = "";
            string path_file = path_files + "/" + output_path + "/" + file_name + ".out";
            foreach (KeyValuePair<string, string> pair in result)
            {
                result_to_file += pair.Key + " --> " + pair.Value + "\n"; 
            }
            if (Directory.Exists(path_files + "/" + output_path))
            {
                System.IO.File.WriteAllText(path_file, result_to_file);
            }
            else
            {
                System.IO.Directory.CreateDirectory(path_files + "/" + output_path);
                System.IO.File.WriteAllText(path_file, result_to_file);
            }
        }

        public string GetJobById(int job_id)
        {
            string file = (string)files_splited[job_id];
            string[] reader_file;
            string string_to_send = "";

            if (File.Exists(file))
            {
                reader_file = File.ReadAllLines(file);
            }
            else
            {
                System.Console.WriteLine("2-Ficheiro não existe: " + file);
                return null;
            }

            reader_file = File.ReadAllLines(file);
            int number_lines = reader_file.Length;
            Hashtable hash_map_words = new Hashtable();

            string_to_send = File.ReadAllText(file);
            System.Console.WriteLine("Client - Ficheiro enviado: " + file);
            return string_to_send;
        }

        public void status()
        {
            Console.WriteLine("/////////////////////  STATUS CLIENT //////////////////////////");
            Console.WriteLine("File splited in {0} pieces.", files_splited.Count);
            Console.WriteLine("Output path for results: " + output_path);
            Console.WriteLine("Jobs sended to workers: " + JobsSended);
            Console.WriteLine("//////////////////////////////////////////////////////////////");
        }

    }

}

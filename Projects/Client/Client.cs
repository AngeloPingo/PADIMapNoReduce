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
        static string path_files = Path.Combine(@"C:\Users\Carlos\Source\Repos\PADIMapNoReduce\files\");
        static string path_dlls = Path.Combine(@"..\..\..\..\dlls\");

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
            init(args);
            files_splited = splitFile(file, num_splits);
            connectIWorker(dll, imap_name_class, entry_url);
            System.Console.ReadLine();
        }

        private static void connectIWorker(string dll, string imap_name_class, string entry_url)
        {
            string path = Directory.GetCurrentDirectory();
            Environment.CurrentDirectory = path_dlls;
            string jobTracker_url;
            try
            {
                byte[] code = File.ReadAllBytes(dll);
                Console.WriteLine("Created code");
                newIWorker = (IWorker)Activator.GetObject(typeof(IWorker), entry_url);
                Console.WriteLine("Created connection to newIWorker");
                //jobTracker_url = newIWorker.getJobTrackerUrl();
                Hashtable jobTrackerUrls =newIWorker.getJobTrackerUrls();
                foreach (DictionaryEntry pair in jobTrackerUrls)
                {
                    try
                    {
                        Console.WriteLine("Trying jobTracker: " + pair.Value);
                        jobTracker = (IJobTracker)Activator.GetObject(typeof(IJobTracker), (string)pair.Value);
                        Console.WriteLine("Created connection to jobTracker");
                        jobTracker.spreadJobs(code, imap_name_class, (Hashtable)files_splited);
                        Console.WriteLine("spreadJobs(code, {0}, Jobs={1})", imap_name_class, files_splited.Count);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("JT invalido, tentando novo JT.");
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
            int port = 10001;
            String entry_url = args[0];
            String path_file = args[1];
            String output_path = args[2];
            int num_splits = Convert.ToInt32(args[3]);
            

            

            char[] delimiter = { '/', ':' };
            String[] url_splited = entry_url.Split(delimiter);
            // int port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientServices), "Clients",
                WellKnownObjectMode.Singleton);


            System.Console.WriteLine("Entry URL: " + entry_url);
            System.Console.WriteLine("Connnected in port: " + port);
            System.Console.WriteLine("Service: " + service);
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
                string path_file_temp = path_files + i + ".out";
                StreamWriter file_temp = new StreamWriter(path_file_temp);                
                while (j < num_lines_by_split * i || (i == num_splits_string && j < num_lines)) {
                    file_temp.WriteLine(reader_file[j++]);
                }
                file_temp.Close();
                files_splited[i] = path_file_temp;
                System.Console.WriteLine("Write File: " + files_splited[i]);
            }
            return files_splited;
        }


    }

    class ClientServices : MarshalByRefObject, IClient, IMapper
    {
        List<string> messages;

        ClientServices()
        {
            messages = new List<string>();
        }     

        public void SendResults(string result)
        {
            throw new NotImplementedException();
        }

        public IList<KeyValuePair<string, string>> Map(string splited_file_path)
        {
            return null;
        }
    }

}

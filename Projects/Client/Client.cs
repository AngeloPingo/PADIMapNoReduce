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

        public delegate IList<KeyValuePair<string, string>> RemoteAsyncDelegate(string path_file_splited);
        public static Hashtable files_splited = new Hashtable();
        public static List<IList<KeyValuePair<string, string>>> words_mapped;
        public static Hashtable workers_url;
        public static List<IWorker> workers = new List<IWorker>();

	  // This is the call that the AsyncCallBack delegate will reference.
        public static void OurRemoteAsyncCallBack(IAsyncResult ar)
        {
            // Alternative 2: Use the callback to get the return value
            RemoteAsyncDelegate del = (RemoteAsyncDelegate)((AsyncResult)ar).AsyncDelegate;
            //foreach (KeyValuePair<string, string> pair in del.EndInvoke(ar))
            //{
            //    System.Console.WriteLine(pair.Key + "  -  " + pair.Value);
            //}
            //System.Console.ReadLine();
            words_mapped.Add(del.EndInvoke(ar));
            Console.WriteLine("\r\n**SUCCESS**: Result of the remote AsyncCallBack: ");

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
            init(args);
            files_splited = splitFile(args[1], args[3], args[2]);
            connectPuppetMaster();
            connectIWorker(args[0]);
         
        }

        private static void connectIWorker(string worker_url_lllll)
        {
            foreach (DictionaryEntry worker in workers_url)
            {
                System.Console.WriteLine((int)worker.Key + " connectIWorker: " + worker.Value);
                IWorker newIWorker =
                    (IWorker)Activator.GetObject(
                           typeof(IWorker), (string)worker.Value);
                workers.Add(newIWorker);
            }
            System.Console.WriteLine("connectPuppetMaster!");

            int num_jobs = files_splited.Count;
            int num_workers = workers.Count;
            System.Console.WriteLine("Num workers: " + num_workers);
            System.Console.WriteLine("num_jobs: " + num_jobs);
            
            
            for (int i = 0; i < num_jobs; i++)
            {
                int index = ((i + num_workers) % num_workers);
                //System.Console.WriteLine("Index: " + index);
                IWorker current_worker = workers[index];
                RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(current_worker.DoJob);
                AsyncCallback RemoteCallback = new AsyncCallback(Client.OurRemoteAsyncCallBack);
                IAsyncResult RemAr = RemoteDel.BeginInvoke(@"..\..\..\..\files\"+(i+1)+".out",
                    RemoteCallback, null);
            }
            System.Console.WriteLine("Task finished!");

            System.Console.ReadLine();
        }

        private static void connectPuppetMaster()
        {
            System.Console.WriteLine("Enter: void connectPuppetMaster(string id, string puppet_master_url, string worker_url)");
            string puppet_master_url = "tcp://localhost:8080/PuppetMaster";
            IPuppetMaster newPuppetMaster =
                (IPuppetMaster)Activator.GetObject(
                       typeof(IPuppetMaster), puppet_master_url);
            System.Console.WriteLine("connectPuppetMaster!");

            try
            {
                workers_url = newPuppetMaster.getWorkers();
                System.Console.WriteLine("List workers recived!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Fail! " + e.Message);
            }

        }

        private static void init(string[] args)
        {

            String entry_url = args[0];
            String path_file = args[1];
            String output_path = args[2];
            int num_splits = Convert.ToInt32(args[3]);
            String imap_name_class = args[4];

            

            char[] delimiter = { '/', ':' };
            String[] url_splited = entry_url.Split(delimiter);
            // int port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            TcpChannel channel = new TcpChannel(9090);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientServices), "Clients",
                WellKnownObjectMode.Singleton);


            System.Console.WriteLine("Entry URL: " + entry_url);
            System.Console.WriteLine("Connnected in port: " + 9090);
            System.Console.WriteLine("Service: " + service);
            System.Console.WriteLine("Press <enter> to terminate chat server...");
        }

        public static Hashtable splitFile(String path_file, String num_splits_string, String output)
        {
            int num_splits = Convert.ToInt32(num_splits_string);
            Hashtable files_splited = getHastable();
            System.Console.WriteLine("Enter: splitFile(String path_file, int num_splits)");
            string[] reader_file = File.ReadAllLines(path_file);
            int num_lines = reader_file.Length;
            int num_lines_by_split = num_lines / num_splits;

            System.Console.WriteLine();
            int j = 0;
            for (int i = 1; i <= num_splits; i++)
            {
                string path_file_temp = output + i + ".out";
                StreamWriter file_temp = new StreamWriter(path_file_temp);                
                while (j < num_lines_by_split * i || (i == num_splits && j < num_lines)) {
                    file_temp.WriteLine(reader_file[j++]);
                }
                file_temp.Close();
                files_splited[i] = i + ".out";
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

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
using System.Reflection;

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
            JobTracker jobTracker = new JobTracker();
            Thread workerThread = new Thread(jobTracker.run);

            string id = args[0];
            string puppet_master_url = args[1];
            string worker_url = args[2];

            init(args);
            connectPuppetMaster(id, puppet_master_url, worker_url);
            //channel.StopListening(null);
            //System.Console.WriteLine("channel.StopListening");
            ////RemotingServices.Disconnect(this);
            ////ChannelServices.UnregisterChannel(channel);
            //System.Console.ReadLine();
            //channel.StartListening(null);
            //System.Console.WriteLine("channel.StartListening");
            //System.Console.ReadLine();
        }

        private static void connectPuppetMaster(string id, string puppet_master_url, string worker_url)
        {
            System.Console.WriteLine("Enter: void connectPuppetMaster");
            int id_worker = Convert.ToInt32(id);
            IPuppetMaster newPuppetMaster =
                (IPuppetMaster)Activator.GetObject(
                       typeof(IPuppetMaster), puppet_master_url);

            if (newPuppetMaster == null)
            {
                System.Console.WriteLine("newPuppetMaster == null!");
            }

            System.Console.WriteLine("connectPuppetMaster!");
            System.Console.WriteLine("id: {0}, puppet_master_url: {1}, worker_url: {2}", id, puppet_master_url, worker_url);

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

        public static void printHere(string msg)
        {
            System.Console.WriteLine("printHere: " + msg);
        }
    }

    class WorkerServices : MarshalByRefObject, IWorker
    {
        List<IPuppetMaster> clients;
        Boolean freeze = false;
        object ClassMap;

        WorkerServices()
        {
            clients = new List<IPuppetMaster>();
        }

        public IList<KeyValuePair<string, string>> SendMapper(byte[] code, string className, string splited_file_path)
        {
            //System.Console.WriteLine("### Enter in SendMapper(code, className, splited_file_path) ###");
            //System.Console.WriteLine("code: " + code);
            //System.Console.WriteLine("className: " + className);
            //System.Console.WriteLine("splited_file_path: " + splited_file_path);
            //if (!freeze)
            //{
                Assembly assembly = Assembly.Load(code);
                
                // Walk through each type in the assembly looking for our class
                foreach (Type type in assembly.GetTypes())
                {
                    //System.Console.WriteLine("### $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ ###");
                    if (type.IsClass == true)
                    {
                        if (type.FullName.EndsWith("." + className))
                        {
                            ClassMap = Activator.CreateInstance(type);

                            object[] args = new object[] { splited_file_path };
                            //System.Console.WriteLine("MAP!! - " + splited_file_path);
                            object resultObject = type.InvokeMember("Map",
                              BindingFlags.Default | BindingFlags.InvokeMethod,
                                   null,
                                   ClassMap,
                                   args);
                            IList<KeyValuePair<string, string>> result = (IList<KeyValuePair<string, string>>)resultObject;
                            //Console.WriteLine("Map call result was: ");
                            //foreach (KeyValuePair<string, string> p in result)
                            //{
                            //    Console.WriteLine("key: " + p.Key + ", value: " + p.Value);
                            //}
                            return result;
                        }
                    }
                }
                throw (new System.Exception("could not invoke method"));
            //}
        }


        public void SlowW(int secs)
        {
            throw new NotImplementedException();
        }

        public void FreezeW()
        {
            if (freeze == true) {
                System.Console.WriteLine("Ja esta freeze!");
            }
            else
            {
                freeze = true;
                System.Console.WriteLine("Freeze!");
            }            
        }

        public void UnFreezeW()
        {
            if (freeze == false)
            {
                System.Console.WriteLine("Ja NAO esta freeze!");
            }
            else
            {
                freeze = false;
                System.Console.WriteLine("NOT Freeze!");
            } 
        }

        public void FreezeC()
        {
            throw new NotImplementedException();
        }

        public void UnFreezeC()
        {
            throw new NotImplementedException();
        }

    }
    
}

public class JobTracker
{
    public static Hashtable workers_url;
    public static List<IWorker> workers = new List<IWorker>();

    public void run()
    {
        System.Console.WriteLine("worker thread: working...");
        Console.WriteLine("worker thread: working...");
        
        while (true)
        {
            Thread.Sleep(5*1000);
            Console.WriteLine("thread: working... more 5 sec!");
        }
    }

    class JobTrackerServices : IJobTracker
    {

        public void spreadJobs(byte[] code, string imap_name_class, Hashtable files_splited)
        {
            foreach (DictionaryEntry worker in workers_url)
            {
                System.Console.WriteLine((int)worker.Key + " connectIWorker: " + worker.Value);
                IWorker newIWorker =
                    (IWorker)Activator.GetObject(
                           typeof(IWorker), (string)worker.Value);
                workers.Add(newIWorker);
            }
            System.Console.WriteLine("connectWorkers!");

            int num_jobs = files_splited.Count;
            int num_workers = workers.Count;
            System.Console.WriteLine("Num workers: " + num_workers);
            System.Console.WriteLine("num_jobs: " + num_jobs);

            // fazer ciclo que envia em bacth os splits a cada cliente apenas uma vez e envia de forma sincrona
            //try
            //{
            //    for (int i = 0; i < num_jobs; i++)
            //    {
            //        int index = ((i + num_workers) % num_workers);
            //        //System.Console.WriteLine("Index: " + index);
            //        IWorker current_worker = workers[index];
            //        RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(current_worker.SendMapper);
            //        AsyncCallback RemoteCallback = new AsyncCallback(Client.OurRemoteAsyncCallBack);
            //        System.Console.WriteLine("File send: " + files_splited[i + 1]);
            //        IAsyncResult RemAr = RemoteDel.BeginInvoke(code, imap_name_class, (String)files_splited[i + 1],
            //            RemoteCallback, null);
            //    }
            //}
            //catch (SocketException)
            //{
            //    System.Console.WriteLine("Could not locate server");
            //}
            System.Console.WriteLine("Task finished!");
        }
    }

}

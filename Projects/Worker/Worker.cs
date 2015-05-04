﻿using System;
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
        public static int my_id;
        public static string my_url;
        public static string puppet_master_url;
        public static string job_tracker_url;
        public static int port;
        public static TcpChannel chan;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool hasEntryUrl = false;
            my_id = Convert.ToInt32(args[0]);
            puppet_master_url = args[1];
            my_url = args[2];
            string entry_url = null;

            if (args.Length > 3)
            {
                entry_url = args[3];
                hasEntryUrl = true;
                connectEntryUrl(entry_url);
            }

            init(args);

            JobTracker jobTracker = new JobTracker();
            Thread workerThread = new Thread(new ThreadStart(jobTracker.run));
            workerThread.Start();
            if (workerThread.IsAlive)
            {
                System.Console.WriteLine(" --> JobTracker is alive!");
            }

            //connectPuppetMaster(id, puppet_master_url, worker_url);
            //channel.StopListening(null);
            //System.Console.WriteLine("channel.StopListening");
            ////RemotingServices.Disconnect(this);
            ////ChannelServices.UnregisterChannel(channel);
            //System.Console.ReadLine();
            //channel.StartListening(null);
            //System.Console.WriteLine("channel.StartListening");
            System.Console.ReadLine();
        }

        private static bool connectEntryUrl(string entry_url)
        {
            System.Console.WriteLine("Enter: connectEntryUrl: {0}", entry_url);

            IWorker newWorker =
                (IWorker)Activator.GetObject(
                       typeof(IWorker), entry_url);

            if (newWorker == null)
            {
                System.Console.WriteLine("newWorker == null!");
            }

            try
            {
                job_tracker_url = newWorker.getJobTrackerUrl();

                IJobTracker newJobTracker =
                (IJobTracker)Activator.GetObject(
                       typeof(IJobTracker), job_tracker_url);

                newJobTracker.registerNewWorker(my_id, my_url);

                System.Console.WriteLine("Connect and registerd in worker - " + my_url);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail! " + e.ToString());
                return false;
            }
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
            
        }

        private static void init(string[] args)
        {
            int id = Convert.ToInt32(args[0]);
            String puppet_url = args[1];
            String service_url = args[2];
            if (args.Length == 4)
            {
                String entry_url = args[3];
            }            

            char[] delimiter = { '/', ':' };
            String[] url_splited = service_url.Split(delimiter);
            port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            IDictionary RemoteChannelProperties = new Hashtable();
            RemoteChannelProperties["port"] = port;
            RemoteChannelProperties["name"] = "tcpWorker";

            chan = new TcpChannel(RemoteChannelProperties, null, null);
            ChannelServices.RegisterChannel(chan, false);

            WorkerServices servicos = new WorkerServices();
            RemotingServices.Marshal(servicos, service,
                typeof(WorkerServices));

            //TcpChannel channel = new TcpChannel(port);
            //ChannelServices.RegisterChannel(channel, false);
            //RemotingConfiguration.RegisterWellKnownServiceType(
            //    typeof(WorkerServices), service,
            //    WellKnownObjectMode.Singleton);
            System.Console.WriteLine("Service URL: " + service_url);
            System.Console.WriteLine("Connnected in port: " + port);
            System.Console.WriteLine("Service: " + service);

        }

        public static void print(string msg)
        {
            System.Console.WriteLine("Worker: " + msg);
        }

    }

    public class WorkerServices : MarshalByRefObject, IWorker
    {
        //List<IPuppetMaster> clients;
        Boolean freeze = false;
        object ClassMap;
        string jobTrackerMaster;
        Hashtable jobTrackers = new Hashtable();

        public WorkerServices()
        {
            //clients = new List<IPuppetMaster>();
        }

        public bool SendMapper(byte[] code, string className, string splited_file_path)
        {
            System.Console.WriteLine("Enter in SendMapper(code, {0}, {1})", className, splited_file_path);
            //System.Console.WriteLine("code: " + code);
            //System.Console.WriteLine("className: " + className);
            //System.Console.WriteLine("splited_file_path: " + splited_file_path);
            //if (!freeze)
            //{
            try
                            {
                Assembly assembly = Assembly.Load(code);
                System.Console.WriteLine("assembly.GetTypes(): " + assembly.GetTypes().Length);
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
                            object resultObject = null;
                            
                                resultObject = type.InvokeMember("Map",
                              BindingFlags.Default | BindingFlags.InvokeMethod,
                                   null,
                                   ClassMap,
                                   args);
                            
                            IList<KeyValuePair<string, string>> result = (IList<KeyValuePair<string, string>>)resultObject;
                            // FALTA GUARDAR RESULTADO NOS FICHEIROS COM O NOME OUTPUT
                            //Console.WriteLine("Map call result was: ");
                            //foreach (KeyValuePair<string, string> p in result)
                            //{
                            //    Console.WriteLine("key: " + p.Key + ", value: " + p.Value);
                            //}
                            Console.WriteLine("Resultado do Map: " + result.Count);
                            return result != null;
                        }
                    }
                }
                            }
            catch (Exception e)
            {
                Console.WriteLine("Worker-Exception Message: {0}", e.Message);
                Console.WriteLine("Worker-Exception Message: {0}", e.Source);
                Console.WriteLine("Worker-Exception Trace: {0}", e.ToString());
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



        public void RegisterJobTracker(int id, string url_JobTracker)
        {
            jobTrackers.Add(id, url_JobTracker);
            int maxId = 0;

            foreach (DictionaryEntry pair in jobTrackers) {
                if ((int)pair.Key > maxId) {
                    maxId = (int)pair.Key;
                }
            }

            jobTrackerMaster = (string)jobTrackers[maxId];
            // Save url for send the client
        }


        public string getJobTrackerUrl()
        {
            return jobTrackerMaster;
        }
    }
    
    public class JobTracker
    {
        private static string service_job_tracker = "JobTracker";
        private static string url_tcp = "tcp://localhost:";
        private static int port_job_tracker = 5000 + Worker.port;
        private static string myURL = url_tcp + port_job_tracker + "/" + service_job_tracker;
        public static Hashtable workers = new Hashtable();
        public static Hashtable workers_url = new Hashtable();

        public void run()
        {
            Console.WriteLine("JobTracker thread: working...");
            init();

            while (!connectWorker())
            {
                Thread.Sleep(2*1000);
                Console.WriteLine("thread: working... more 5 sec!");
            }
            Console.WriteLine("Connected to worker.");
            Console.ReadLine();
        }

        private void init()
        {
            //TcpChannel chan = null;
            //chan = new TcpChannel(port_job_tracker);
            //ChannelServices.RegisterChannel(chan, false);

            //JobTrackerServices servicos = new JobTrackerServices();
            //RemotingServices.Marshal(servicos, service_job_tracker,
            //    typeof(JobTrackerServices));

            IDictionary RemoteChannelProperties = new Hashtable();
            RemoteChannelProperties["port"] = port_job_tracker;
            RemoteChannelProperties["name"] = "tcpJobTracker";

            TcpChannel chan = new TcpChannel(RemoteChannelProperties, null, null);
            ChannelServices.RegisterChannel(chan, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(JobTrackerServices), service_job_tracker,
                WellKnownObjectMode.Singleton);
            Console.WriteLine("JobTracker binding in: " + myURL);
        }

        private static bool connectWorker()
        {
            int id_worker = Worker.my_id;
            string worker_url = Worker.my_url;
            System.Console.WriteLine("Enter: connectWorker: {0} - {1}", id_worker, worker_url);

            IWorker newWorker =
                (IWorker)Activator.GetObject(
                       typeof(IWorker), worker_url);

            if (newWorker == null)
            {
                System.Console.WriteLine("newWorker == null!");
            }
            else
            {
                workers.Add(id_worker, newWorker);
                workers_url.Add(id_worker, worker_url);
            }

            try
            {
                newWorker.RegisterJobTracker(port_job_tracker, myURL);
                System.Console.WriteLine("Connect and registerd in worker - " + worker_url);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail! " + e.ToString());
                return false;
            }

        }

        public class JobTrackerServices : MarshalByRefObject, IJobTracker
        {
            public JobTrackerServices()
            {

            }

            public void spreadJobs(byte[] code, string imap_name_class, Hashtable files_splited)
            {
                System.Console.WriteLine("connectWorkers!");

                int num_jobs = files_splited.Count;
                int num_workers = workers.Count;
                Hashtable JobDistribution = new Hashtable(num_workers);
                List<int> keys = workers.Keys.Cast<int>().ToList();
                System.Console.WriteLine("Num workers: " + num_workers);
                System.Console.WriteLine("num_jobs: " + num_jobs);
                
                for (int i = 0; i < num_jobs; i++)
                {
                    int index = ((i + num_workers) % num_workers);
                    if (JobDistribution.ContainsKey(keys[index]))
                    {
                        List<string> splitsWorker = (List<string>)JobDistribution[keys[index]];
                        splitsWorker.Add((String)files_splited[i + 1]);
                        JobDistribution[keys[index]] = splitsWorker;
                    }
                    else
                    {
                        List<string> splitsWorker = new List<string>();
                        splitsWorker.Add((String)files_splited[i + 1]);
                        JobDistribution.Add(keys[index], splitsWorker);
                    }
                    //System.Console.WriteLine("Index: " + index);
                    
                }

                foreach (DictionaryEntry pair in JobDistribution)
                {
                    //Thread t5 = new Thread(sendJobToWorker((int)pair.Key, code, imap_name_class, (List<string>)pair.Value));
                    //t5.Start();
                    Console.WriteLine("Job send to {0}, with {1} splits!", (int)pair.Key, ((List<string>)pair.Value).Count);
                    if (sendJobToWorker((int)pair.Key, code, imap_name_class, (List<string>)pair.Value))
                    {
                        Console.WriteLine("Job {0} finish with success!", (int)pair.Key);
                    }
                }
                
                System.Console.WriteLine("Task finished!");
            }

            private bool sendJobToWorker(int worker_id, byte[] code, string imap_name_class, List<string> files_splited)
            {
                //int worker_id;
                //byte[] code;
                //string imap_name_class;
                //List<string> files_splited;
                bool isSucess = true;
                Console.WriteLine("worker_id: " + worker_id);

                foreach (string value_string in files_splited)
                {
                    Console.WriteLine("\t" + imap_name_class + "\t" + worker_id + " - " + value_string);
                    IWorker newWorker = (IWorker)workers[worker_id];
                    if (!(newWorker.SendMapper(code, imap_name_class, value_string)))
                    {
                        isSucess = false;
                    }
                    Console.WriteLine("isSucess: " + isSucess);
                    //Thread.Sleep(3 * 1000);
                    //break; // tirar break assim so faz o primeiro split
                }
                return isSucess;
            }

            public bool registerNewWorker(int worker_id, string worker_url)
            {
                System.Console.WriteLine("Enter: registerNewWorker: {0}", worker_url);

                IWorker newWorker =
                    (IWorker)Activator.GetObject(
                           typeof(IWorker), worker_url);

                if (newWorker == null)
                {
                    System.Console.WriteLine("newWorker == null!");
                }

                try
                {
                    workers.Add(worker_id, newWorker);
                    workers_url.Add(worker_id, worker_url);
                    System.Console.WriteLine("Connect and registerd in worker ID {0} - {1}",worker_id, worker_url);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail! " + e.ToString());
                    return false;
                }
            }
        }
    }
}


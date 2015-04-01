using PADIMapNoReduceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client 
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            init(args);
            connectPuppetMaster(args[1]);
        }

        private static void connectPuppetMaster(string puppet_master_url)
        {
            IPuppetMaster newPuppetMaster =
                (IPuppetMaster)Activator.GetObject(
                       typeof(IPuppetMaster), puppet_master_url);
            System.Console.WriteLine("connectPuppetMaster!");

            try
            {
                System.Console.WriteLine(newPuppetMaster.SubmitJob(puppet_master_url));
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail! " + e.Message);
            }


            System.Console.ReadLine();
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
            int port = Convert.ToInt32(url_splited[4]);
            String service = url_splited[5];

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientServices), service,
                WellKnownObjectMode.Singleton);


            System.Console.WriteLine("Entry URL: " + entry_url);
            System.Console.WriteLine("Connnected in port: " + port);
            System.Console.WriteLine("Service: " + service);
            System.Console.WriteLine("Press <enter> to terminate chat server...");
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

        public IList<KeyValuePair<string, string>> Map(string fileLine)
        {
            throw new NotImplementedException();
        }
    }

}

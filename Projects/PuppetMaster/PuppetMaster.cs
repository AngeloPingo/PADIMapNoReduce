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

namespace PuppetMaster
{
    public class PuppetMaster
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(PuppetMasterServices), "PuppetMaster",
                WellKnownObjectMode.Singleton);
            System.Console.WriteLine("Press <enter> to terminate chat server...");
            System.Console.ReadLine();
        }
    }

    class PuppetMasterServices : MarshalByRefObject, IPuppetMaster
    {
        List<IWorker> clients;

        PuppetMasterServices()
        {
            clients = new List<IWorker>();
        }

    }
}

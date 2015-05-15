using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using PADIMapNoReduceServices;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace PuppetMaster
{
    public partial class PuppetMaster : Form
    {
        Hashtable workers = new Hashtable();
        int port = 20001;
        string puppet_master_name = "PM";
        string worker_name = "/W";
        string url_tcp = "tcp://localhost:";
        string path_dll = @"..\..\..\\LibMapper\bin\Debug\LibMapper.dll";
        string class_mapper = "Mapper";
        string[] filelines = null;

        public delegate void RemoteAsyncDelegate();
        public delegate void RemoteAsyncDelegate2(int delay);
        public PuppetMaster()
        {
            InitializeComponent();
            
        }

        private void button_worker_Click(object sender, EventArgs e)
        {
            

        }

        private void PuppetMaster_Load(object sender, EventArgs e)
        {
            //textBox_submit_dll.Text = path_dll;
            //textBox_submit_map.Text = class_mapper;
            //textBox_worker_service_url.Text = url_tcp + "30001" + worker_name;
            //textBox_worker_puppet_url.Text = url_tcp + port + "/" + puppet_master_name;
            //textBox_worker_id.Text = Convert.ToString(count_worker);
            //string path_files = Path.Combine(@"..\..\..\..\files\");
            //textBox_submit_file.Text = path_files + "doc.txt";
            //textBox_submit_output.Text = path_files;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            
            TcpChannel chan = null;
            chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);

            PuppetMasterServices servicos = new PuppetMasterServices();
            RemotingServices.Marshal(servicos, puppet_master_name,
                typeof(PuppetMasterServices));
            label_connect.Text = "Connected";
            button_connect.Enabled = false;
            workers = servicos.getWorkers();
            System.Console.WriteLine("Port PuppetMaster: " + port);
            
        }

        private void button_submit_Click(object sender, EventArgs e)
        {       
            
            
        }

        private void comboBox_submit_entery_url_click(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = workers;
            comboBox_submit_entery_url.DataSource = bindingSource;
            comboBox_submit_entery_url.DisplayMember = "Value";
        }

        private void comboBox_worker_freeze_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = workers;
            comboBox_worker_freeze.DataSource = bindingSource;
            comboBox_worker_freeze.DisplayMember = "Key";
        }

        private void button_freeze_worker_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox_worker_freeze.Text);
            string worker_url = Convert.ToString(workers[id]);

            System.Console.WriteLine(id + " connectIWorker: " + worker_url);
                IWorker newIWorker =
                    (IWorker)Activator.GetObject(
                           typeof(IWorker), worker_url);

            System.Console.WriteLine("connectWorker!");

            //Remote
            RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(newIWorker.FreezeW);
            //AsyncCallback RemoteCallback = new AsyncCallback(PuppetMaster.OurRemoteAsyncCallBack);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(null, null);
            
            System.Console.WriteLine("Task finished!");

            System.Console.ReadLine();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files With Script|*.txt";
            openFileDialog1.Title = "Select a File to load a Script";
            openFileDialog1.InitialDirectory = @"D:\Code\PADIMapNoReduce\files";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // this.Cursor = new Cursor(openFileDialog1.OpenFile());
                
                progressBar_script.Minimum = 0;
                progressBar_script.Value = 0;
                string filename = openFileDialog1.FileName;

                label_file_script.Text = filename;

                filelines = File.ReadAllLines(filename);

                textBox_script.Text = "";
                for (int i = 0; i < filelines.Length; i++)
                {
                    if (i == 0) {
                        textBox_script.Text += filelines[i];
                    }
                    else
                    {
                        textBox_script.Text += "\r\n" + filelines[i];
                    }
                    
                }
                
            }
        }

        private String[] readFromTextBox()
        {
            string[] stringSeparators = new string[] { "\r\n" };
            return textBox_script.Text.Split(stringSeparators, StringSplitOptions.None);
        }

        private void writeToTextBox()
        {
            textBox_script.Text = "";
            for (int i = 0; i < filelines.Length; i++)
            {
                if (i == 0)
                {
                    textBox_script.Text += filelines[i];
                }
                else
                {
                    textBox_script.Text += "\r\n" + filelines[i];
                }

            }
        }

        private void readFileAndProcess(String line)
        {
            char[] delimiterChars = {' '};
            String[] lineSplitted = line.Split(delimiterChars);
            String[] args;
            //System.Console.WriteLine("SIZE Args: " + lineSplitted.Length);
            //System.Console.WriteLine("lineSplitted: ");
            //printArgs(lineSplitted);
            switch (lineSplitted[0])
            {
                case "WORKER":
                    //System.Console.WriteLine("Enter command: WORKER-" + lineSplitted.Length);
                    if (lineSplitted.Length == 5 || lineSplitted.Length == 6)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchWorker(args);
                    }
                    break;
                case "SUBMIT":
                    //System.Console.WriteLine("Enter command: SUBMIT-" + lineSplitted.Length);
                    if (lineSplitted.Length == 7)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchClient(args);
                    }
                    break;
                case "WAIT":
                    //System.Console.WriteLine("Enter command: WAIT-" + lineSplitted.Length);
                    if (lineSplitted.Length == 2)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchWait(args);
                    }
                    break;
                case "STATUS":
                    //System.Console.WriteLine("Enter command: STATUS-" + lineSplitted.Length);
                    if (lineSplitted.Length == 1)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        //launchStatus();
                    }
                    break;
                case "SLOWW":
                    //System.Console.WriteLine("Enter command: SLOWW-" + lineSplitted.Length);
                    if (lineSplitted.Length == 4)
                    {
                        printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchSloww(args);
                    }
                    break;
                case "FREEZEW":
                    //System.Console.WriteLine("Enter command: FREEZEW-" + lineSplitted.Length);
                    if (lineSplitted.Length == 2)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchFreezew(args);
                    }
                    break;
                case "UNFREEZEW":
                    //System.Console.WriteLine("Enter command: UNFREEZEW-" + lineSplitted.Length);
                    if (lineSplitted.Length == 2)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchUnfreezew(args);
                    }
                    break;
                case "FREEZEC":
                    //System.Console.WriteLine("Enter command: FREEZEC-" + lineSplitted.Length);
                    if (lineSplitted.Length == 2)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchFreezec(args);
                    }
                    break;
                case "UNFREEZEC":
                    //System.Console.WriteLine("Enter command: UNFREEZEC-" + lineSplitted.Length);
                    if (lineSplitted.Length == 2)
                    {
                        //printArgs(lineSplitted);
                        args = removeFirst(lineSplitted);
                        launchUnfreezec(args);
                    }
                    break;
                default:
                    System.Console.WriteLine("Command doesn't not exist! -> " + lineSplitted[0]);
                    return;
            }
        }

        private void launchUnfreezec(string[] args)
        {
            int id_Worker = Convert.ToInt32(args[0]);
            string worker_url = (string)workers[id_Worker];
            char[] delimiterChars = { ':', '/' };
            String[] lineSplitted = worker_url.Split(delimiterChars);
            string service_job_tracker = "JobTracker";
            string url_tcp = "tcp://localhost:";
            int port_job_tracker = 5000 + Convert.ToInt32(lineSplitted[1]);
            string job_url = url_tcp + port_job_tracker + "/" + service_job_tracker;

            IJobTracker newIJobTracker =
                (IJobTracker)Activator.GetObject(
                       typeof(IJobTracker), job_url);

            RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(newIJobTracker.UnFreezeC);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(null, null);
        }

        private void launchFreezec(string[] args)
        {
            int id_Worker = Convert.ToInt32(args[0]);
            string worker_url = (string)workers[id_Worker];
            char[] delimiterChars = { ':', '/' };
            String[] lineSplitted = worker_url.Split(delimiterChars);
            string service_job_tracker = "JobTracker";
            string url_tcp = "tcp://localhost:";
            int port_job_tracker = 5000 + Convert.ToInt32(lineSplitted[1]);
            string job_url = url_tcp + port_job_tracker + "/" + service_job_tracker;

            IJobTracker newIJobTracker =
                (IJobTracker)Activator.GetObject(
                       typeof(IJobTracker), job_url);

            RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(newIJobTracker.FreezeC);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(null, null);
        }

        private void launchUnfreezew(string[] args)
        {
            int id_Worker = Convert.ToInt32(args[0]);
            string worker_url = (string)workers[id_Worker];
            IWorker newIWorker =
                (IWorker)Activator.GetObject(
                       typeof(IWorker), worker_url);

            RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(newIWorker.UnFreezeW);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(null, null);
        }

        private void launchFreezew(string[] args)
        {
            int id_Worker = Convert.ToInt32(args[0]);
            string worker_url = (string)workers[id_Worker];
            IWorker newIWorker =
                (IWorker)Activator.GetObject(
                       typeof(IWorker), worker_url);

            RemoteAsyncDelegate RemoteDel = new RemoteAsyncDelegate(newIWorker.FreezeW);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(null, null);
        }

        private void launchSloww(string[] args)
        {
            int id_Worker = Convert.ToInt32(args[0]);
            string worker_url = (string)workers[id_Worker];
            System.Console.WriteLine("OLA"+worker_url);
            int delay = Convert.ToInt32(args[1]);

            IWorker newIWorker =
                (IWorker)Activator.GetObject(
                       typeof(IWorker), worker_url);

            RemoteAsyncDelegate2 RemoteDel = new RemoteAsyncDelegate2(newIWorker.SlowW);
            IAsyncResult RemAr = RemoteDel.BeginInvoke(delay, null, null);
        }

        private void launchStatus()
        {
            throw new NotImplementedException();
        }

        private void launchWait(string[] args)
        {
            int segundos = Convert.ToInt32(args[0]);
            label_run_status_display.Text = "PuppetMaster STOPS " + segundos + " sec´s --";
            System.Threading.Thread.Sleep(segundos * 1000);
        }

        private void launchClient(string[] args)
        {
            string entery_url = args[0];
            string file = args[1];
            string output = args[2];
            string num_splits = args[3];
            string map = args[4];
            string dll = args[5];
            String[] parametros = new String[] {entery_url, file, output, num_splits, map, dll};
            try
            {
                string path_files = Path.Combine(@"..\..\..\Client\bin\Debug\");
                System.Diagnostics.Process.Start(path_files + "Client.exe", String.Join(" ", parametros));
            }
            catch (IOException msg)
            {
                if (msg.Source != null)
                    Console.WriteLine("IOException source: {0}", msg.Source);
                throw;
            }
        }

        private void launchWorker(string[] args)
        {
            Random rnd = new Random();
            int port_random = rnd.Next(30001, 39999);
            string id = args[0];
            string puppet_url = args[1];
            string service_url = args[2];
            string entry_url = args[3];
            String[] parametros = new String[] { id, puppet_url, service_url, entry_url };
            workers[Convert.ToInt32(id)] = service_url;
            System.Console.WriteLine("Estamos aqui" + id + "service" + workers[Convert.ToInt32(id)]);

            try
            {
                string path_files = Path.Combine(@"..\..\..\Worker\bin\Debug\");
                System.Diagnostics.Process.Start(path_files + "Worker.exe", String.Join(" ", parametros));
            }
            catch (IOException msg)
            {
                if (msg.Source != null)
                    Console.WriteLine("IOException source: {0}", msg.Source);
                throw;
            }            
        }

        private String[] removeFirst(String[] arrayString)
        {
            String[] result = new String[arrayString.Length - 1];
            for (int i = 1; i < arrayString.Length; i++)
                {
                    result[i - 1] = arrayString[i];
                }
            return result;
        }

        private void printArgs(String[] arrayArgs)
        {
            for (int i = 1; i < arrayArgs.Length; i++)
                {
                    System.Console.WriteLine("printArgs: " + arrayArgs[i]);
                }
        }

        private void button_run_script_all_Click(object sender, EventArgs e)
        {
            filelines = readFromTextBox();
            if (filelines != null && filelines.Length > 0)
            {
                progressBar_script.Minimum = 0;
                progressBar_script.Maximum = filelines.Length - 1;
                for (int i = 0; i < filelines.Length; i++)
                {
                    if (filelines[i].Length > 0)
                    {
                        readFileAndProcess(filelines[i]);
                        filelines[i] = "";
                        progressBar_script.Value = i + 1;
                    }                    
                }
                label_run_status_display.Text = "File processed!";
            }
            else
            {
                label_file_script.Text = "Please select a script file";
                progressBar_script.Value = 0;
            }
            writeToTextBox();
        }

        private void button_run_script_step_Click(object sender, EventArgs e)
        {
            filelines = readFromTextBox();
            if (filelines != null && filelines.Length > 0)
            {
                bool isFinish = true;
                progressBar_script.Minimum = 0;
                progressBar_script.Maximum = filelines.Length;
                for (int i = 0; i < filelines.Length; i++)
                {
                    if (filelines[i].Length > 0)
                    {
                        readFileAndProcess(filelines[i]);
                        label_run_status_display.Text = filelines[i];
                        filelines[i] = "";
                        progressBar_script.Value = i + 1;
                        isFinish = false;
                        writeToTextBox();
                        return;
                    }
                }
                if (isFinish)
                {
                    label_run_status_display.Text = "File processed!";
                }
            }
            else
            {
                label_file_script.Text = "Please select a script file";
                progressBar_script.Value = 0;
            }
        }


    }

    public class PuppetMasterServices : MarshalByRefObject, IPuppetMaster
    {
        public static PuppetMaster form;
        //static public Hashtable workers = new Hashtable();

        public PuppetMasterServices()
        {
        }

        public Hashtable getWorkers()
        {
            return null;
            //throw new NotImplementedException();
            //  return workers;
        }

        public void RegisterWorker(int id_worker, string worker_url)
        {
            
            //throw new NotImplementedException();
            //workers[id_worker] = worker_url;
            //System.Console.WriteLine("Service URL: ");

        }
        public void RegisterClient(string NewClientPort) {
            System.Console.WriteLine("Service URL: ");
        }
        public string SubmitJob(string result)
        {
            return "Ola ocnosucnso" + result;
        }
        public string JobResult(string result)
        {
            return "Ola ccxcxzcxc" + result;
        }

    }
}

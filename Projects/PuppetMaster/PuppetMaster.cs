﻿using System;
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

namespace PuppetMaster
{
    public partial class PuppetMaster : Form
    {
        Hashtable workers;
        int count_worker = 0;
        public PuppetMaster()
        {
            InitializeComponent();
            
        }

        private void button_worker_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int port_random = rnd.Next(1024, 65000);
            textBox_worker_service_url.Text = "tcp://localhost:" + port_random + "/Worker";
            textBox_worker_id.Text = Convert.ToString(++count_worker);
            String[] parametros = new String[]{textBox_worker_id.Text, textBox_worker_puppet_url.Text, textBox_worker_service_url.Text, textBox_worker_entry_url.Text};
            try {
                System.Diagnostics.Process.Start(@"D:\Code\PADIMapNoReduce\Projects\Worker\bin\Debug\Worker.exe", String.Join(" ", parametros));
            }
            catch (IOException msg)
            {
                if (msg.Source != null)
                    Console.WriteLine("IOException source: {0}", msg.Source);
                throw;
            }



        }

        private void PuppetMaster_Load(object sender, EventArgs e)
        {
            textBox_worker_service_url.Text = "tcp://localhost:1111/Worker";
            textBox_worker_puppet_url.Text = "tcp://localhost:8080/PuppetMaster";
            textBox_worker_id.Text = Convert.ToString(count_worker);
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            int port = 8080;
            TcpChannel chan = null;
            chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);

            PuppetMasterServices servicos = new PuppetMasterServices();
            RemotingServices.Marshal(servicos, "PuppetMaster",
                typeof(PuppetMasterServices));
            label_connect.Text = "Connected";
            button_connect.Enabled = false;
            workers = servicos.getWorkers();


            
            
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            
            String[] parametros = new String[] { comboBox_submit_entery_url.Text, textBox_submit_file.Text, textBox_submit_output.Text, textBox_submit_num_splits.Text, textBox_submit_map.Text };
            try
            {
                System.Diagnostics.Process.Start(@"D:\Code\PADIMapNoReduce\Projects\Client\bin\Debug\Client.exe", String.Join(" ", parametros));
            }
            catch (IOException msg)
            {
                if (msg.Source != null)
                    Console.WriteLine("IOException source: {0}", msg.Source);
                throw;
            }
        }

        private void comboBox_submit_entery_url_click(object sender, EventArgs e)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = workers;
            comboBox_submit_entery_url.DataSource = bindingSource;
            comboBox_submit_entery_url.DisplayMember = "Value";
        }

    }

    public class PuppetMasterServices : MarshalByRefObject, IPuppetMaster
    {
        public static PuppetMaster form;
        static public Hashtable workers = new Hashtable();

        public PuppetMasterServices()
        {
        }

        public Hashtable getWorkers()
        {
            return workers;
        }

        public void RegisterWorker(int id_worker, string worker_url)
        {
            workers[id_worker] = worker_url;
            System.Console.WriteLine("Service URL: ");

        }
        public void RegisterClient(string NewClientPort) {
            System.Console.WriteLine("Service URL: ");
        }
        public string SubmitJob(string textFile)
        {
            return "Ola ocnosucnso" + textFile;
        }
        public string JodResult(string result)
        {
            return "Ola ccxcxzcxc" + result;
        }

    }
}

namespace PuppetMaster
{
    partial class PuppetMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_connect = new System.Windows.Forms.Button();
            this.label_connect = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_worker_freeze = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_submit_num_splits = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_puppetmaster_url = new System.Windows.Forms.Label();
            this.textBox_worker_entry_url = new System.Windows.Forms.TextBox();
            this.textBox_worker_service_url = new System.Windows.Forms.TextBox();
            this.textBox_worker_puppet_url = new System.Windows.Forms.TextBox();
            this.textBox_worker_id = new System.Windows.Forms.TextBox();
            this.button_worker = new System.Windows.Forms.Button();
            this.button_submit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button_freeze_worker = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_submit_file = new System.Windows.Forms.TextBox();
            this.textBox_submit_output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_submit_map = new System.Windows.Forms.TextBox();
            this.comboBox_submit_entery_url = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_submit_dll = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(51, 38);
            this.button_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_connect
            // 
            this.label_connect.AutoSize = true;
            this.label_connect.Location = new System.Drawing.Point(132, 43);
            this.label_connect.Name = "label_connect";
            this.label_connect.Size = new System.Drawing.Size(102, 17);
            this.label_connect.TabIndex = 1;
            this.label_connect.Text = "Not Connected";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox_worker_freeze, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_submit_num_splits, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_puppetmaster_url, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_worker_entry_url, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_worker_service_url, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_worker_puppet_url, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_worker_id, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_worker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_submit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_freeze_worker, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label_id, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_submit_file, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_submit_output, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_submit_map, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_submit_entery_url, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 11, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_submit_dll, 12, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 122);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1750, 297);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // comboBox_worker_freeze
            // 
            this.comboBox_worker_freeze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_worker_freeze.FormattingEnabled = true;
            this.comboBox_worker_freeze.Location = new System.Drawing.Point(178, 167);
            this.comboBox_worker_freeze.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_worker_freeze.Name = "comboBox_worker_freeze";
            this.comboBox_worker_freeze.Size = new System.Drawing.Size(194, 24);
            this.comboBox_worker_freeze.TabIndex = 35;
            this.comboBox_worker_freeze.Click += new System.EventHandler(this.comboBox_worker_freeze_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "ID:";
            // 
            // textBox_submit_num_splits
            // 
            this.textBox_submit_num_splits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_submit_num_splits.Location = new System.Drawing.Point(1003, 35);
            this.textBox_submit_num_splits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_submit_num_splits.Mask = "00000";
            this.textBox_submit_num_splits.Name = "textBox_submit_num_splits";
            this.textBox_submit_num_splits.Size = new System.Drawing.Size(194, 22);
            this.textBox_submit_num_splits.TabIndex = 3;
            this.textBox_submit_num_splits.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(931, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Entry-url:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 33);
            this.label3.TabIndex = 20;
            this.label3.Text = "Service-URL:";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label_puppetmaster_url
            // 
            this.label_puppetmaster_url.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_puppetmaster_url.AutoSize = true;
            this.label_puppetmaster_url.Location = new System.Drawing.Point(381, 0);
            this.label_puppetmaster_url.Name = "label_puppetmaster_url";
            this.label_puppetmaster_url.Size = new System.Drawing.Size(66, 33);
            this.label_puppetmaster_url.TabIndex = 19;
            this.label_puppetmaster_url.Text = "PuppetMaster-URL:";
            this.label_puppetmaster_url.UseCompatibleTextRendering = true;
            // 
            // textBox_worker_entry_url
            // 
            this.textBox_worker_entry_url.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_worker_entry_url.Location = new System.Drawing.Point(1003, 2);
            this.textBox_worker_entry_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_worker_entry_url.Name = "textBox_worker_entry_url";
            this.textBox_worker_entry_url.Size = new System.Drawing.Size(194, 22);
            this.textBox_worker_entry_url.TabIndex = 17;
            // 
            // textBox_worker_service_url
            // 
            this.textBox_worker_service_url.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_worker_service_url.Location = new System.Drawing.Point(728, 2);
            this.textBox_worker_service_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_worker_service_url.Name = "textBox_worker_service_url";
            this.textBox_worker_service_url.Size = new System.Drawing.Size(194, 22);
            this.textBox_worker_service_url.TabIndex = 15;
            // 
            // textBox_worker_puppet_url
            // 
            this.textBox_worker_puppet_url.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_worker_puppet_url.Location = new System.Drawing.Point(453, 2);
            this.textBox_worker_puppet_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_worker_puppet_url.Name = "textBox_worker_puppet_url";
            this.textBox_worker_puppet_url.Size = new System.Drawing.Size(194, 22);
            this.textBox_worker_puppet_url.TabIndex = 13;
            // 
            // textBox_worker_id
            // 
            this.textBox_worker_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_worker_id.Location = new System.Drawing.Point(178, 2);
            this.textBox_worker_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_worker_id.Name = "textBox_worker_id";
            this.textBox_worker_id.Size = new System.Drawing.Size(194, 22);
            this.textBox_worker_id.TabIndex = 11;
            // 
            // button_worker
            // 
            this.button_worker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_worker.Location = new System.Drawing.Point(14, 5);
            this.button_worker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_worker.Name = "button_worker";
            this.button_worker.Size = new System.Drawing.Size(91, 23);
            this.button_worker.TabIndex = 0;
            this.button_worker.Text = "Worker";
            this.button_worker.UseVisualStyleBackColor = true;
            this.button_worker.Click += new System.EventHandler(this.button_worker_Click);
            // 
            // button_submit
            // 
            this.button_submit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_submit.Location = new System.Drawing.Point(14, 38);
            this.button_submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(91, 23);
            this.button_submit.TabIndex = 1;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(14, 71);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(14, 104);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(14, 137);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button_freeze_worker
            // 
            this.button_freeze_worker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_freeze_worker.Location = new System.Drawing.Point(14, 170);
            this.button_freeze_worker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_freeze_worker.Name = "button_freeze_worker";
            this.button_freeze_worker.Size = new System.Drawing.Size(91, 23);
            this.button_freeze_worker.TabIndex = 5;
            this.button_freeze_worker.Text = "FreezeW";
            this.button_freeze_worker.UseVisualStyleBackColor = true;
            this.button_freeze_worker.Click += new System.EventHandler(this.button_freeze_worker_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Location = new System.Drawing.Point(14, 203);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.Location = new System.Drawing.Point(14, 236);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(91, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.Location = new System.Drawing.Point(12, 269);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label_id
            // 
            this.label_id.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(147, 8);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(25, 17);
            this.label_id.TabIndex = 18;
            this.label_id.Text = "ID:";
            // 
            // textBox_submit_file
            // 
            this.textBox_submit_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_submit_file.Location = new System.Drawing.Point(453, 35);
            this.textBox_submit_file.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_submit_file.Name = "textBox_submit_file";
            this.textBox_submit_file.Size = new System.Drawing.Size(194, 22);
            this.textBox_submit_file.TabIndex = 23;
            // 
            // textBox_submit_output
            // 
            this.textBox_submit_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_submit_output.Location = new System.Drawing.Point(728, 35);
            this.textBox_submit_output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_submit_output.Name = "textBox_submit_output";
            this.textBox_submit_output.Size = new System.Drawing.Size(194, 22);
            this.textBox_submit_output.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Entry URL:";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "File:";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(673, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Output:";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(941, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Nº Splits";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1238, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "MAP";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // textBox_submit_map
            // 
            this.textBox_submit_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_submit_map.Location = new System.Drawing.Point(1278, 35);
            this.textBox_submit_map.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_submit_map.Name = "textBox_submit_map";
            this.textBox_submit_map.Size = new System.Drawing.Size(194, 22);
            this.textBox_submit_map.TabIndex = 31;
            // 
            // comboBox_submit_entery_url
            // 
            this.comboBox_submit_entery_url.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_submit_entery_url.FormattingEnabled = true;
            this.comboBox_submit_entery_url.Location = new System.Drawing.Point(178, 35);
            this.comboBox_submit_entery_url.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_submit_entery_url.Name = "comboBox_submit_entery_url";
            this.comboBox_submit_entery_url.Size = new System.Drawing.Size(194, 24);
            this.comboBox_submit_entery_url.TabIndex = 32;
            this.comboBox_submit_entery_url.Click += new System.EventHandler(this.comboBox_submit_entery_url_click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1513, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "DLL";
            // 
            // textBox_submit_dll
            // 
            this.textBox_submit_dll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_submit_dll.Location = new System.Drawing.Point(1553, 36);
            this.textBox_submit_dll.Name = "textBox_submit_dll";
            this.textBox_submit_dll.Size = new System.Drawing.Size(194, 22);
            this.textBox_submit_dll.TabIndex = 37;
            // 
            // PuppetMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_connect);
            this.Controls.Add(this.button_connect);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PuppetMaster";
            this.Text = "Puppet Master";
            this.Load += new System.EventHandler(this.PuppetMaster_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_connect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_worker;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button_freeze_worker;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_puppetmaster_url;
        private System.Windows.Forms.TextBox textBox_worker_entry_url;
        private System.Windows.Forms.TextBox textBox_worker_service_url;
        private System.Windows.Forms.TextBox textBox_worker_puppet_url;
        private System.Windows.Forms.TextBox textBox_worker_id;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_submit_file;
        private System.Windows.Forms.TextBox textBox_submit_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_submit_map;
        private System.Windows.Forms.ComboBox comboBox_submit_entery_url;
        private System.Windows.Forms.MaskedTextBox textBox_submit_num_splits;
        private System.Windows.Forms.ComboBox comboBox_worker_freeze;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_submit_dll;
    }
}


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
            this.tableLayoutPanel_menu = new System.Windows.Forms.TableLayoutPanel();
            this.button_worker = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_wait = new System.Windows.Forms.Button();
            this.label_gama_localhost = new System.Windows.Forms.Label();
            this.tableLayoutPanel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(26, 24);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            // 
            // label_connect
            // 
            this.label_connect.AutoSize = true;
            this.label_connect.Location = new System.Drawing.Point(118, 30);
            this.label_connect.Name = "label_connect";
            this.label_connect.Size = new System.Drawing.Size(102, 17);
            this.label_connect.TabIndex = 1;
            this.label_connect.Text = "Not Connected";
            // 
            // tableLayoutPanel_menu
            // 
            this.tableLayoutPanel_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_menu.ColumnCount = 3;
            this.tableLayoutPanel_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel_menu.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel_menu.Controls.Add(this.button_worker, 0, 0);
            this.tableLayoutPanel_menu.Controls.Add(this.button_submit, 0, 1);
            this.tableLayoutPanel_menu.Controls.Add(this.button_wait, 0, 2);
            this.tableLayoutPanel_menu.Controls.Add(this.label_gama_localhost, 2, 0);
            this.tableLayoutPanel_menu.Location = new System.Drawing.Point(26, 82);
            this.tableLayoutPanel_menu.Name = "tableLayoutPanel_menu";
            this.tableLayoutPanel_menu.RowCount = 9;
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_menu.Size = new System.Drawing.Size(485, 500);
            this.tableLayoutPanel_menu.TabIndex = 2;
            this.tableLayoutPanel_menu.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button_worker
            // 
            this.button_worker.Location = new System.Drawing.Point(3, 3);
            this.button_worker.Name = "button_worker";
            this.button_worker.Size = new System.Drawing.Size(95, 30);
            this.button_worker.TabIndex = 0;
            this.button_worker.Text = "Worker";
            this.button_worker.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(3, 53);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(95, 30);
            this.button_submit.TabIndex = 2;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            // 
            // button_wait
            // 
            this.button_wait.Location = new System.Drawing.Point(3, 103);
            this.button_wait.Name = "button_wait";
            this.button_wait.Size = new System.Drawing.Size(95, 30);
            this.button_wait.TabIndex = 3;
            this.button_wait.Text = "Wait";
            this.button_wait.UseVisualStyleBackColor = true;
            // 
            // label_gama_localhost
            // 
            this.label_gama_localhost.AutoSize = true;
            this.label_gama_localhost.Location = new System.Drawing.Point(321, 0);
            this.label_gama_localhost.Name = "label_gama_localhost";
            this.label_gama_localhost.Size = new System.Drawing.Size(80, 17);
            this.label_gama_localhost.TabIndex = 4;
            this.label_gama_localhost.Text = "127.0.0.0/8";
            // 
            // PuppetMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 676);
            this.Controls.Add(this.tableLayoutPanel_menu);
            this.Controls.Add(this.label_connect);
            this.Controls.Add(this.button_connect);
            this.Name = "PuppetMaster";
            this.Text = "PuppetMaster";
            this.Load += new System.EventHandler(this.PuppetMaster_Load);
            this.tableLayoutPanel_menu.ResumeLayout(false);
            this.tableLayoutPanel_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_connect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_menu;
        private System.Windows.Forms.Button button_worker;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_wait;
        private System.Windows.Forms.Label label_gama_localhost;
    }
}
namespace RecursiveDirectoryHandler_RDH_
{
    partial class Form2
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

        #region
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(416, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(95, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "D:\\технологическая практика\\Work_";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(416, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(95, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(301, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "D:\\технологическая практика";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(215, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "Запуск";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 163);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(557, 199);
            this.listBox1.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(79, 114);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "WORK";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(581, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(117, 17);
            this.toolStripStatusLabel1.Text = "Папок обработанно:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel2.Text = "Папок найдено: ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(199, 17);
            this.toolStripStatusLabel3.Text = "Затраченное время на архивацию:";
            this.toolStripStatusLabel3.Visible = false;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(12, 372);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(557, 109);
            this.listBox2.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(581, 529);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recursive directory handler(RDH)";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
      
    }
}
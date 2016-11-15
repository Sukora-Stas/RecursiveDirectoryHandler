using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;


namespace RecursiveDirectoryHandler_RDH_
{
    public partial class Form2 : Form
    {
        DateTime date1 = new DateTime(0, 0);
        string div2 = "";
        FolderBrowserDialog FBD = new FolderBrowserDialog();
        FolderBrowserDialog FBD1 = new FolderBrowserDialog();
               
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
          
            this.folderBrowserDialog1.ShowNewFolderButton = false;
                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FBD.Description = "Выберете корневой каталог для обработки";
            
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FBD.SelectedPath + @"\";
            }
       
        }
        public int i = 0;
        public int n = 0;
        
        public void DirSearch(string sDir)
        {
                try
            {
                toolStripStatusLabel1.Text = "Папок обработанно: " + i;
                toolStripStatusLabel2.Text = "Папок найдено: " + n;
                statusStrip1.Refresh();
                i++;
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    listBox2.Items.Add(d);
                    listBox2.SelectedIndex = listBox2.Items.Count - 1;
                    listBox2.Refresh();
                    
                    //string dir1 = new DirectoryInfo(sDir).Name;

                    //string dir2 = new DirectoryInfo(sDir).Name; 

                    foreach (string f in Directory.GetDirectories(d, textBox3.Text))
                    {


                        DateTime dt = Directory.GetCreationTime(@sDir);
                        // MessageBox.Show("" + sDir);
                        
                        DateTime localDate = DateTime.Now;
                        int now = localDate.Year;
                        int last = localDate.Year - 1;
                        int lastlast = localDate.Year - 2;

                          
                        //пропуск действий
                        if (dt.Year == now)
                        {

                            listBox1.Items.Add("Для данного каталога действий не требуется!");
                            listBox1.Items.Add("Дата создания: " + dt);
                            listBox1.Items.Add("Путь к каталогу: ");
                            listBox1.Items.Add(sDir);
                            listBox1.Items.Add("<==========================================================================>");
                            //MessageBox.Show("delete" + f);
                            //MessageBox.Show("name" + archive_name);
                            //MessageBox.Show("directori for zip" + sDir);
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                            listBox1.Refresh();
                        }

                        //архивация
                        else if (dt.Year == last)
                        {
                            MessageBox.Show("last");
                            string div1 = new DirectoryInfo(sDir).Name;
                            MessageBox.Show("name = " + div1);


                            MessageBox.Show("go");
                            if (Directory.Exists(f))
                            {
                                MessageBox.Show("exist go");
                                listBox1.Items.Add("Данный каталог подлежит архивации и удалению для очистки места!");
                                listBox1.Items.Add(f);
                                listBox1.Items.Add("Дата создания: " + dt);
                                listBox1.Items.Add("Путь к каталогу: ");
                                listBox1.Items.Add(sDir);
                                listBox1.Items.Add("Каталог: " + textBox3.Text + "- удалён.");
                                MessageBox.Show("delete" + f);
                                Directory.Delete(f, true);
                                MessageBox.Show("delete");
                                div2 = div1;
                                MessageBox.Show("div1=" + div1);
                                MessageBox.Show("div2=" + div2);
                                DirSearch(div2);
                            }
                            else
                            {
                                MessageBox.Show("eror 1");
                            }

                            MessageBox.Show("go 2");
                            if (div1 != div2)
                            {
                                MessageBox.Show("div1=" + div1);
                                MessageBox.Show("div2=" + div2);
                                string source_folder = div2; //путь к папке для архивации
                                string archive_name = new DirectoryInfo(div2).Name; //имя архива

                                MessageBox.Show("arhiv go");
                                listBox1.Items.Add("Архивация каталога!");
                                listBox1.Items.Add("Подождите...");
                                MessageBox.Show("name" + archive_name);

                                DateTime dtb = DateTime.Now;
                                /////////////////////////
                                ZipFile zf = new ZipFile();
                                zf.AlternateEncoding = Encoding.GetEncoding("cp866");

                                zf.AddDirectory(source_folder);//Добавляем папку
                                zf.Save(@textBox2.Text + @"\" + archive_name + ".zip"); //Сохраняем архив.
                                /////////////////////////
                                DateTime dte = DateTime.Now;
                                statusStrip1.Text = ("ZipFile end " + (dte - dtb).ToString());

                                listBox1.Items.Add("Удаление каталога!");
                                MessageBox.Show("delete");
                                //Directory.Delete(sDir, true);

                                listBox1.Items.Add("Готово");
                                MessageBox.Show("repet");
                                listBox1.Items.Add("<==========================================================================>");

                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                listBox1.Refresh();
                            }



                            //if (!Directory.Exists(f))
                            //{
                            //    listBox1.Items.Add("Архивация каталога!");
                            //    listBox1.Items.Add("Подождите...");
                            //    MessageBox.Show("name" + archive_name);

                            //    DateTime dtb = DateTime.Now;
                            //    /////////////////////////
                            //    ZipFile zf = new ZipFile();
                            //    zf.AlternateEncoding = Encoding.GetEncoding("cp866");

                            //    zf.AddDirectory(source_folder);//Добавляем папку
                            //    zf.Save(@textBox2.Text + @"\" + archive_name + ".zip"); //Сохраняем архив.
                            //    /////////////////////////
                            //    DateTime dte = DateTime.Now;
                            //    statusStrip1.Text = ("ZipFile end " + (dte - dtb).ToString());

                            //    listBox1.Items.Add("Удаление каталога!");
                            //    listBox2.Refresh();
                            //    //Directory.Delete(sDir, true);
                            //    listBox2.Refresh();
                            //    listBox1.Items.Add("Готово");
                            //    MessageBox.Show("repet");
                            //    listBox1.Items.Add("<==========================================================================>");

                            //    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                            //    listBox1.Refresh();




                            //}

                            ////listBox1.Items.Add("Данный каталог подлежит архивации и удалению для очистки места!");
                            ////listBox1.Items.Add(f);
                            ////listBox1.Items.Add("Дата создания: " + dt);
                            ////listBox1.Items.Add("Путь к каталогу: ");
                            ////listBox1.Items.Add(sDir);
                            ////listBox1.Items.Add("Каталог: " + textBox3.Text + "- удалён.");
                            ////MessageBox.Show("delete" + f);
                            ////Directory.Delete(f, true);
                            ////MessageBox.Show("delete");
                            //else
                            //{

                            //    listBox1.Items.Add("Данный каталог подлежит архивации и удалению для очистки места!");
                            //    listBox1.Items.Add(f);
                            //    listBox1.Items.Add("Дата создания: " + dt);
                            //    listBox1.Items.Add("Путь к каталогу: ");
                            //    listBox1.Items.Add(sDir);
                            //    listBox1.Items.Add("Каталог: " + textBox3.Text + "- удалён.");
                            //    MessageBox.Show("delete" + f);
                            //    Directory.Delete(f, true);
                            //    MessageBox.Show("delete");
                            //}

                        }

                        //удаление
                        else if (dt.Year <= lastlast)
                        {
                            listBox1.Items.Add("Данный каталог устарел!");
                            listBox1.Items.Add("Дата создания: " + dt);
                            listBox1.Items.Add("Путь к каталогу: ");
                            listBox1.Items.Add(sDir);
                            listBox1.Items.Add("Каталог удаляется..");
                            Directory.Delete(sDir, true);
                            listBox1.Items.Add("Готово!");
                            listBox1.Items.Add("<==========================================================================>");

                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                            listBox1.Refresh();
                        }
                        else if (!Directory.Exists(f))
                        {
                            MessageBox.Show("name else --  " + sDir);
                        }

                        n++;
                            }

                    
                    DirSearch(d);
                }
            }

            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            FBD1.Description = "Выберете каталог для сохранения обработанных файлов";

            if (FBD1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = FBD1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                      

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            listBox1.Items.Clear();
            listBox1.Refresh();
            string adress = Convert.ToString(FBD.SelectedPath);
           
            button3.Text = "Обработка...";
            this.Cursor = Cursors.WaitCursor;
            
            Application.DoEvents();
            DirSearch(textBox1.Text);

            this.Cursor = Cursors.Default;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button3.Text = "Запуск";
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
            

      
          
    }
}

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
using System.Runtime.InteropServices;
using System.Globalization;
using System.Diagnostics;


namespace RecursiveDirectoryHandler_RDH_
{
    public partial class frmMain : Form
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        String dir = "";
        String pathIn = "";
        String pathOut = "";
        String pathLog = "";

        DateTime dtLog;
               
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBoxDir.Items.Clear();
            listBoxMain.Items.Clear();

            if (!File.Exists("Ionic.Zip.dll"))
            {
                MessageBox.Show("Библиотека Ionic.Zip.dll не найдена, дальнейшая работа невозможна", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

            if (!loadIni(Environment.CurrentDirectory + @"\tools.ini"))
            {
                MessageBox.Show("Отсуствует файл настроек - tools.ini", "Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                butstart.Enabled = false;
            }

            pathIn = getPath(pathIn);
            pathOut = getPath(pathOut);
            pathLog = getPath(pathLog);            

            if (dir == "")
            {
                MessageBox.Show("Директория для поиска не определена", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butstart.Enabled = false;
                txtDir.Enabled = true;
                btnDir.Visible = true;

            }
            if (!Directory.Exists(pathIn))
            {
                MessageBox.Show("Отсуствует IN директория", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butstart.Enabled = false;
                txtIn.Enabled = true;
                btnIn.Visible = true;
            }
            if (!Directory.Exists(pathOut))
            {
                MessageBox.Show("Отсуствует OUT директория", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butstart.Enabled = false;
                txtOut.Enabled = true;
                btnOut.Visible = true;
            }
        }

        private String getPath(String pathDir)
        {
            if (pathDir != "" && pathDir.Substring(pathDir.Length - 1) != @"\")
                return pathDir + @"\";
            return pathDir;
        }

        private String getName(String str)
        {
            return str.Substring(0, str.IndexOf("=")).Trim();
        }

        private String getValue(String str)
        {
            return str.Substring(str.IndexOf("=") + 1).Trim();
        }

        private Boolean loadIni(String fileIni)
        {
            if (!File.Exists(fileIni))
                return false;

            byte[] buffer = new byte[2048];            
            GetPrivateProfileSection("path", buffer, 2048, fileIni);
            String[] tmp = Encoding.GetEncoding(1251).GetString(buffer).Trim('\0').Split('\0');
            foreach (String entry in tmp)
                if (getValue(entry) != "")
                {
                    if (getName(entry).ToLower() == "dir".ToLower() && dir == "")
                    {
                        dir = getValue(entry).ToUpper();
                        txtDir.Text = dir;
                    }
                    if (getName(entry).ToLower() == "pathIn".ToLower() && pathIn == "")
                    {
                        pathIn = getValue(entry);
                        txtIn.Text = pathIn;
                    }
                    if (getName(entry).ToLower() == "pathOut".ToLower() && pathOut == "")
                    {
                        pathOut = getValue(entry);
                        txtOut.Text = pathOut;
                    }
                    if (getName(entry).ToLower() == "pathLog".ToLower() && pathLog == "")
                    {
                        pathLog = getValue(entry);
                        txtLog.Text = pathLog;
                    }
                }

            return true;
        }

        public int i = 0;
        public int n = 0;
        public int m = 0; 

        private void butStart_Click(object sender, EventArgs e)
        {
            i = 0;
            n = 0;
            m = 0;

            butstart.Enabled = false;
            butstart.Text = "Обработка...";
            this.Cursor = Cursors.WaitCursor;

            txtDir.Enabled = false;
            txtIn.Enabled = false;
            txtLog.Enabled = false;
            txtOut.Enabled = false;

            btnDir.Visible = false;
            btnIn.Visible = false;
            btnLog.Visible = false;
            btnOut.Visible = false;
            

            listBoxMain.Items.Clear();
            listBoxDir.Items.Clear();

            dtLog = DateTime.Now;

            DateTime localDate = DateTime.Now;
            int now = localDate.Year;
            int last = localDate.Year - 1;
            int lastlast = localDate.Year - 2;

            DateTime dtPath;

            DateTime dtb, dte;
            ZipFile zf;
            String archive;

            caption(pathIn);

            listBoxMain.Items.Add("Start... ");
            listBoxMain.Items.Add("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
            listBoxMain.Refresh(); 

            listBoxMain.Items.Add("Стартовая директория: " + pathIn);
            listBoxMain.Items.Add("-------------------------------------------------------------------");
            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
            listBoxMain.Refresh();   

            try
            {
                foreach (string pathDir in Directory.GetDirectories(pathIn))
                {                    
                    DateTime dt = Directory.GetCreationTime(pathDir);
                    
                    archive = dt.ToString("yyyy") + pathDir.Substring(pathIn.Length);

                    Boolean flag = DateTime.TryParseExact(archive, "yyyyddMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtPath);
                    if (flag)
                    {
                        listBoxMain.Items.Add("<---- Директория для поиска: " + pathDir + " ---->");
                        // удаляем
                        pathDelete(pathDir);
                        //MessageBox.Show("" + dt.Year);
                        //MessageBox.Show("" + dtLog.Year);
                        /////////////////////////
                        if (dt.Year == now)
                        {
                            
                        }
                        

                        else if (dt.Year == last)
                        {
                            // архиввация
                            dtb = DateTime.Now;
                            /////////////////////////
                            zf = new ZipFile();
                            zf.AlternateEncoding = Encoding.GetEncoding("cp866");

                            zf.AddDirectory(pathDir);//Добавляем папку
                            zf.Save(pathOut + @"\" + archive + ".zip"); //Сохраняем архив
                            /////////////////////////
                            dte = DateTime.Now;

                            listBoxMain.Items.Add("<==========================================================================>");
                            listBoxMain.Items.Add("Архивация директории: " + pathDir);
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Затрачено времени: " + (dte - dtb).ToString());
                            m++;
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            toolStripStatusLabel1.Text = "Создано архивов: " + m;
                            toolStripStatusLabel1.Visible = true;
                            // delete
                            Directory.Delete(pathDir, true);
                            // info
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Удалена заархивированная директория: " + pathDir);
                            listBoxMain.Items.Add("<==========================================================================>");
                        }
                        else if (dt.Year <= lastlast)
                        {
                            listBoxMain.Items.Add("<==========================================================================>");
                            listBoxMain.Items.Add("Удаление директории: " + pathDir);
                            listBoxMain.Items.Add("Дата создания: " + dt);
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                           // MessageBox.Show("test " + dt.Year + pathDir + dtLog.Year);
                            Directory.Delete(pathDir, true);
                            listBoxMain.Items.Add("Удаление завершено! ");
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                        }
                        /////////////////////////
                    }
                    
                    else
                        listBoxMain.Items.Add("Директория исключена из просмотра: " + pathDir);
                    listBoxMain.Items.Add("<==========================================================================>");

                    caption(pathDir);
                                        
                    listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                    listBoxMain.Refresh();   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
            butstart.Text = "Запуск";
            butstart.Enabled = true;
            
            listBoxMain.Items.Add("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            listBoxMain.Items.Add("=Finish!=");
            MessageBox.Show("Готово!", "Работа завершена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        void caption(String pathDir)
        {
            i++;            
            caption2(pathDir);
        }

        void caption2(String pathDir)
        {   
            toolStripStatusObr.Text = "Папок найдено: " + n;
            toolStripStatusFind.Text = "Папок обработанно: " + i;
            statusStrip1.Refresh();
        }

        void pathDelete(String pathDir)
        {            
            foreach (string pathNew in Directory.GetDirectories(pathDir))
            {
                caption(pathNew);

                listBoxDir.Items.Add(pathNew);
                listBoxDir.SelectedIndex = listBoxDir.Items.Count - 1;
                listBoxDir.Refresh();

                if (pathNew.Substring(pathDir.Length + 1).ToUpper() == dir)                
                {
                    try
                    {
                        // delete
                        DateTime dt = Directory.GetCreationTime(pathNew);
                        string archive_name = new DirectoryInfo(pathNew).Name;
                        if (dt.Year == dtLog.Year)
                        {
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Директория " + archive_name + " текущего года не подлежит удалению");
                            n++;
                        }
                        else
                        {
                            Directory.Delete(pathNew, true);
                            // info
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Удалена директория: " + pathNew);
                            //listBoxMain.Items.Add("___________________________________________________");

                            n++;
                            caption2(pathNew);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                        listBoxMain.Refresh();
                        listBoxMain.Items.Add("ERROR:" + ex.Message);
                        
                        listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                        listBoxMain.Refresh();
                        listBoxMain.Items.Add("Ошибка удаления директории: " + pathNew);                       
                       
                    }
                }
                else
                    pathDelete(pathNew);
            }

        }

        private void writeFile(ListBox list, Boolean flag)
        {
            if (list.Items.Count <= 0)
                return;

            String file = pathLog + getPathLog(flag);

            try
            {
                using (System.IO.StreamWriter fileStream =
                new System.IO.StreamWriter(file, true, Encoding.GetEncoding("cp866")))
                {
                    fileStream.WriteLine(list.Items[list.Items.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!File.Exists(file))
            {
                MessageBox.Show("Файл логов не создан","Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }   
        }

        private String getPathLog(Boolean flag)
        {
            return dtLog.ToString("yyyy_MM_dd_HH_mm_ss_") + (flag ? "main" : "path") + ".log";
        }

        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeFile(sender as ListBox, true);
        }

        private void listBoxDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeFile(sender as ListBox, false);
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOut_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void dsjlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!loadIni(Environment.CurrentDirectory + @"\tools.ini"))
            {
                MessageBox.Show("Отсуствует файл настроек - tools.ini", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butstart.Enabled = false;
            }

            txtDir.Enabled = true;
            txtIn.Enabled = true;
            txtLog.Enabled = true;
            txtOut.Enabled = true;

            btnDir.Visible = true;
            btnIn.Visible = true;
            btnLog.Visible = true;
            btnOut.Visible = true;
            
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Process.Start("tools.ini");
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Process.Start("tools.ini");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Process.Start("tools.ini");
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            Process.Start("tools.ini");
        }

        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 0;
            n = 0;
            m = 0;

            butstart.Enabled = false;
            butstart.Text = "Обработка...";
            this.Cursor = Cursors.WaitCursor;

            txtDir.Enabled = false;
            txtIn.Enabled = false;
            txtLog.Enabled = false;
            txtOut.Enabled = false;

            btnDir.Visible = false;
            btnIn.Visible = false;
            btnLog.Visible = false;
            btnOut.Visible = false;
            

            listBoxMain.Items.Clear();
            listBoxDir.Items.Clear();

            dtLog = DateTime.Now;

            DateTime localDate = DateTime.Now;
            int now = localDate.Year;
            int last = localDate.Year - 1;
            int lastlast = localDate.Year - 2;

            DateTime dtPath;

            DateTime dtb, dte;
            ZipFile zf;
            String archive;

            caption(pathIn);

            listBoxMain.Items.Add("Start... ");
            listBoxMain.Items.Add("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
            listBoxMain.Refresh(); 

            listBoxMain.Items.Add("Стартовая директория: " + pathIn);
            listBoxMain.Items.Add("-------------------------------------------------------------------");
            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
            listBoxMain.Refresh();   

            try
            {
                foreach (string pathDir in Directory.GetDirectories(pathIn))
                {                    
                    DateTime dt = Directory.GetCreationTime(pathDir);
                    
                    archive = dt.ToString("yyyy") + pathDir.Substring(pathIn.Length);

                    Boolean flag = DateTime.TryParseExact(archive, "yyyyddMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtPath);
                    if (flag)
                    {
                        listBoxMain.Items.Add("<---- Директория для поиска: " + pathDir + " ---->");
                        // удаляем
                        pathDelete(pathDir);
                        //MessageBox.Show("" + dt.Year);
                        //MessageBox.Show("" + dtLog.Year);
                        /////////////////////////
                        if (dt.Year == now)
                        {
                            
                        }
                        

                        else if (dt.Year == last)
                        {
                            // архиввация
                            dtb = DateTime.Now;
                            /////////////////////////
                            zf = new ZipFile();
                            zf.AlternateEncoding = Encoding.GetEncoding(1251);

                            zf.AddDirectory(pathDir);//Добавляем папку
                            zf.Save(pathOut + @"\" + archive + ".zip"); //Сохраняем архив
                            /////////////////////////
                            dte = DateTime.Now;

                            listBoxMain.Items.Add("<==========================================================================>");
                            listBoxMain.Items.Add("Архивация директории: " + pathDir);
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Затрачено времени: " + (dte - dtb).ToString());
                            m++;
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            toolStripStatusLabel1.Text = "Создано архивов: " + m;
                            toolStripStatusLabel1.Visible = true;
                            // delete
                            Directory.Delete(pathDir, true);
                            // info
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                            listBoxMain.Items.Add("Удалена заархивированная директория: " + pathDir);
                            listBoxMain.Items.Add("<==========================================================================>");
                        }
                        else if (dt.Year <= lastlast)
                        {
                            listBoxMain.Items.Add("<==========================================================================>");
                            listBoxMain.Items.Add("Удаление директории: " + pathDir);
                            listBoxMain.Items.Add("Дата создания: " + dt);
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                           // MessageBox.Show("test " + dt.Year + pathDir + dtLog.Year);
                            Directory.Delete(pathDir, true);
                            listBoxMain.Items.Add("Удаление завершено! ");
                            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                            listBoxMain.Refresh();
                        }
                        /////////////////////////
                    }
                    
                    else
                        listBoxMain.Items.Add("Директория исключена из просмотра: " + pathDir);
                    listBoxMain.Items.Add("<==========================================================================>");

                    caption(pathDir);
                                        
                    listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;
                    listBoxMain.Refresh();   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
            butstart.Text = "Запуск";
            butstart.Enabled = true;
            
            listBoxMain.Items.Add("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            listBoxMain.Items.Add("=Finish!=");
            MessageBox.Show("Готово!", "Работа завершена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        }       
    }


using System;
using System.Windows.Forms;
using gma.System.Windows;
using System.IO;
using System.Text;
using System.Drawing;
using Un4seen;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SoundBinder 
{
	class MainForm : System.Windows.Forms.Form
    {
		public MainForm()
		{
			InitializeComponent();
            //if (Properties.Settings.Default.OnlyInGame)
            //    Variables.OnlyInGame = true;
           // else Variables.OnlyInGame = false;
            //Variables.GamesName = Properties.Settings.Default.GamesName;
            string keys_path = Application.StartupPath + "\\keys.ini";
            if (!File.Exists(keys_path))
                File.Create(keys_path);
            else
            {
                string[] lines = File.ReadAllLines(keys_path, Encoding.GetEncoding(1251));
                foreach (string line in lines)
                {
                    if (line.StartsWith("#")) continue;
                    string[] splitted = line.Split(new char[] { '=' }, 2);
                    if (splitted.Length > 1)
                    {
                        splitted[0] = splitted[0].Trim();
                        splitted[1] = splitted[1].Trim();
                        Variables.Sounds.Add(splitted[1]);
                        Variables.Keys.Add(splitted[0]);
                    }
                }

                //for (int i = 0; i < Variables.Keys.Count; ++i)
                //{
                //    Variables.Keys[i] = Variables.Keys[i].Trim();
                //    listView1.Items.Add(Variables.Keys[i]);
                //}
            }

            string path = Application.StartupPath + "\\lastlist.pls";
            string updaterPath = Application.StartupPath + "\\Updater.exe";
            if (File.Exists(updaterPath))
                File.Delete(updaterPath);
            if (Properties.Settings.Default.LoadLastList && !string.IsNullOrEmpty(path))
            {
                if (String.IsNullOrEmpty(path))
                    return;

                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    if (line.StartsWith("File"))
                    {
                        string[] splitted = line.Split(new char[] { '=' }, 2);
                        if (splitted.Length > 1)
                        {
                            string name = Path.GetFileNameWithoutExtension(splitted[1]);
                            string fullName = Path.GetFullPath(splitted[1]);
                            listView1.Items.Add(name);
                            Variables.Files.Add(fullName);
                        }
                    }
                }
                listView1.Items[0].Selected = true;
            }
        }
        private CheckBox checkBoxHooks;
        private Button button1;



	
		void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStripMY = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenDit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMY = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxHooks = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStripMY.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 30);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(245, 315);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "œÓÁËˆËˇ Ù‡ÈÎ‡ ‚ ÔÎÂÈÎËÒÚÂ";
            this.columnHeader1.Width = 240;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox1.Location = new System.Drawing.Point(130, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "¡˚ÒÚ˚È ÔÓËÒÍ";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // contextMenuStripMY
            // 
            this.contextMenuStripMY.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMY.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenDit,
            this.toolStripSeparatorMY,
            this.toolStripMenuItemDelete});
            this.contextMenuStripMY.Name = "contextMenuStrip1";
            this.contextMenuStripMY.Size = new System.Drawing.Size(194, 54);
            // 
            // toolStripMenuItemOpenDit
            // 
            this.toolStripMenuItemOpenDit.Name = "toolStripMenuItemOpenDit";
            this.toolStripMenuItemOpenDit.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItemOpenDit.Text = "ÃÂÒÚÓÔÓÎÓÊÂÌËÂ";
            this.toolStripMenuItemOpenDit.Click += new System.EventHandler(this.toolStripMenuItemOpenDit_Click);
            // 
            // toolStripSeparatorMY
            // 
            this.toolStripSeparatorMY.Name = "toolStripSeparatorMY";
            this.toolStripSeparatorMY.Size = new System.Drawing.Size(190, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItemDelete.Text = "”‰‡ÎËÚ¸";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // checkBoxHooks
            // 
            this.checkBoxHooks.AutoSize = true;
            this.checkBoxHooks.Checked = true;
            this.checkBoxHooks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHooks.Location = new System.Drawing.Point(70, 7);
            this.checkBoxHooks.Name = "checkBoxHooks";
            this.checkBoxHooks.Size = new System.Drawing.Size(61, 21);
            this.checkBoxHooks.TabIndex = 3;
            this.checkBoxHooks.Text = "’ÛÍË";
            this.checkBoxHooks.UseVisualStyleBackColor = true;
            this.checkBoxHooks.CheckedChanged += new System.EventHandler(this.checkBoxHooks_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe Condensed", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "ŒÔˆËË";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(270, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxHooks);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "Sound Binder v0.40";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.contextMenuStripMY.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
			
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
        }
        private OpenFileDialog openFileDialog1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStripMY;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem toolStripMenuItemOpenDit;
        private ToolStripSeparator toolStripSeparatorMY;
        private ToolStripMenuItem toolStripMenuItemDelete;
		
		
		UserActivityHook actHook;
		void MainFormLoad(object sender, System.EventArgs e)
		{
            actHook = new UserActivityHook();
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            actHook.OnMouseActivity += new MouseEventHandler(MouseHook);
		}

        public void MouseHook(object sender, MouseEventArgs e)
        {
            if(Properties.Settings.Default.MouseHooks)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    if (listView1.SelectedItems[0] != null)
                    {
                        if (e.Delta < 0)
                        {
                            if (listView1.Items.Count != (listView1.SelectedIndices[0] + 1))
                            {
                                listView1.Items[listView1.SelectedIndices[0]].ForeColor =
                                    SystemColors.WindowText;
                                listView1.Items[listView1.SelectedIndices[0] + 1].ForeColor =
                                    Properties.Settings.Default.TextColor;
                                listView1.Items[listView1.SelectedIndices[0] + 1].Selected = true;
                                listView1.Items[listView1.SelectedIndices[0]].EnsureVisible();
                            }
                        }
                        else if (e.Delta > 0)
                        {
                            if (listView1.SelectedIndices[0] != 0)
                            {
                                listView1.Items[listView1.SelectedIndices[0]].ForeColor = SystemColors.WindowText;
                                listView1.Items[listView1.SelectedIndices[0] - 1].ForeColor = Properties.Settings.Default.TextColor;
                                listView1.Items[listView1.SelectedIndices[0] - 1].Selected = true;
                                listView1.Items[listView1.SelectedIndices[0]].EnsureVisible();
                            }
                        }
                        if (e.Button == MouseButtons.Middle)
                        {
                            Player.Play(listView1.SelectedIndices[0]);
                        }
                    }
                }
            }
        }

        private string[] splitted = null;
        private bool found = false;
        string CRAP = "null";
        string COM;
        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            // œŒÃ≈Õﬂ“‹ “”“ “¿…“À Õ¿—“–Œ≈ , ≈—À» Ã≈ÕﬂÀ ≈√Œ
            if(Properties.Settings.Default.Hooks == 0 &&
                (NativeMethods.GetActiveWindowTitle() == this.Text ||
                    NativeMethods.GetActiveWindowTitle() == "Settings..."))
            { return; }
            else if(Properties.Settings.Default.Hooks == 1 &&
                NativeMethods.GetActiveWindowTitle() != Properties.Settings.Default.HookInGame)
            { return; }
            //this.Text = "";
            //if (listView1.Items.Count < 1) return;
            //if (e.KeyCode == Keys.LShiftKey)
            //{
            //    shift = true;
            //}
           // MessageBox.Show(Variables.Sounds.Count.ToString() + Variables.Keys.Count.ToString());

            int i;
            for(i = 0; i < Variables.Keys.Count; ++i)
            {
                if(Variables.Keys[i].Contains(e.KeyCode.ToString())
                    && Variables.Keys[i] != e.KeyCode.ToString())
                {
                    splitted = Variables.Keys[i].Split(new char[] { '+' }, 2);
                    splitted[0] = splitted[0].Trim();
                    splitted[1] = splitted[1].Trim();
                    if (splitted[0] == e.KeyCode.ToString())
                    {
                        COM = e.KeyCode.ToString();
                        found = true;
                        //this.Text = splitted[0] + " " + splitted[1];
                        if(!Variables.AllKeys.Contains(splitted[1]))
                            Variables.AllKeys.Add(splitted[1]);
                        CRAP = Variables.Sounds[i];
                        
                        //break;
                    }
                }
            }

            //listView1.Items.Clear();
           // listView1.Items.Add(COM);

            //for (int j = 0; j < Variables.AllKeys.Count; ++j)
            //{
            //    listView1.Items.Add(Variables.AllKeys[j]);
            //}

            if (found)
            {
                for (int k = 0; k < Variables.AllKeys.Count; ++k )
                {
                    if(e.KeyCode.ToString() == Variables.AllKeys[k])
                    {
                        for (int h = 0; h < Variables.Keys.Count; ++h)
                        {
                            if (Variables.Keys[h].Contains(COM + "+" + Variables.AllKeys[k]))
                            {
                                //this.Text = COM + "+" + Variables.AllKeys[k];
                                Player.Play(Variables.Sounds[h]);
                                //listView1.Items.Add(Variables.Sounds[h]);
                                return;
                            }
                        }
                    }

                        //if (Variables.Keys[k].Contains(COM + "+" + Variables.AllKeys[k]))
                        //{
                        //    this.Text = Variables.AllKeys[k] + "+" + e.KeyCode.ToString();
                        //    break;
                        //    // Player.Play(Variables.)
                        //}
                }
                    //if (e.KeyCode.ToString() == splitted[1])
                    //{
                    //    //this.Text = splitted[1] + " " + CRAP;
                    //    Player.Play(CRAP);
                    //    return; // MAYBE
                    //}
            }
            //for (int j = 0; j < Variables.AllKeys.Count; ++j)
            //    listView1.Items.Add(Variables.AllKeys[j]);
            for(int j = 0; j < Variables.Keys.Count; ++j)
            {
                if (e.KeyCode.ToString() == Variables.Keys[j])
                    Player.Play(Variables.Sounds[j]);
            }

            if (Properties.Settings.Default.AutoRestor)
                if (e.KeyCode == (Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.KeyRestor, true))
                {
                    var ink = NativeMethods.FindWindow(null, Properties.Settings.Default.GamesName);
                    if (NativeMethods.GetActiveWindowTitle() == Properties.Settings.Default.GamesName) return;
                    NativeMethods.SetWindowPos(ink, (IntPtr)Variables.HWND_TOPMOST, 0, 0, 0, 0, Variables.SWP_NOMOVE | Variables.SWP_NOSIZE);
                    NativeMethods.SetWindowPos(ink, (IntPtr)Variables.HWND_NOTOPMOST, 0, 0, 0, 0, Variables.SWP_NOMOVE | Variables.SWP_NOSIZE);
                }
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            Variables.AllKeys.Clear();
            COM = "null";
            found = false;
            CRAP = "null";
            //if (splitted != null && (splitted[0] == e.KeyCode.ToString() 
            //    || splitted[1] == e.KeyCode.ToString()))
            //{
            //   // this.Text = "A";

            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void loadSettings()
        {
            if (Properties.Settings.Default.AlwaysOnTop)
                TopMost = true;
            else TopMost = false;
            Player.InitBass(44100, Properties.Settings.Default.DeviceNumber);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if ((Variables.GetFileExtension(file) != "wav") && (Variables.GetFileExtension(file) != "mp3"))
                    continue;
                else
                {
                    listView1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fi.FullName));
                    Variables.Files.Add(System.IO.Path.GetFullPath(file));
                }
            }
            listView1.Items[0].Selected = true;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    if (item.Text.ToLower().Contains(textBox1.Text.ToLower()))
                        listView1.EnsureVisible(item.Index);
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    contextMenuStripMY.Show(Cursor.Position);
            }
            else if(e.Button == MouseButtons.Left)
            {
            if (listView1.SelectedItems.Count > 0)
                if (listView1.SelectedItems[0] != null)
                {
                    listView1.Columns[0].Text = "¬˚·‡Ì: " + (listView1.SelectedIndices[0] + 1) + " ËÁ "
                    + listView1.Items.Count.ToString();
                    Player.Play(listView1.SelectedIndices[0]);
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                  listView1.Items[i].Remove();
                Variables.Files.RemoveAt(i);
                }
            }
        }

        private void toolStripMenuItemOpenDit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                if (listView1.SelectedItems[0] != null)
                    NativeMethods.SelectInFileExplorer(Variables.Files[listView1.SelectedIndices[0]]);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.LoadLastList)
            {
                string path = Application.StartupPath + "\\lastlist.pls";
                if (listView1.Items.Count < 1)
                    return;
                if (String.IsNullOrEmpty(path))
                    return;
                var sb = new StringBuilder("[playlist]" + Environment.NewLine);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sb.AppendFormat("File{0}={1}{2}", i, Variables.Files[i], Environment.NewLine);
                }
                File.WriteAllText(path, sb.ToString());
            }
        }

        private void checkBoxHooks_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHooks.Checked == true)
                actHook.Start();
            else actHook.Stop();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0] != null)
                {
                    listView1.Columns[0].Text = "¬˚·‡Ì: " + (listView1.SelectedIndices[0] + 1) + " ËÁ "
                    + listView1.Items.Count.ToString();
                }

                for(int i = 0; i < listView1.Items.Count; ++i)
                {
                    if(!listView1.Items[i].Selected)
                        listView1.Items[i].ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = (Width - 42);
        }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBinder
{
    /// <summary>
    /// This class allows changing settings by user
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Occurs on first form loading
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public SettingsForm()
        {
            InitializeComponent();

            Player.GetAllDevices(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void loadSettings()
        {
            if (Properties.Settings.Default.AutoRestor)
            {
                checkBox2.Checked = true;
                textBoxGamesName.Enabled = textBoxKey.Enabled = true;
            }
            else textBoxGamesName.Enabled = textBoxKey.Enabled = false;
            if (Properties.Settings.Default.LoadLastList)
                checkBox7.Checked = true;
            if (Properties.Settings.Default.MouseHooks)
            {
                button4.Enabled = true;
                mouse.Checked = true;
                button4.ForeColor = Properties.Settings.Default.TextColor;
                button4.Text = "Вкл";
            }
            comboBox1.SelectedIndex = Properties.Settings.Default.DeviceNumber;
            textBoxGamesName.Text = Properties.Settings.Default.GamesName;
            textBoxKey.Text = Properties.Settings.Default.KeyRestor;
            if (Properties.Settings.Default.AlwaysOnTop)
                checkBox1.Checked = true;
            if (Properties.Settings.Default.AutoRestor)
                checkBox2.Checked = true;

            comboBox2.SelectedIndex = Properties.Settings.Default.Hooks;
            if (Properties.Settings.Default.HookInGame != "No game")
                HookBlockTextBox.Text = Properties.Settings.Default.HookInGame;

            button1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
                Properties.Settings.Default.LoadLastList = true;
            else Properties.Settings.Default.LoadLastList = false;
            Properties.Settings.Default.DeviceNumber = comboBox1.SelectedIndex;
            if (checkBox1.Checked)
                Properties.Settings.Default.AlwaysOnTop = true;
            else Properties.Settings.Default.AlwaysOnTop = false;
            Properties.Settings.Default.GamesName = textBoxGamesName.Text;
            Properties.Settings.Default.KeyRestor = textBoxKey.Text;
            if (checkBox2.Checked)
                Properties.Settings.Default.AutoRestor = true;
            else Properties.Settings.Default.AutoRestor = false;
            if (mouse.Checked)
                Properties.Settings.Default.MouseHooks = true;
            else Properties.Settings.Default.MouseHooks = false;
            Properties.Settings.Default.Hooks = comboBox2.SelectedIndex;
            if (Properties.Settings.Default.Hooks == 1)
                Properties.Settings.Default.HookInGame = HookBlockTextBox.Text;
            else Properties.Settings.Default.HookInGame = "No game";
            //MessageBox.Show(Properties.Settings.Default.HookInGame);
            Properties.Settings.Default.Save();
            //Variables.SplitString(Properties.Settings.Default.Disabled);



            button1.Enabled = false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            loadSettings();
            //for (int i = 0; i < Variables.Keys.Count; ++i)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.Text = Variables.Keys[i];
            //    item.SubItems.Add(Variables.Sounds[i]);
            //    listView1.Items.Add(item);
            //}
        }

        private void textBoxShortcuts_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                textBoxKey.Enabled = textBoxGamesName.Enabled = true;
            else textBoxKey.Enabled = textBoxGamesName.Enabled = false;
            button1.Enabled = true;
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBoxGamesName_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VersionChecker.check();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mouse_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (mouse.Checked) { button4.Enabled = true; button4.Text = "Вкл"; }
            else { button4.Enabled = false; button4.Text = "Выкл"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Properties.Settings.Default.TextColor = button4.ForeColor = colorDialog1.Color;
            button1.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (comboBox2.SelectedIndex == 1)
                HookBlockTextBox.Enabled = true;
            else
                HookBlockTextBox.Enabled = false;
        }

        private void HookBlockTextBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

    }
}

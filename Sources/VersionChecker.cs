using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace SoundBinder
{
    /// <summary>
    /// Class that allow to load updates
    /// </summary>
    public static class VersionChecker
    {
        /// <summary>
        /// Check if new version exists
        /// </summary>
        /// <param name="localVersion">Current version</param>
        /// <param name="versionFromServer">Newer version</param>
        /// <returns></returns>
        public static bool NewVersionExists(string localVersion, string versionFromServer)
        {
            Version verLocal = new Version(localVersion);
            Version verWeb = new Version(versionFromServer);
            return verLocal < verWeb;
        }

        /// <summary>
        /// Loads update if it exists
        /// </summary>
        /// <param name="path">Path to new version on server</param>
        public static void load_obnovlenie(string path)
        {
            try
            {
                WebClient w = new WebClient();
                string adres = Application.StartupPath;

                adres += "\\Sound Binder New.exe";
                w.DownloadFile(new Uri(path), adres);
                File.WriteAllBytes(Application.StartupPath + "\\Updater.exe", SoundBinder.Properties.Resources.Updater);
                Process.Start(Application.StartupPath + "\\Updater.exe");
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Checks version on server
        /// </summary>
        /// <returns></returns>
        public static bool check()
        {
            string s = "";
            string localVersion = "";
            try
            {
                while (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    System.Threading.Thread.Sleep(60000);
                }
                localVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                WebClient w = new WebClient();
                s = w.DownloadString("http://asphysof.isp12.admintest.ru/version.txt");
                w.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string[] q = s.Split('|');
            if (VersionChecker.NewVersionExists(localVersion, q[0]))
            {
                if (MessageBox.Show("New version " + q[0] + " exists! Download now?", "Sound Binder Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
                load_obnovlenie(q[1]);
            }
            else
            {
                MessageBox.Show("No new version", "Sound Binder Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            return true;
        }
    }
}

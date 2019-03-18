using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBinder
{
    /// <summary>
    /// Stores global variables
    /// </summary>
    public static class Variables
    {
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_ASYNCWINDOWPOS = 0x4000;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_DEFERERASE = 0x2000;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_DRAWFRAME = 0x0020;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_FRAMECHANGED = 0x0020;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_HIDEWINDOW = 0x0080;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOACTIVATE = 0x0010;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOCOPYBITS = 0x0100;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOMOVE = 0x0002;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOOWNERZORDER = 0x0200;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOREDRAW = 0x0008;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOREPOSITION = 0x0200;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOSENDCHANGING = 0x0400;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOSIZE = 0x0001;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_NOZORDER = 0x0004;
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        public  const int SWP_SHOWWINDOW = 0x0040;

        /// <summary>
        /// Set window in focus
        /// </summary>
        public  const int HWND_TOP = 0;
        /// <summary>
        /// Set window out of focus
        /// </summary>
        public  const int HWND_BOTTOM = 1;
        /// <summary>
        /// Set window top most
        /// </summary>
        public  const int HWND_TOPMOST = -1;
        /// <summary>
        /// Set window not top most
        /// </summary>
        public  const int HWND_NOTOPMOST = -2;
        /// <summary>
        /// Gets the game's name from textBox
        /// </summary>
        public static string GamesName;

        /// <summary>
        /// On\off using hooks only in active game window
        /// </summary>
        /// 
        public static bool OnlyInGame;
        /// <summary>
        /// Website
        /// </summary>
        /// 
        public static string Website = "https://vk.com/phillybo";
        /// <summary>
        /// List which stores a full sounds pathes added in listView
        /// </summary>
        /// 
        public static List<string> Files = new List<string>();

        /// <summary>
        /// List which stores all the keys binded
        /// </summary>
        /// 
        public static List<string> Keys = new List<string>();
        /// <summary>
        /// List which stores all the key's sounds
        /// </summary>
        /// 



        public static List<string> Sounds = new List<string>();

        public static List<string> AllKeys = new List<string>();
        /// <summary>
        /// Massive of disabled keys
        /// </summary>
        public static string[] DisabledMass;

        /// <summary>
        /// Gets keys that needs to disable in massive, splitted by ","
        /// </summary>
        public static void SplitString(string Target)
        {
            DisabledMass = Target.Split(',');
        }

        /// <summary>
        /// Gets file extension
        /// </summary>
        /// <param name="fileName">Target file</param>
        /// <returns>Extension</returns>
        public static string GetFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }
    }
}

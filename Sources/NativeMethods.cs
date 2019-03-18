using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SoundBinder
{
    /// <summary>
    /// Contains methods
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Selecting file in window's explorer
        /// </summary>
        /// <param name="fullPath">Path to file</param>
        public static void SelectInFileExplorer(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentNullException("fullPath");

            fullPath = System.IO.Path.GetFullPath(fullPath);

            IntPtr pidlList = NativeMethods.ILCreateFromPathW(fullPath);
            if (pidlList != IntPtr.Zero)
                try
                {
                    // Open parent folder and select item
                    Marshal.ThrowExceptionForHR(NativeMethods.SHOpenFolderAndSelectItems(pidlList, 0, IntPtr.Zero, 0));
                }
                finally
                {
                    NativeMethods.ILFree(pidlList);
                }
        }

        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

         //<summary>
         //Gets active window title
         //</summary>
         //<returns></returns>
        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        
        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        [DllImport("shell32.dll", ExactSpelling = true)]
        public static extern void ILFree(IntPtr pidlList);

        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern IntPtr ILCreateFromPathW(string pszPath);

        /// <summary>
        /// NEED FOR CORRECT WORKING
        /// </summary>
        [DllImport("shell32.dll", ExactSpelling = true)]
        public static extern int SHOpenFolderAndSelectItems(IntPtr pidlList, uint cild, IntPtr children, uint dwFlags);
    }
}

using System;
using Un4seen.Bass;
using System.Windows.Forms;
namespace SoundBinder
{
    /// <summary>
    /// By using this class program works with sound
    /// </summary>
    public static class Player
    {
        //private static int FQ = 44100;
        /// <summary>
        /// Determines initializing state
        /// </summary>
        public static bool InitDefaultDevice;
        /// <summary>
        /// Using to play sound by streaming
        /// </summary>
        public static int Stream;

        /// <summary>
        /// Get all avialable sound devices
        /// </summary>
        /// <param name="comboBox">Fill specified combobox</param>
        /// <returns></returns>
        public static void GetAllDevices(ComboBox comboBox)
        {
            BASS_DEVICEINFO info = new BASS_DEVICEINFO();
            comboBox.Items.Clear();
            for (int n = 0; Bass.BASS_GetDeviceInfo(n, info); n++)
                comboBox.Items.Add(info.ToString());
        }
        /// <summary>
        /// Initializing bass
        /// </summary>
        /// <param name="FQ">Frequency</param>
        /// <param name="dev">Number of sound device that's been selected</param>
        /// <returns></returns>
        public static void InitBass(int FQ, int dev)
        {
            //if (!InitDefaultDevice)
                InitDefaultDevice = Bass.BASS_Init(dev, FQ, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            //return InitDefaultDevice;
        }

        /// <summary>
        /// Playing sound by selected index in listView
        /// </summary>
        /// <param name="index">Determines sound which has been selected</param>
        /// <returns></returns>
        public static void Play(int index)
        {
            Stop();
            if (!(index > Variables.Files.Count))
            {
                Stream = Bass.BASS_StreamCreateFile(Variables.Files[index], 0, 0, BASSFlag.BASS_DEFAULT);
                if(Stream != 0)
                {
                    Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, 100);
                    Bass.BASS_ChannelPlay(Stream, false);
                }
            }
        }

        public static void Play(string path)
        {
            Stop();
           // MessageBox.Show(path);
            Stream = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_DEFAULT);
            if (Stream != 0)
            {
                Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, 100);
                Bass.BASS_ChannelPlay(Stream, false);
            }
            else MessageBox.Show("eror");
        }

        /// <summary>
        /// Stops playing sound
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public static void Stop()
        {
            Bass.BASS_ChannelStop(Stream);
            Bass.BASS_StreamFree(Stream);
        }
    }
}


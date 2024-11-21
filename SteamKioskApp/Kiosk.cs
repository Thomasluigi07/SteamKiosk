using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamKioskApp
{
    public partial class Kiosk : Form
    {
        struct Resolution
        {
            public int Width;
            public int Height;
        }

        int previous = -1;
        int current = -1;

        private int GetScreenIndex()
        {
            return Array.IndexOf(Screen.AllScreens, Screen.FromControl(this));
        }

        private bool CheckScreenChanged()
        {
            bool changed = false;
            current = GetScreenIndex();

            if (current != -1 && previous != -1 && current != previous)
            {
                changed = true;
            }

            previous = current;

            return changed;
        }

        private void SetFormSize()
        {
            Resolution res = GetCurrentResolution();
            this.Size = new Size(res.Width, res.Height);
            this.Top = 0;
            this.Left = 0;
        }

        private void Form_Moved(object sender, System.EventArgs e)
        {
            bool changed = CheckScreenChanged();
            if (changed == true)
            {
                SetFormSize();
            }
        }


        public void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            SetFormSize();
        }

        private Resolution GetCurrentResolution()
        {
            Screen screen = Screen.FromControl(this);
            Resolution res = new Resolution();
            res.Width = screen.Bounds.Width;
            res.Height = screen.Bounds.Height;

            return res;
        }

        public Kiosk()
        {
            InitializeComponent();
            this.Move += Form_Moved;
            SystemEvents.DisplaySettingsChanged += new
            EventHandler(SystemEvents_DisplaySettingsChanged);
            previous = GetScreenIndex();
            current = GetScreenIndex();
            SetFormSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SteamKioskApp.LogOut LogOut = new SteamKioskApp.LogOut();
            LogOut.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (steam.IsBusy != true)
            {
                steam.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (steam.IsBusy != true)
            {
                steam.RunWorkerAsync();
            }
        }

        private void steam_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                var pProcess = new Process();
                pProcess.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Steam\steam.exe");
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.Start();
            }
            catch
            {
                MessageBox.Show("Failed to open Steam!", "Steam Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}

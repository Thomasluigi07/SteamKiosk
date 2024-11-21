using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace SteamKioskApp
{
    public partial class LogOut : Form
    {
        public LogOut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogOutHelper.ExitWindows(ExitWindows.LogOff, ShutdownReason.FlagUserDefined, true);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

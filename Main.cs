using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
namespace RosaryModManager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.23.5/BepInEx_win_x64_5.4.23.5.zip";
            string extractPath = guna2TextBox1.Text;

            if (string.IsNullOrWhiteSpace(extractPath) || !Directory.Exists(extractPath))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }

            string zipPath = Path.Combine(Path.GetTempPath(), "bepinex.zip");

            try
            {
                using (WebClient wc = new WebClient())
                {
                    await wc.DownloadFileTaskAsync(new Uri(url), zipPath);
                }

                ZipFile.ExtractToDirectory(zipPath, extractPath);

                MessageBox.Show("Bepinex installed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string path = guna2TextBox1.Text;

            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }

            try
            {
                string bepInExFolder = Path.Combine(path, "BepInEx");
                string winhttp = Path.Combine(path, "winhttp.dll");
                string doorstopConfig = Path.Combine(path, "doorstop_config.ini");
                string doorstopDll = Path.Combine(path, "doorstop_x64.dll");
                string changelog = Path.Combine(path, "changelog.txt");
                string doorstopVersion = Path.Combine(path, ".doorstop_version");
                if (Directory.Exists(bepInExFolder))
                    Directory.Delete(bepInExFolder, true);

                if (File.Exists(winhttp))
                    File.Delete(winhttp);

                if (File.Exists(doorstopConfig))
                    File.Delete(doorstopConfig);

                if (File.Exists(doorstopDll))
                    File.Delete(doorstopDll);
                if (File.Exists(changelog))
                    File.Delete(changelog);
                if (File.Exists(doorstopVersion))
                    File.Delete(doorstopVersion);
                MessageBox.Show("Bepinex uninstalled successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/iiDk-the-actual/iis.Stupid.Menu/releases/download/8.3.0/iis_Stupid_Menu.dll";
            string folder = guna2TextBox1.Text + "\\BepInEx\\plugins";
            string filePath = Path.Combine(folder, "iis_Stupid_Menu.dll");

            try
            {

                using (WebClient wc = new WebClient())
                {
                    await wc.DownloadFileTaskAsync(new Uri(url), filePath);
                }

                MessageBox.Show("IIdk Menu Installed!");
            }
            catch (Exception ex)
            {
            }
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/BrokenSt0ne/Consoleless/releases/download/1.0.3/Consoleless.dll";
            string folder = guna2TextBox1.Text + "\\BepInEx\\plugins";
            string filePath = Path.Combine(folder, "Consoleless.dll");

            try
            {

                using (WebClient wc = new WebClient())
                {
                    await wc.DownloadFileTaskAsync(new Uri(url), filePath);
                }

                MessageBox.Show("Consoleless Installed!");
            }
            catch (Exception ex)
            {
            }
        }
    }
}

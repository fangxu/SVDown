using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lite
{
    public partial class Form1 : Form
    {
        private Video video;
        private DownloadManager dm;
        public delegate void Title(String s);

        public void updateTitle(String s)
        {
            this.Text = s;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dlg.SelectedPath;
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            video = new Video(textBoxUrl.Text);
            video.saveName = textBoxSaveName.Text;
            video.path = textBoxPath.Text;
            XML.parserVideo(video);
            Console.WriteLine("hello");
            dm = new DownloadManager(this, video);
            dm.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (dm == null)
            {
                return;
            }
            dm.Stop();
            dm = null;
        }
    }
}

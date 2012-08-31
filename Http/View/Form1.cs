using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SVDown.Services;

namespace Http
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBoxHtml.Text = Service.GetHtmlString(textBoxHttp.Text);
            String xmlUrl = @"http://v.iask.com/v_play.php?vid=" + "81799417";
            textBoxHtml.Text = Service.GetHtmlString(xmlUrl);
            HtmlService.GetVideo(xmlUrl);
        }
    }
}

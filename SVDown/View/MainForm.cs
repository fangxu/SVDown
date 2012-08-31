using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SVDown.View;
using SVDown.Model;
using SVDown.Controller;

namespace SVDown
{
    public partial class MainForm : Form, IView
    {
        private IModel model;
        private IController controller;

        public delegate void updateListView();

        public MainForm()
        {
            InitializeComponent();
            model = new Model.Model(this);
            controller = new Controller.Controller(this, model);
            model.addObserver(this);
        }

        public void updateView()
        {
            listView1.Items.Clear();
            foreach (Video v in model.getVideos())
            {
                String[] s = new String[]{
                    "",v.SaveName,v.TimeLength.ToString(),"",v.process.ToString(),
                    v.Path,v.start.ToString(),v.end.ToString()
                };
                ListViewItem lvi = new ListViewItem(s);
                listView1.Items.Add(lvi);
            }
        }

        private void toolStripButtonNewTask_ButtonClick(object sender, EventArgs e)
        {
            NewTask newTask = new NewTask(controller);
            newTask.ShowDialog(this);
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            controller.startDownload();
        }
    }
}

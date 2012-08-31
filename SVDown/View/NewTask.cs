using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SVDown.Controller;
using SVDown.Model;

namespace SVDown
{
    public partial class NewTask : Form
    {
        private IController ic;
        public NewTask(IController ic)
        {
            InitializeComponent();
            comboBoxPath.Items.Add(Environment.CurrentDirectory);
            comboBoxPath.SelectedIndex = 0;
            this.ic = ic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {           
            ic.newTask(textBoxUrl.Text, textBoxName.Text, comboBoxPath.SelectedItem.ToString());
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg=new FolderBrowserDialog();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                comboBoxPath.Items.Add(dlg.SelectedPath);
                //comboBoxPath.SelectedItem = comboBoxPath.Items.Count-1;
                comboBoxPath.SelectedIndex = comboBoxPath.Items.Count - 1;
            }
        }
    }
}

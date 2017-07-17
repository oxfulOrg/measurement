using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enviriomentMeasurement
{
    public partial class addClassify : Form
    {

        public event EventHandler addData;

        public void clearData()
        {
            this.richTextBox1.Text = "";
        }

        public string getData()
        {
            return this.richTextBox1.Text;
        }

        public addClassify()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (null != addData)
            {
                addData(sender, e);
            }
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addClassify_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

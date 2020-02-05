using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMERP
{
    public partial class masters : Form
    {
        public masters()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void masters_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            employeemaster em = new employeemaster();
            em.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productmaster pm = new productmaster();
            pm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            employeemaster em = new employeemaster();
            em.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employeemaster em = new employeemaster();
            em.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            suppliermaster sm = new suppliermaster();
            sm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            customermaster cm = new customermaster();
            cm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            brokermaster bm = new brokermaster();
            bm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            departmentmaster dm = new departmentmaster();
            dm.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            designationmaster dm = new designationmaster();
            dm.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

       
    }
}

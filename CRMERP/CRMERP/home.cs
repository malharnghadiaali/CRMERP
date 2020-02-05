using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CRMERP
{
    public partial class home : Form
    {
        
        public home()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
            PopulateRssFeed();

            this.WindowState = FormWindowState.Maximized;
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            //con.Open();

            //label3.Text = loginform.name;
            
            //string q = "Select count(*) from EmpMaster";
            //SqlCommand cmd = new SqlCommand(q, con);
            //int d = (int)cmd.ExecuteScalar();
            //label6.Text = d.ToString();

            //string q1 = "Select count(*) from DeptMaster";
            //SqlCommand cmd1 = new SqlCommand(q1, con);
            //int d1 = (int)cmd1.ExecuteScalar();
            //label9.Text = d1.ToString();

            //string q2 = "Select count(*) from DesigMaster";
            //SqlCommand cmd2 = new SqlCommand(q2, con);
            //int d2 = (int)cmd2.ExecuteScalar();
            //label11.Text = d2.ToString();

            //string q3 = "Select count(*) from SuppMaster";
            //SqlCommand cmd3 = new SqlCommand(q3, con);
            //int d3 = (int)cmd3.ExecuteScalar();
            //label21.Text = d3.ToString();

            //string q4 = "Select count(*) from CustMaster";
            //SqlCommand cmd4 = new SqlCommand(q4, con);
            //int d4 = (int)cmd4.ExecuteScalar();
            //label23.Text = d4.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "CRM ERP", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            masters m = new masters();
            m.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            companyprofile cp = new companyprofile();
            cp.Show();
        }

        private void logout(object sender, EventArgs e)
        {
            this.Hide();
            loginform h = new loginform();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }

        private void PopulateRssFeed()
        {
            string RssFeedUrl = "http://feeds.feedburner.com/NDTV-LatestNews";
            List<Class1> feeds = new List<Class1>();

            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        //  label1.Text = i.title;
                        //  linkLabel1.Text = i.link;
                        Class1 f = new Class1
                        {
                            Title = i.title,
                            Link = i.link,
                            PublishDate = i.pubDate,
                            Description = i.description
                        };

                        feeds.Add(f);

                    }
                }
                dataGridView1.DataSource = feeds;
                int k = 0;
                Label[] lray = { label25, linkLabel26, label27, label28,label30,linkLabel1,label26,label29,label33,linkLabel2, label31, label32, label42, linkLabel5, label40, label41, label48, linkLabel7, label46, label47 };

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        
                        if (k < 20)
                        {
                            lray[k].Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            k = k + 1;
                        }
                    }
                }

                linkLabel26.Text = "Read more..";
                linkLabel1.Text = "Read more..";
                linkLabel2.Text = "Read more..";
                linkLabel5.Text = "Read more..";
                linkLabel7.Text = "Read more..";

                String Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

                String[] str_array = Text.Split('<');
                String stringa = str_array[0];
                String stringb = str_array[1];

                label28.Text = stringa;

                Text = dataGridView1.Rows[1].Cells[3].Value.ToString();

                str_array = Text.Split('<');
                 stringa = str_array[0];
                 stringb = str_array[1];

                label29.Text = stringa;

                Text = dataGridView1.Rows[2].Cells[3].Value.ToString();

                str_array = Text.Split('<');
                stringa = str_array[0];
                stringb = str_array[1];

                label32.Text = stringa;

                Text = dataGridView1.Rows[3].Cells[3].Value.ToString();

                str_array = Text.Split('<');
                stringa = str_array[0];
                stringb = str_array[1];

                label41.Text = stringa;

                Text = dataGridView1.Rows[4].Cells[3].Value.ToString();

                str_array = Text.Split('<');
                stringa = str_array[0];
                stringb = str_array[1];

                label47.Text = stringa;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel26.LinkVisited = true;
            System.Diagnostics.Process.Start(dataGridView1.Rows[0].Cells[1].Value.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(dataGridView1.Rows[1].Cells[1].Value.ToString());


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(dataGridView1.Rows[2].Cells[1].Value.ToString());

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(dataGridView1.Rows[3].Cells[1].Value.ToString());

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(dataGridView1.Rows[4].Cells[1].Value.ToString());

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

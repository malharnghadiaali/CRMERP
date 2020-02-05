using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMERP
{
    public partial class designationmaster : Form
    {
        public designationmaster()
        {
            InitializeComponent();
        }

        private void designationmaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void desigid_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DesigID.Text))
            {

                errorProvider1.SetError(DesigID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(DesigID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(DesigID.Text))
                {
                    errorProvider1.SetError(DesigID, "");
                }
                else
                {
                    errorProvider1.SetError(DesigID, "Please Enter Valid Input!");
                }

            }
        }

        private void designame_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DesigName.Text))
            {

                errorProvider1.SetError(DesigName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(DesigName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(DesigName.Text))
                {
                    errorProvider1.SetError(DesigName, "");
                }
                else
                {
                    errorProvider1.SetError(DesigName, "Please Enter Valid Input!");
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DesigID.Text) || string.IsNullOrWhiteSpace(DesigName.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                con.Open();

                decimal t1 = decimal.Parse(DesigID.Text);
                string q = "select * from DesigMaster where DesigID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Designation ID is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into DesigMaster values (@t1,@t2,@t3)";

                    cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(DesigID.Text));
                    cmd.Parameters.AddWithValue("@t2", (DesigName.Text));
                    cmd.Parameters.AddWithValue("@t3", (DateTime.Today));




                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Inserted");
                    string query = "select * from DesigMaster";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(query, con);
                    dap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    con.Close();
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            string q = "update DesigMaster set DesigID=@t1,DesigName=@t2,Timestamp=@t3 where DesigID=@t1";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@t1", decimal.Parse(DesigID.Text));
            cmd.Parameters.AddWithValue("@t2", (DesigName.Text));
            cmd.Parameters.AddWithValue("@t3", (DateTime.Today));


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from DesigMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            string q = "delete from DesigMaster where DesigID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", int.Parse(DesigID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
            string query = "select * from DesigMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection con;

            con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            if (string.IsNullOrWhiteSpace(DesigID.Text))
            {
                MessageBox.Show("Enter Designation ID");
            }
           
            else
            {
                decimal t1 = decimal.Parse(DesigID.Text);

                string q = "select * from DesigMaster where DesigID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        DesigID.Text = myreader["DesigID"].ToString();
                        DesigName.Text = myreader["DesigName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Designation ID not found");
                }
            }

            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }
    }
}

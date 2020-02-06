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
    public partial class departmentmaster : Form
    {
        public departmentmaster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "CRM ERP", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
           

        }

        private void departmentmaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            string query = "select * from DeptMaster";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DeptID.Text) || string.IsNullOrWhiteSpace(DeptName.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                con.Open();

                decimal t1 = decimal.Parse(DeptID.Text);
                string q = "select * from DeptMaster where DeptID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Department ID is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into DeptMaster values (@t1,@t2,@t3)";

                    cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(DeptID.Text));
                    cmd.Parameters.AddWithValue("@t2", (DeptName.Text));
                    cmd.Parameters.AddWithValue("@t3", (DateTime.Today));




                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Inserted");
                    string query = "select * from DeptMaster";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(query, con);
                    dap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    con.Close();
                }
            }
        }

        private void DeptID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DeptID.Text))
            {

                errorProvider1.SetError(DeptID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(DeptID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(DeptID.Text))
                {
                    errorProvider1.SetError(DeptID, "");
                }
                else
                {
                    errorProvider1.SetError(DeptID, "Please Enter Valid Input!");
                }

            }
        }

        private void DeptName_Validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DeptName.Text))
            {

                errorProvider1.SetError(DeptName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(DeptName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(DeptName.Text))
                {
                    errorProvider1.SetError(DeptName, "");
                }
                else
                {
                    errorProvider1.SetError(DeptName, "Please Enter Valid Input!");
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            string q = "update DeptMaster set DeptID=@t1,DeptName=@t2,Timestamp=@t3 where DeptID=@t1";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@t1", decimal.Parse(DeptID.Text));
            cmd.Parameters.AddWithValue("@t2", (DeptName.Text));
            cmd.Parameters.AddWithValue("@t3", (DateTime.Today));


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from DeptMaster";

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
            string q = "delete from DeptMaster where DeptID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", int.Parse(DeptID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
            string query = "select * from DeptMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void DeptMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S) {

                Save_Click(sender, e);
                
            }
            if (e.Control == false && e.KeyCode == Keys.Escape)
            {

                button1_Click(sender, e);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection con;

            con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            if (string.IsNullOrWhiteSpace(DeptID.Text))
            {
                MessageBox.Show("Enter Department ID");
            }
            else
            {
                decimal t1 = decimal.Parse(DeptID.Text);
                string q = "select * from DeptMaster where DeptID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        DeptID.Text = myreader["DeptID"].ToString();
                        DeptName.Text = myreader["DeptName"].ToString();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Department ID not found");
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

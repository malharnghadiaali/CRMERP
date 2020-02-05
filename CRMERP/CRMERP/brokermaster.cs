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
    public partial class brokermaster : Form
    {
        public brokermaster()
        {
            InitializeComponent();
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brokermaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            this.WindowState = FormWindowState.Maximized;
            string query = "select * from BrokerMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrokerID.Text) || string.IsNullOrWhiteSpace(BrokerName.Text) || string.IsNullOrWhiteSpace(BrokerCategory.Text) || string.IsNullOrWhiteSpace(BrokerEmailID.Text) || string.IsNullOrWhiteSpace(BrokerMobileNo.Text) || string.IsNullOrWhiteSpace(Pincode.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                con.Open();
                decimal t1 = decimal.Parse(BrokerID.Text);
                string q = "select * from BrokerMaster where BrokerID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Broker ID is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into BrokerMaster values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16)";

                    cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(BrokerID.Text));
                    cmd.Parameters.AddWithValue("@t2", (BrokerName.Text));
                    cmd.Parameters.AddWithValue("@t3", (BrokerCategory.Text));
                    cmd.Parameters.AddWithValue("@t4", decimal.Parse(BrokerMobileNo.Text));
                    cmd.Parameters.AddWithValue("@t5", (BrokerEmailID.Text));


                    cmd.Parameters.AddWithValue("@t6", (Address1.Text));
                    cmd.Parameters.AddWithValue("@t7", (Address2.Text));
                    cmd.Parameters.AddWithValue("@t8", (Landmark.Text));
                    cmd.Parameters.AddWithValue("@t9", decimal.Parse(Pincode.Text));
                    cmd.Parameters.AddWithValue("@t10", (City.Text));
                    cmd.Parameters.AddWithValue("@t11", (State.Text));
                    cmd.Parameters.AddWithValue("@t12", (Country.Text));

                    cmd.Parameters.AddWithValue("@t13", (Broker_PAN_No.Text));
                    cmd.Parameters.AddWithValue("@t14", (Broker_GST_No.Text));

                    cmd.Parameters.AddWithValue("@t15", 11);
                    cmd.Parameters.AddWithValue("@t16", DateTime.Today);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Inserted");
                    string query = "select * from BrokerMaster";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(query, con);
                    dap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    con.Close();
                }
            }
        }
        private void id_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrokerID.Text))
            {

                errorProvider1.SetError(BrokerID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(BrokerID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(BrokerID.Text))
                {
                    errorProvider1.SetError(BrokerID, "");

                }
                else
                {
                    errorProvider1.SetError(BrokerID, "Please Enter Valid Input!");
                }

            }

        }

        private void name_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrokerName.Text))
            {

                errorProvider1.SetError(BrokerName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(BrokerName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(BrokerName.Text))
                {
                    errorProvider1.SetError(BrokerName, "");
                }
                else
                {
                    errorProvider1.SetError(BrokerName, "Please Enter Valid Input!");
                }
            }
        }

        private void mobile_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrokerMobileNo.Text))
            {

                errorProvider1.SetError(BrokerMobileNo, "Enter Mobile Number!");
            }
            else
            {
                errorProvider1.SetError(BrokerMobileNo, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(BrokerMobileNo.Text))
                {
                    errorProvider1.SetError(BrokerMobileNo, "");
                }
                else
                {
                    errorProvider1.SetError(BrokerMobileNo, "Please Enter Valid Input!");
                }

            }
        }

        private void email_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrokerEmailID.Text))
            {

                errorProvider1.SetError(BrokerEmailID, "Enter Email!");
            }
            else
            {
                errorProvider1.SetError(BrokerEmailID, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(BrokerEmailID.Text))
                {
                    errorProvider1.SetError(BrokerEmailID, "");
                }
                else
                {
                    errorProvider1.SetError(BrokerEmailID, "Please Enter Valid Input!");
                }
            }
        }

        private void pin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Pincode.Text))
            {

                errorProvider1.SetError(Pincode, "Please Enter the Pincode!");

            }
            else
            {
                errorProvider1.SetError(Pincode, "");

                Regex r = new Regex("^[1-9][0-9]{5}$");
                if (r.IsMatch(Pincode.Text))
                {
                    SqlCommand cmd;
                    SqlConnection con;

                    con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                    con.Open();
                    decimal t1 = decimal.Parse(Pincode.Text);
                    string q = "select * from pincode where pincode='" + @t1 + "'";

                    cmd = new SqlCommand(q, con);
                    SqlDataReader myreader = cmd.ExecuteReader();

                    while (myreader.Read())
                    {
                        City.Text = myreader["city"].ToString();
                        State.Text = myreader["state"].ToString();
                        Country.Text = "India";

                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(Pincode, "Please Enter Valid Input!");
                }

            }
        }
        private void pan_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Broker_PAN_No.Text))
            {
                errorProvider1.SetError(Broker_PAN_No, "");
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
                if (r.IsMatch(Broker_PAN_No.Text))
                {
                    errorProvider1.SetError(Broker_PAN_No, "");
                }
                else
                {
                    errorProvider1.SetError(Broker_PAN_No, "Please Enter Valid Input!");
                }
            }
        }

        private void gst_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Broker_GST_No.Text))
            {
                errorProvider1.SetError(Broker_GST_No, "");
            }
            else
            {
               

                Regex r = new Regex("^^([0]{1}[1-9]{1}|[1-2]{1}[0-9]{1}|[3]{1}[0-7]{1})([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$");
                if (r.IsMatch(Broker_GST_No.Text))
                {
                    errorProvider1.SetError(Broker_GST_No, "");
                }
                else
                {
                    errorProvider1.SetError(Broker_GST_No, "Please Enter Valid Input!");
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection con;

            con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            if (string.IsNullOrWhiteSpace(BrokerID.Text))
            {
                MessageBox.Show("Enter Broker ID");
            }
            else
            {
                decimal t1 = decimal.Parse(BrokerID.Text);
                string q = "select * from BrokerMaster where BrokerID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if(myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        BrokerID.Text = myreader["BrokerID"].ToString();
                        BrokerName.Text = myreader["BrokerName"].ToString();
                        BrokerCategory.Text = myreader["BrokerCategory"].ToString();
                        Broker_PAN_No.Text = myreader["Broker_PAN_No"].ToString();
                        Broker_GST_No.Text = myreader["Broker_GST_No"].ToString();

                        BrokerMobileNo.Text = myreader["BrokerMobile1"].ToString();

                        BrokerEmailID.Text = myreader["BrokerEmail1"].ToString();



                        Address1.Text = myreader["Address1"].ToString();

                        Address2.Text = myreader["Address2"].ToString();
                        Landmark.Text = myreader["Landmark"].ToString();

                        Pincode.Text = myreader["Pincode"].ToString();
                        City.Text = myreader["City"].ToString();

                        State.Text = myreader["State"].ToString();
                        Country.Text = myreader["Country"].ToString();



                    }
                }
                else
                {
                    MessageBox.Show("Broker ID not found");

                }
            }
            con.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            string q = "delete from BrokerMaster where BrokerID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", int.Parse(BrokerID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
            string query = "select * from BrokerMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            string q = "update BrokerMaster set BrokerID=@t1,BrokerName=@t2,BrokerCategory=@t3,BrokerMobile1=@t4,BrokerEmail1=@t5,Address1=@t6,Address2=@t7,Landmark=@t8,Pincode=@t9,City=@t10,State=@t11,Country=@t12,Broker_PAN_No=@t13,Broker_GST_No=@t14,EntryID=@t15,Timestamp=@t16 where BrokerID=@t1";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@t1", decimal.Parse(BrokerID.Text));
            cmd.Parameters.AddWithValue("@t2", (BrokerName.Text));
            cmd.Parameters.AddWithValue("@t3", (BrokerCategory.Text));
            cmd.Parameters.AddWithValue("@t4", decimal.Parse(BrokerMobileNo.Text));
            cmd.Parameters.AddWithValue("@t5", (BrokerEmailID.Text));


            cmd.Parameters.AddWithValue("@t6", (Address1.Text));
            cmd.Parameters.AddWithValue("@t7", (Address2.Text));
            cmd.Parameters.AddWithValue("@t8", (Landmark.Text));
            cmd.Parameters.AddWithValue("@t9", decimal.Parse(Pincode.Text));
            cmd.Parameters.AddWithValue("@t10", (City.Text));
            cmd.Parameters.AddWithValue("@t11", (State.Text));
            cmd.Parameters.AddWithValue("@t12", (Country.Text));

            cmd.Parameters.AddWithValue("@t13", (Broker_PAN_No.Text));
            cmd.Parameters.AddWithValue("@t14", (Broker_GST_No.Text));

            cmd.Parameters.AddWithValue("@t15", 11);
            cmd.Parameters.AddWithValue("@t16", DateTime.Today);


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from BrokerMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            masters m = new masters();
            m.Close();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
           
        }
    }
    }


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
using System.Text.RegularExpressions;

namespace CRMERP
{
    public partial class customermaster : Form
    {
        public customermaster()
        {
            InitializeComponent();
        }

        private void customermaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();

            string query = "select * from CustMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustID.Text) || string.IsNullOrWhiteSpace(CustName.Text) || string.IsNullOrWhiteSpace(CustMobile1.Text) || string.IsNullOrWhiteSpace(CustEmail1.Text) || string.IsNullOrWhiteSpace(Pincode.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                con.Open();

                decimal t1 = decimal.Parse(CustID.Text);
                string q = "select * from CustMaster where CustID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Customer ID is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into CustMaster values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25)";

                    cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(CustID.Text));
                    cmd.Parameters.AddWithValue("@t2", (CustName.Text));
                    cmd.Parameters.AddWithValue("@t3", (CustCategory.Text));
                    cmd.Parameters.AddWithValue("@t4", decimal.Parse(CustMobile1.Text));
                    cmd.Parameters.AddWithValue("@t5", (CustMobile2.Text));
                    cmd.Parameters.AddWithValue("@t6", (CustEmail1.Text));
                    cmd.Parameters.AddWithValue("@t7", (CustEmail2.Text));
                    cmd.Parameters.AddWithValue("@t8", (Website.Text));
                    cmd.Parameters.AddWithValue("@t9", (OfficeNo.Text));
                    cmd.Parameters.AddWithValue("@t10", (BuildingName.Text));

                    cmd.Parameters.AddWithValue("@t11", (Address1.Text));
                    cmd.Parameters.AddWithValue("@t12", (Address2.Text));
                    cmd.Parameters.AddWithValue("@t13", (Landmark.Text));
                    cmd.Parameters.AddWithValue("@t14", decimal.Parse(Pincode.Text));
                    cmd.Parameters.AddWithValue("@t15", (City.Text));
                    cmd.Parameters.AddWithValue("@t16", (State.Text));
                    cmd.Parameters.AddWithValue("@t17", (Country.Text));
                    cmd.Parameters.AddWithValue("@t18", (ContactPersonName.Text));
                    cmd.Parameters.AddWithValue("@t19", (ContactPersonMobileNo.Text));
                    cmd.Parameters.AddWithValue("@t20", (ContactPersonEmailID.Text));
                    cmd.Parameters.AddWithValue("@t21", (Currency.Text));
                    cmd.Parameters.AddWithValue("@t22", (Cust_PAN_No.Text));
                    cmd.Parameters.AddWithValue("@t23", (Cust_GST_No.Text));

                    cmd.Parameters.AddWithValue("@t24", 11);
                    cmd.Parameters.AddWithValue("@t25", DateTime.Today);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Inserted");
                    string query = "select * from CustMaster";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(query, con);
                    dap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            string q = "update CustMaster set CustID=@t1,CustName=@t2,CustCategory=@t3,CustMobile1=@t4,CustMobile2=@t5,CustEmail1=@t6,CustEmail2=@t7,Website=@t8,OfficeNo=@t9,BuildingName=@t10,Address1=@t11,Address2=@t12,Landmark=@t13,Pincode=@t14,City=@t15,State=@t16,Country=@t17,ContactPersonName=@t18,ContactPersonMobileNo=@t19,ContactPersonEmailID=@t20,Currency=@t21,Cust_PAN_No=@t22, Cust_GST_No=@t23,EntryID=@t24,Timestamp=@t25 where CustID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", decimal.Parse(CustID.Text));
            cmd.Parameters.AddWithValue("@t2", (CustName.Text));
            cmd.Parameters.AddWithValue("@t3", (CustCategory.Text));
            cmd.Parameters.AddWithValue("@t4", decimal.Parse(CustMobile1.Text));
            cmd.Parameters.AddWithValue("@t5", (CustMobile2.Text));
            cmd.Parameters.AddWithValue("@t6", (CustEmail1.Text));
            cmd.Parameters.AddWithValue("@t7", (CustEmail2.Text));
            cmd.Parameters.AddWithValue("@t8", (Website.Text));
            cmd.Parameters.AddWithValue("@t9", (OfficeNo.Text));
            cmd.Parameters.AddWithValue("@t10", (BuildingName.Text));

            cmd.Parameters.AddWithValue("@t11", (Address1.Text));
            cmd.Parameters.AddWithValue("@t12", (Address2.Text));
            cmd.Parameters.AddWithValue("@t13", (Landmark.Text));
            cmd.Parameters.AddWithValue("@t14", decimal.Parse(Pincode.Text));
            cmd.Parameters.AddWithValue("@t15", (City.Text));
            cmd.Parameters.AddWithValue("@t16", (State.Text));
            cmd.Parameters.AddWithValue("@t17", (Country.Text));
            cmd.Parameters.AddWithValue("@t18", (ContactPersonName.Text));
            cmd.Parameters.AddWithValue("@t19", (ContactPersonMobileNo.Text));
            cmd.Parameters.AddWithValue("@t20", (ContactPersonEmailID.Text));
            cmd.Parameters.AddWithValue("@t21", (Currency.Text));
            cmd.Parameters.AddWithValue("@t22", (Cust_PAN_No.Text));
            cmd.Parameters.AddWithValue("@t23", (Cust_GST_No.Text));

            cmd.Parameters.AddWithValue("@t24", 11);
            cmd.Parameters.AddWithValue("@t25", DateTime.Today);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from CustMaster";

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
            string q = "delete from CustMaster where CustID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", int.Parse(CustID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
            string query = "select * from CustMaster";

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

            if (string.IsNullOrWhiteSpace(CustID.Text))
            {
                MessageBox.Show("Enter Customer ID");
            }
            else
            {
                decimal t1 = decimal.Parse(CustID.Text);
                string q = "select * from CustMaster where CustID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        CustID.Text = myreader["CustID"].ToString();
                        CustName.Text = myreader["CustName"].ToString();
                        CustCategory.Text = myreader["CustCategory"].ToString();
                        CustMobile1.Text = myreader["CustMobile1"].ToString();
                        CustMobile2.Text = myreader["CustMobile2"].ToString();

                        CustEmail1.Text = myreader["CustEmail1"].ToString();

                        CustEmail2.Text = myreader["CustEmail2"].ToString();

                        Website.Text = myreader["Website"].ToString();
                        OfficeNo.Text = myreader["OfficeNo"].ToString();

                        BuildingName.Text = myreader["BuildingName"].ToString();

                        Address1.Text = myreader["Address1"].ToString();
                        Address2.Text = myreader["Address2"].ToString();
                        Landmark.Text = myreader["Landmark"].ToString();

                        Pincode.Text = myreader["Pincode"].ToString();
                        City.Text = myreader["City"].ToString();

                        State.Text = myreader["State"].ToString();
                        Country.Text = myreader["Country"].ToString();

                        ContactPersonEmailID.Text = myreader["ContactPersonEmailID"].ToString();
                        ContactPersonMobileNo.Text = myreader["ContactPersonMobileNo"].ToString();
                        ContactPersonName.Text = myreader["ContactPersonName"].ToString();
                        Currency.Text = myreader["Currency"].ToString();

                        Cust_PAN_No.Text = myreader["Cust_PAN_No"].ToString();
                        Cust_GST_No.Text = myreader["Cust_GST_No"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Customer ID not found");
                }
            }
           
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void id_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustID.Text))
            {

                errorProvider1.SetError(CustID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(CustID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(CustID.Text))
                {
                    errorProvider1.SetError(CustID, "");
                }
                else
                {
                    errorProvider1.SetError(CustID, "Please Enter Valid Input!");
                }

            }

        }

        private void name_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustName.Text))
            {

                errorProvider1.SetError(CustName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(CustName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(CustName.Text))
                {
                    errorProvider1.SetError(CustName, "");
                }
                else
                {
                    errorProvider1.SetError(CustName, "Please Enter Valid Input!");
                }
            }
        }

        private void mobile_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustMobile1.Text))
            {
                errorProvider1.SetError(CustMobile1, "Enter Mobile Number!");
            }
            else
            {
                errorProvider1.SetError(CustMobile1, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(CustMobile1.Text))
                {
                    errorProvider1.SetError(CustMobile1, "");
                }
                else
                {
                    errorProvider1.SetError(CustMobile1, "Please Enter Valid Input!");
                }

            }
        }

        private void email_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustEmail1.Text))
            {
                errorProvider1.SetError(CustEmail1, "Enter Email!");
            }
            else
            {
                errorProvider1.SetError(CustEmail1, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(CustEmail1.Text))
                {
                    errorProvider1.SetError(CustEmail1, "");
                }
                else
                {
                    errorProvider1.SetError(CustEmail1, "Please Enter Valid Input!");
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

       

        private void gst_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cust_GST_No.Text))
            {
                errorProvider1.SetError(Cust_GST_No, "Enter GST Number!");
            }
            else
            {
                errorProvider1.SetError(Cust_GST_No, "");

                Regex r = new Regex("^^([0]{1}[1-9]{1}|[1-2]{1}[0-9]{1}|[3]{1}[0-7]{1})([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$");
                if (r.IsMatch(Cust_GST_No.Text))
                {
                    errorProvider1.SetError(Cust_GST_No, "");
                }
                else
                {
                    errorProvider1.SetError(Cust_GST_No, "Please Enter Valid Input!");
                }
            }
        }

        private void pan_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cust_PAN_No.Text))
            {
                errorProvider1.SetError(Cust_PAN_No, "Enter PAN Number!");
            }
            else
            {
                errorProvider1.SetError(Cust_PAN_No, "");

                Regex r = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
                if (r.IsMatch(Cust_PAN_No.Text))
                {
                    errorProvider1.SetError(Cust_PAN_No, "");
                }
                else
                {
                    errorProvider1.SetError(Cust_PAN_No, "Please Enter Valid Input!");
                }
            }
        }

        private void cp_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContactPersonName.Text))
            {
                errorProvider1.SetError(ContactPersonName, "");
            }
            else
            {
                errorProvider1.SetError(ContactPersonName, "");
                Regex r = new Regex("^[a-zA-Z ]+$");
                if (r.IsMatch(ContactPersonName.Text))
                {
                    errorProvider1.SetError(ContactPersonName, "");
                }
                else
                {
                    errorProvider1.SetError(ContactPersonName, "Please Enter Valid Input!");
                }

            }
        }

        private void cpmob_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContactPersonMobileNo.Text))
            {
                errorProvider1.SetError(ContactPersonMobileNo, "");
            }
            else
            {
                errorProvider1.SetError(ContactPersonMobileNo, "");
                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(ContactPersonMobileNo.Text))
                {
                    errorProvider1.SetError(ContactPersonMobileNo, "");
                }
                else
                {
                    errorProvider1.SetError(ContactPersonMobileNo, "Please Enter Valid Input!");
                }

            }
        }

        private void cpemail_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ContactPersonEmailID.Text))
            {
                errorProvider1.SetError(ContactPersonEmailID, "");
            }
            else
            {
                errorProvider1.SetError(ContactPersonEmailID, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(ContactPersonEmailID.Text))
                {
                    errorProvider1.SetError(ContactPersonEmailID, "");

                }
                else
                {
                    errorProvider1.SetError(ContactPersonEmailID, "Please Enter Valid Input!");
                }

            }
        }

        private void email2_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustEmail2.Text))
            {
                errorProvider1.SetError(CustEmail2, "");
            }
            else
            {
                errorProvider1.SetError(CustEmail2, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(CustEmail2.Text))
                {
                    errorProvider1.SetError(CustEmail2, "");
                }
                else
                {
                    errorProvider1.SetError(CustEmail2, "Please Enter Valid Input!");
                }
            }
        }

        private void mob2_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustMobile2.Text))
            {
                errorProvider1.SetError(CustMobile2, "");
            }
            else
            {
                errorProvider1.SetError(CustMobile2, "");
                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(CustMobile2.Text))
                {
                    errorProvider1.SetError(CustMobile2, "");
                }
                else
                {
                    errorProvider1.SetError(CustMobile2, "Please Enter Valid Input!");
                }

            }
        }

        private void cust_keydown(object sender, KeyEventArgs e)
        {
            if(e.Control==true && e.KeyCode==Keys.S)
            {
                Save_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

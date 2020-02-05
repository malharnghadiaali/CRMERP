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
    public partial class suppliermaster : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");

        public suppliermaster()
        {
            InitializeComponent();
        }
        private void suppliermaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
            errorProvider1.ContainerControl = this;
            con.Open();
            string query = "select * from SuppMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }



        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SuppID.Text) || string.IsNullOrWhiteSpace(SuppName.Text) || string.IsNullOrWhiteSpace(SuppMobile1.Text) || string.IsNullOrWhiteSpace(SuppEmail1.Text) || string.IsNullOrWhiteSpace(Pincode.Text) || string.IsNullOrWhiteSpace(Supp_PAN_No.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else 
            {

                con.Open();



                decimal t1 = decimal.Parse(SuppID.Text);
                string q = "select * from SuppMaster where SuppID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Supplier Code is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into SuppMaster values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t19,@t20,@t21,@t22,@t23,@t24,@t25,@t26)";

                    cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(SuppID.Text));
                    cmd.Parameters.AddWithValue("@t2", (SuppName.Text));
                    cmd.Parameters.AddWithValue("@t3", (SuppCategory.Text));
                    cmd.Parameters.AddWithValue("@t4", decimal.Parse(SuppMobile1.Text));
                    cmd.Parameters.AddWithValue("@t5", (SuppMobile2.Text));
                    cmd.Parameters.AddWithValue("@t6", (SuppEmail1.Text));
                    cmd.Parameters.AddWithValue("@t7", (SuppEmail2.Text));
                    cmd.Parameters.AddWithValue("@t8", (SuppWebsite.Text));
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
                    cmd.Parameters.AddWithValue("@t22", (CreditLimit.Text));
                    cmd.Parameters.AddWithValue("@t23", (Supp_PAN_No.Text));
                    cmd.Parameters.AddWithValue("@t24", (Supp_GST_No.Text));
                    cmd.Parameters.AddWithValue("@t25", (11));
                    cmd.Parameters.AddWithValue("@t26", DateTime.Today);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Inserted Successfully");
                    string query = "select * from SuppMaster";

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
            con.Open();
            string q = "update SuppMaster set SuppID=@t1,SuppName=@t2,SuppCategory=@t3,SuppMobile1=@t4,SuppMobile2=@t5,SuppEmail1=@t6,SuppEmail2=@t7,SuppWebsite=@t8,OfficeNo=@t9,BuildingName=@t10,Address1=@t11,Address2=@t12,Landmark=@t13,Pincode=@t14,City=@t15,State=@t16,Country=@t17,ContactPersonName=@t18,ContactPersonMobileNo=@t19,ContactPersonEmailID=@t20,Currency=@t21,CreditLimit=@t22,Supp_PAN_No=@t23, Supp_GST_No=@t24,EntryID=@t25,Timestamp=@t26 where SuppID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@t1", decimal.Parse(SuppID.Text));
            cmd.Parameters.AddWithValue("@t2", (SuppName.Text));
            cmd.Parameters.AddWithValue("@t3", (SuppCategory.Text));
            cmd.Parameters.AddWithValue("@t4", decimal.Parse(SuppMobile1.Text));
            cmd.Parameters.AddWithValue("@t5", (SuppMobile2.Text));
            cmd.Parameters.AddWithValue("@t6", (SuppEmail1.Text));
            cmd.Parameters.AddWithValue("@t7", (SuppEmail2.Text));
            cmd.Parameters.AddWithValue("@t8", (SuppWebsite.Text));
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
            cmd.Parameters.AddWithValue("@t22", (CreditLimit.Text));
            cmd.Parameters.AddWithValue("@t23", (Supp_PAN_No.Text));
            cmd.Parameters.AddWithValue("@t24", (Supp_GST_No.Text));
            cmd.Parameters.AddWithValue("@t25", (11));
            cmd.Parameters.AddWithValue("@t26", DateTime.Today);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from SuppMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            string q = "delete from SuppMaster where SuppID=@t1";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", int.Parse(SuppID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
            string query = "select * from SuppMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();




        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;

            con.Open();

            if (string.IsNullOrWhiteSpace(SuppID.Text))
            {
                MessageBox.Show("Enter Supplier ID");
            }
            else
            {
                decimal t1 = decimal.Parse(SuppID.Text);
                string q = "select * from SuppMaster where SuppID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        SuppID.Text = myreader["SuppID"].ToString();
                        SuppName.Text = myreader["SuppName"].ToString();
                        SuppCategory.Text = myreader["SuppCategory"].ToString();
                        SuppMobile1.Text = myreader["SuppMobile1"].ToString();
                        SuppMobile2.Text = myreader["SuppMobile2"].ToString();

                        SuppEmail1.Text = myreader["SuppEmail1"].ToString();

                        SuppEmail2.Text = myreader["SuppEmail2"].ToString();

                        SuppWebsite.Text = myreader["SuppWebsite"].ToString();
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
                        CreditLimit.Text = myreader["CreditLimit"].ToString();

                        Supp_PAN_No.Text = myreader["Supp_PAN_No"].ToString();
                        Supp_GST_No.Text = myreader["Supp_GST_No"].ToString();


                    }
                }
                else
                {
                    MessageBox.Show("Supplier ID not found");

                }
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }






        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void suppid_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SuppID.Text))
            {

                errorProvider1.SetError(SuppID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(SuppID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(SuppID.Text))
                {

                }
                else
                {
                    errorProvider1.SetError(SuppID, "Please Enter Valid Input!");
                }

            }

        }

        private void name_validator(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SuppName.Text))
            {

                errorProvider1.SetError(SuppName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(SuppName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(SuppName.Text))
                {

                }
                else
                {
                    errorProvider1.SetError(SuppName, "Please Enter Valid Input!");
                }
            }

        }

        private void pan_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Supp_PAN_No.Text))
            {

                errorProvider1.SetError(Supp_PAN_No, "Enter PAN Number!");
            }
            else
            {
                errorProvider1.SetError(Supp_PAN_No, "");

                Regex r = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
                if (r.IsMatch(Supp_PAN_No.Text))
                {
                    errorProvider1.SetError(Supp_PAN_No, "");

                    con.Open();
                    string t1 = (Supp_PAN_No.Text);
                    string q = "select * from SuppMaster where Supp_PAN_No='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("PAN ID is already taken");
                        errorProvider1.SetError(Supp_PAN_No, "PAN ID is already taken");
                        Supp_PAN_No.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(Supp_PAN_No, "");
                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(Supp_PAN_No, "Please Enter Valid Input!");
                }
            }
        }

        private void gst_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Supp_GST_No.Text))
            {

                errorProvider1.SetError(Supp_GST_No, "Enter GST Number!");
            }
            else
            {
                errorProvider1.SetError(Supp_GST_No, "");

                Regex r = new Regex("^^([0]{1}[1-9]{1}|[1-2]{1}[0-9]{1}|[3]{1}[0-7]{1})([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$");
                if (r.IsMatch(Supp_GST_No.Text))
                {
                    errorProvider1.SetError(Supp_GST_No, "");

                    con.Open();
                    string t1 = (Supp_GST_No.Text);
                    string q = "select * from SuppMaster where Supp_GST_No='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("GST is already taken");
                        errorProvider1.SetError(Supp_GST_No, "GST is already taken");
                        Supp_GST_No.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(Supp_GST_No, "");
                    }
                    con.Close();

                }
                else
                {
                    errorProvider1.SetError(Supp_GST_No, "Please Enter Valid Input!");
                }
            }

        }

        private void mob_validate(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SuppMobile1.Text))
            {

                errorProvider1.SetError(SuppMobile1, "Enter Mobile Number!");
            }
            else
            {
                errorProvider1.SetError(SuppMobile1, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(SuppMobile1.Text))
                {
                    errorProvider1.SetError(SuppMobile1, "");
                    con.Open();
                    decimal t1 = decimal.Parse(SuppMobile1.Text);
                    string q = "select * from SuppMaster where SuppMobile1='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("Mobile No is already taken");
                        errorProvider1.SetError(SuppMobile1, "Mobile No is already taken");
                        SuppMobile1.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(SuppMobile1, "");
                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(SuppMobile1, "Please Enter Valid Input!");
                }

            }
        }

        private void emai_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SuppEmail1.Text))
            {
                errorProvider1.SetError(SuppEmail1, "Enter Email!");
            }
            else
            {
                errorProvider1.SetError(SuppEmail1, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(SuppEmail1.Text))
                {
                    errorProvider1.SetError(SuppEmail1, "");

                    con.Open();
                    string t1 = (SuppEmail1.Text);
                    string q = "select * from SuppMaster where SuppEmail1='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("Email ID already taken");
                        errorProvider1.SetError(SuppEmail1, "Email ID is already taken");
                        SuppEmail1.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(SuppEmail1, "");
                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(SuppEmail1, "Please Enter Valid Input!");
                }
            }
        }

        private void pin_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Pincode.Text))
            {

                errorProvider1.SetError(Pincode, "Please Enter the Pincode!");

            }
            else
            {

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

        private void contactpersonname_validate(object sender, EventArgs e)
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



        private void contactpersonno_validate(object sender, EventArgs e)
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

        private void contactpersonemail_validate(object sender, EventArgs e)
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

        private void mob2_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SuppMobile2.Text))
            {
                errorProvider1.SetError(SuppMobile2, "");
            }
            else
            {
                errorProvider1.SetError(SuppMobile2, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(SuppMobile2.Text))
                {
                    errorProvider1.SetError(SuppMobile2, "");

                }
                else
                {
                    errorProvider1.SetError(SuppMobile2, "Please Enter Valid Input!");
                }

            }
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
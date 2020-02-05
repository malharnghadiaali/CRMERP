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
    public partial class employeemaster : Form
    {
        public employeemaster()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");

            con.Open();
            string Sql = "select distinct DeptName from DeptMaster";
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                EmpDept.Items.Add(DR[0]);

            }
            con.Close();
            con.Open();
            Sql = "select distinct DesigName from DesigMaster";
            cmd = new SqlCommand(Sql, con);
             DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                EmpDesignation.Items.Add(DR[0]);

            }
          
            con.Close();
            EmpFName.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);
            EmpMName.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);
            EmpLName.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);

        }
        void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");

        private void employeemaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
            con.Open();
            string query = "select * from EmpMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string q = "update EmpMaster set EmpID=@t1,EmpFName=@t2,EmpMName=@t3,EmpLName=@t4,EmpDOB=@t5,EmpMobileNo1=@t6,EmpMobileNo2=@t7,EmpEmailID1=@t8,EmpEmailID2=@t9,Address1=@t10,Address2=@t11,Landmark=@t12,Pincode=@t13,City=@t14,State=@t15,Country=@t16,EmpDept1=@t17,EmpDept2=@t18,EntryID=@t20,PAN_No=@t21,Aadhar_No=@t22 where EmpID=@t1";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@t1", decimal.Parse(EmpID.Text));
            cmd.Parameters.AddWithValue("@t2", (EmpFName.Text));
            cmd.Parameters.AddWithValue("@t3", (EmpMName.Text));
            cmd.Parameters.AddWithValue("@t4", (EmpLName.Text));
            cmd.Parameters.AddWithValue("@t5", (EmpDOB.Value.Date));
            cmd.Parameters.AddWithValue("@t6", decimal.Parse(EmpMobile1.Text));
            cmd.Parameters.AddWithValue("@t7", (EmpMobile2.Text));
            cmd.Parameters.AddWithValue("@t8", (EmpEmailID1.Text));
            cmd.Parameters.AddWithValue("@t9", (EmpEmailID2.Text));
            cmd.Parameters.AddWithValue("@t10", (Address1.Text));
            cmd.Parameters.AddWithValue("@t11", (Address2.Text));
            cmd.Parameters.AddWithValue("@t12", (Landmark.Text));
            cmd.Parameters.AddWithValue("@t13", decimal.Parse(Pincode.Text));
            cmd.Parameters.AddWithValue("@t14", (City.Text));
            cmd.Parameters.AddWithValue("@t15", (State.Text));
            cmd.Parameters.AddWithValue("@t16", (Country.Text));
            cmd.Parameters.AddWithValue("@t17", (EmpDept.Text));
            cmd.Parameters.AddWithValue("@t18", (EmpDesignation.Text));

            cmd.Parameters.AddWithValue("@t20", (11));
            cmd.Parameters.AddWithValue("@t21", (Emp_PAN_No.Text));
            cmd.Parameters.AddWithValue("@t22", decimal.Parse(Emp_Aadhar_No.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
            string query = "select * from EmpMaster";

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
            button7_Click(sender, e);
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpID.Text) || string.IsNullOrWhiteSpace(EmpFName.Text) || string.IsNullOrWhiteSpace(EmpDOB.Value.Date.ToString()) || string.IsNullOrWhiteSpace(EmpMobile1.Text) || string.IsNullOrWhiteSpace(EmpEmailID1.Text) || string.IsNullOrWhiteSpace(Pincode.Text) || string.IsNullOrWhiteSpace(Emp_Aadhar_No.Text) || string.IsNullOrWhiteSpace(Emp_PAN_No.Text))
            {
                MessageBox.Show("Enter Valid Record", "Error");
            }
            else
            {
                
                con.Open();

                decimal t1 = decimal.Parse(EmpID.Text);
                string q = "select * from EmpMaster where EmpID='" + @t1 + "'";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Employee ID is already taken", "Error");
                }
                else
                {
                    myreader.Close();
                    string q1 = "insert into EmpMaster values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@t11,@t12,@t13,@t14,@t15,@t16,@t17,@t18,@t20,@t21,@t22)";

                     cmd = new SqlCommand(q1, con);

                    cmd.Parameters.AddWithValue("@t1", decimal.Parse(EmpID.Text));
                    cmd.Parameters.AddWithValue("@t2", (EmpFName.Text));
                    cmd.Parameters.AddWithValue("@t3", (EmpMName.Text));
                    cmd.Parameters.AddWithValue("@t4", (EmpLName.Text));
                    cmd.Parameters.AddWithValue("@t5", (EmpDOB.Value.Date));
                    cmd.Parameters.AddWithValue("@t6", decimal.Parse(EmpMobile1.Text));
                    cmd.Parameters.AddWithValue("@t7", (EmpMobile2.Text));
                    cmd.Parameters.AddWithValue("@t8", (EmpEmailID1.Text));
                    cmd.Parameters.AddWithValue("@t9", (EmpEmailID2.Text));
                    cmd.Parameters.AddWithValue("@t10", (Address1.Text));
                    cmd.Parameters.AddWithValue("@t11", (Address2.Text));
                    cmd.Parameters.AddWithValue("@t12", (Landmark.Text));
                    cmd.Parameters.AddWithValue("@t13", decimal.Parse(Pincode.Text));
                    cmd.Parameters.AddWithValue("@t14", (City.Text));
                    cmd.Parameters.AddWithValue("@t15", (State.Text));
                    cmd.Parameters.AddWithValue("@t16", (Country.Text));
                    cmd.Parameters.AddWithValue("@t17", (EmpDept.Text));
                    cmd.Parameters.AddWithValue("@t18", (EmpDesignation.Text));

                    cmd.Parameters.AddWithValue("@t20", (11));
                    cmd.Parameters.AddWithValue("@t21", (Emp_PAN_No.Text));
                    cmd.Parameters.AddWithValue("@t22", decimal.Parse(Emp_Aadhar_No.Text));




                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Inserted");
                    string query = "select * from EmpMaster";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dap = new SqlDataAdapter(query, con);
                    dap.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    con.Close();
                }
            }


        }

       
        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            decimal t1 =decimal.Parse(EmpID.Text);

            string q = "select * from EmpMaster where EmpID='" + @t1 + "'";

            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader myreader = cmd.ExecuteReader();
            if (myreader.HasRows)
            {
                myreader.Close();
                q = "delete from EmpMaster where EmpID=@t1";
                cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@t1", int.Parse(EmpID.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted");

                EmpID.Text = "";
                EmpFName.Text = "";
                EmpMName.Text = "";
                EmpLName.Text = "";
                EmpDOB.Text = "";

                EmpMobile1.Text = "";

                EmpMobile2.Text = "";

                EmpEmailID1.Text = "";
                EmpEmailID2.Text = "";

                Address1.Text = "";

                Address2.Text = "";
                Landmark.Text = "";

                Pincode.Text = "";
                City.Text = "";
                State.Text = "";
                Country.Text = "";

                EmpDept.Text = "";
                EmpDesignation.Text = "";

                Emp_PAN_No.Text = "";
                Emp_Aadhar_No.Text = "";
                string query = "select * from EmpMaster";

                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(query, con);
                dap.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                
            }
            else
            {
                MessageBox.Show("Employee ID not found", "Error");

            }
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;

            con.Open();

            if (string.IsNullOrWhiteSpace(EmpID.Text))
            {
                MessageBox.Show("Enter Employee ID");
            }
            else
            {
                decimal t1 = decimal.Parse(EmpID.Text);
                string q = "select * from EmpMaster where EmpID='" + @t1 + "'";

                cmd = new SqlCommand(q, con);
                SqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        EmpID.Text = myreader["EmpID"].ToString();
                        EmpFName.Text = myreader["EmpFName"].ToString();
                        EmpMName.Text = myreader["EmpMName"].ToString();
                        EmpLName.Text = myreader["EmpLName"].ToString();
                        EmpDOB.Text = myreader["EmpDOB"].ToString();

                        EmpMobile1.Text = myreader["EmpMobileNo1"].ToString();

                        EmpMobile2.Text = myreader["EmpMobileNo2"].ToString();

                        EmpEmailID1.Text = myreader["EmpEmailID1"].ToString();
                        EmpEmailID2.Text = myreader["EmpEmailID2"].ToString();

                        Address1.Text = myreader["Address1"].ToString();

                        Address2.Text = myreader["Address2"].ToString();
                        Landmark.Text = myreader["Landmark"].ToString();

                        Pincode.Text = myreader["Pincode"].ToString();
                        City.Text = myreader["City"].ToString();

                        State.Text = myreader["State"].ToString();
                        Country.Text = myreader["Country"].ToString();

                        EmpDept.Text = myreader["EmpDept1"].ToString();
                        EmpDesignation.Text = myreader["EmpDept2"].ToString();

                        Emp_PAN_No.Text = myreader["PAN_No"].ToString();
                        Emp_Aadhar_No.Text = myreader["Aadhar_No"].ToString();





                    }
                }
                else
                {
                    MessageBox.Show("Employee ID not found");

                }
                con.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;

            con.Open();
            int t1 = int.Parse(EmpID.Text);
            string sql = "Select * from EmpMaster where EmpID='" + @t1 + "';";
            cmd = new SqlCommand(sql, con);
            
            using (SqlDataReader myreader = cmd.ExecuteReader())
            {
                myreader.NextResult();
                while (myreader.Read())
                {
                    EmpID.Text = myreader["EmpID"].ToString();
                    EmpFName.Text = myreader["EmpFName"].ToString();
                    EmpMName.Text = myreader["EmpMName"].ToString();
                    EmpLName.Text = myreader["EmpLName"].ToString();
                    EmpDOB.Text = myreader["EmpDOB"].ToString();

                    EmpMobile1.Text = myreader["EmpMobileNo1"].ToString();

                    EmpMobile2.Text = myreader["EmpMobileNo2"].ToString();

                    EmpEmailID1.Text = myreader["EmpEmailID1"].ToString();
                    EmpEmailID2.Text = myreader["EmpEmailID2"].ToString();

                    Address1.Text = myreader["Address1"].ToString();

                    Address2.Text = myreader["Address2"].ToString();
                    Landmark.Text = myreader["Landmark"].ToString();

                    Pincode.Text = myreader["Pincode"].ToString();
                    City.Text = myreader["City"].ToString();

                    State.Text = myreader["State"].ToString();
                    Country.Text = myreader["Country"].ToString();

                    EmpDept.Text = myreader["EmpDept1"].ToString();
                    EmpDesignation.Text = myreader["EmpDept2"].ToString();

                    Emp_PAN_No.Text = myreader["PAN_No"].ToString();
                    Emp_Aadhar_No.Text = myreader["Aadhar_No"].ToString();


                }
            }


                con.Close();


        }

        private void empid_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpID.Text))
            {

                errorProvider1.SetError(EmpID, "Please Enter the Value!");

            }
            else
            {
                errorProvider1.SetError(EmpID, "");
                Regex r = new Regex("^[0-9]+$");
                if (r.IsMatch(EmpID.Text))
                {
                    errorProvider1.SetError(EmpID, "");
                }
                else
                {
                    errorProvider1.SetError(EmpID, "Please Enter Valid Input!");
                }

            }
        }

        private void name_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpFName.Text))
            {

                errorProvider1.SetError(EmpFName, "Name should not be left blank!");
            }
            else
            {
                errorProvider1.SetError(EmpFName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(EmpFName.Text))
                {
                    errorProvider1.SetError(EmpFName, "");
                }
                else
                {
                    errorProvider1.SetError(EmpFName, "Please Enter Valid Input!");
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
                errorProvider1.SetError(Pincode, "");

                Regex r = new Regex("^[1-9][0-9]{5}$");
                if (r.IsMatch(Pincode.Text))
                {
                    errorProvider1.SetError(Pincode, "");

                    SqlCommand cmd;
                    SqlConnection con;

                    con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
                    con.Open();
                    decimal t1 = decimal.Parse(Pincode.Text);
                    string q = "select * from pincode where pincode='" + @t1 + "'";

                    cmd = new SqlCommand(q, con);
                    SqlDataReader myreader = cmd.ExecuteReader();
                    if (myreader.HasRows)
                    {
                        while (myreader.Read())
                        {
                            City.Text = myreader["city"].ToString();
                            State.Text = myreader["state"].ToString();
                            Country.Text = "India";

                        }
                    }
                    else
                    {
                        errorProvider1.SetError(Pincode, "Enter Proper Pincode");
                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(Pincode, "Please Enter Valid Input!");
                }

            }
        }

        private void mname_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpMName.Text))
            {
                errorProvider1.SetError(EmpMName, "");
            }
            else
            {
                errorProvider1.SetError(EmpMName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(EmpMName.Text))
                {
                    errorProvider1.SetError(EmpMName, "");
                }
                else
                {
                    errorProvider1.SetError(EmpMName, "Please Enter Valid Input!");
                }
            }
        }

        private void lname_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpLName.Text))
            {

                errorProvider1.SetError(EmpLName, "");
            }
            else
            {
                errorProvider1.SetError(EmpLName, "");

                Regex r = new Regex("^[a-z A-Z]+$");
                if (r.IsMatch(EmpLName.Text))
                {
                    errorProvider1.SetError(EmpLName, "");
                }
                else
                {
                    errorProvider1.SetError(EmpLName, "Please Enter Valid Input!");
                }
            }
        }

        private void pan_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Emp_PAN_No.Text))
            {

                errorProvider1.SetError(Emp_PAN_No, "Enter PAN Number!");
            }
            else
            {
                errorProvider1.SetError(Emp_PAN_No, "");

                Regex r = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
                if (r.IsMatch(Emp_PAN_No.Text))
                {
                    errorProvider1.SetError(Emp_PAN_No, "");

                    con.Open();
                    string t1 = (Emp_PAN_No.Text);
                    string q = "select * from EmpMaster where PAN_No='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if(d.HasRows)
                    {
                        MessageBox.Show("PAN ID is already taken");
                        errorProvider1.SetError(Emp_PAN_No, "PAN ID is already taken");
                        Emp_PAN_No.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(Emp_PAN_No, "");
                    }
                    con.Close();

                }
                else
                {
                    errorProvider1.SetError(Emp_PAN_No, "Please Enter Valid Input!");
                }
            }
        }

        private void adhar_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Emp_Aadhar_No.Text))
            {

                errorProvider1.SetError(Emp_Aadhar_No, "Enter Adhar card Number!");
            }
            else
            {
                errorProvider1.SetError(Emp_Aadhar_No, "");

                Regex r = new Regex("^[0-9]{12}$");
                if (r.IsMatch(Emp_Aadhar_No.Text))
                {
                    errorProvider1.SetError(Emp_Aadhar_No, "");


                    con.Open();
                    decimal t1 = decimal.Parse(Emp_Aadhar_No.Text);
                    string q = "select * from EmpMaster where Aadhar_No='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("Aadhar No is already taken");
                        errorProvider1.SetError(Emp_Aadhar_No, "Aadhar No is already taken");
                        Emp_Aadhar_No.Focus();

                    }
                    else
                    {
                        errorProvider1.SetError(Emp_Aadhar_No, "");
                    }
                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(Emp_Aadhar_No, "Please Enter Valid Input!");
                }
            }
        }

        private void mob1_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpMobile1.Text))
            {

                errorProvider1.SetError(EmpMobile1, "Enter Mobile Number!");
            }
            else
            {
                errorProvider1.SetError(EmpMobile1, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(EmpMobile1.Text))
                {
                    errorProvider1.SetError(EmpMobile1, "");
                    con.Open();
                    string t1 = (EmpMobile1.Text);
                    string q = "select * from EmpMaster where EmpMobileNo1='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("Mobile No is already taken");
                        errorProvider1.SetError(EmpMobile1, "Mobile No is already taken");
                        EmpMobile1.Focus();
                    }
                    else
                    {
                        errorProvider1.SetError(EmpMobile1, "");
                    }
                    con.Close();

                }
                else
                {
                    errorProvider1.SetError(EmpMobile1, "Please Enter Valid Input!");
                }

            }

        }

        private void mob2_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpMobile2.Text))
            {
                errorProvider1.SetError(EmpMobile2, "");
            }
            else
            {
                errorProvider1.SetError(EmpMobile2, "");

                Regex r = new Regex("^[6-9]{1}[0-9]{9}$");
                if (r.IsMatch(EmpMobile2.Text))
                {
                    errorProvider1.SetError(EmpMobile2, "");
                }
                else
                {
                    errorProvider1.SetError(EmpMobile2, "Please Enter Valid Input!");
                }

            }
        }

        private void email1_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpEmailID1.Text))
            {
                errorProvider1.SetError(EmpEmailID1, "Enter Email!");
            }
            else
            {
                errorProvider1.SetError(EmpEmailID1, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(EmpEmailID1.Text))
                {
                    errorProvider1.SetError(EmpEmailID1, "");

                    con.Open();
                    string t1 = (EmpEmailID1.Text);
                    string q = "select * from EmpMaster where EmpEmailID1='" + @t1 + "'";

                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.HasRows)
                    {
                        MessageBox.Show("Email ID is already taken");
                        errorProvider1.SetError(EmpEmailID1, "Email ID is already taken");
                        EmpEmailID1.Focus();

                    }
                    else
                    {
                        errorProvider1.SetError(EmpEmailID1, "");
                    }
                    con.Close();

                }
                else
                {
                    errorProvider1.SetError(EmpEmailID1, "Please Enter Valid Input!");
                }
            }
        }

        private void email2_validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmpEmailID2.Text))
            {
                errorProvider1.SetError(EmpEmailID2, "");
            }
            else
            {
                errorProvider1.SetError(EmpEmailID2, "");

                Regex r = new Regex("^[a-zA-Z0-9]+@[a-zA-Z_]+?.[a-zA-Z]{2,3}");
                if (r.IsMatch(EmpEmailID2.Text))
                {
                    errorProvider1.SetError(EmpEmailID2, "");
                }
                else
                {
                    errorProvider1.SetError(EmpEmailID2, "Please Enter Valid Input!");
                }
            }
        }

        private void hello(object sender, EventArgs e)
        {
           
        }

        private void DesigList(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }

        private void check(object sender, EventArgs e)
        {
            string year = EmpDOB.Value.Year.ToString();
            string ch= DateTime.Now.Year.ToString();
            int y = int.Parse(year);
            int c = int.Parse(ch);
            if ((c - y) < 14)
            {
                MessageBox.Show("Avoid Child Labour");
            }

        }


       
    }
}

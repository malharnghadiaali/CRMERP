using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRMERP
{
    public partial class loginform : Form
    {
        internal static string name;

        public loginform()
        {
            InitializeComponent();
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
          
            String username = bunifuMaterialTextbox1.Text.Trim();
            String pass = bunifuMaterialTextbox3.Text.Trim();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            string q = "Select * from LoginMaster where Username='" + @username + "' and Password='" + @pass + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader r = cmd.ExecuteReader();
         
            decimal id;
            if (r.HasRows)
            {
                while (r.Read())
                {
                    name = r["EmpName"].ToString();
                    id = (decimal)r["EmpID"];
                }
                this.Hide();
                home h = new home();
                h.Closed += (s, args) => this.Close();
                h.Show();
                

            }
            
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }

     
    }
}

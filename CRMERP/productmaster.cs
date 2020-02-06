using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMERP
{
    public partial class productmaster : Form
    {
        public productmaster()
        {
            InitializeComponent();
        }

        private void productmaster_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string imagelocation1 = "";

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                imagelocation1 = dialog.FileName.ToString();

                image.ImageLocation = imagelocation1;


            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            byte[] im = null;
            FileStream stream = new FileStream(imagelocation1,FileMode.Open,FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            im = brs.ReadBytes((int)stream.Length);

            //Image img = image.Image;
            //byte[] arr;
            //ImageConverter converter = new ImageConverter();
            //arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UPGUJCC\ROHANSQL;Initial Catalog=CRMERP;Integrated Security=True");
            con.Open();
            string q = "insert into ProductMaster values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,'" + im + "',@t11)";

            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@t1", decimal.Parse(ProductID.Text));
            cmd.Parameters.AddWithValue("@t2", (ProductName.Text));
            cmd.Parameters.AddWithValue("@t3", (ProductAlias.Text));
            cmd.Parameters.AddWithValue("@t4", ProductCategoryName.Text);
            cmd.Parameters.AddWithValue("@t5", UOM.Text);
            cmd.Parameters.AddWithValue("@t6", decimal.Parse(Rate.Text));
            cmd.Parameters.AddWithValue("@t7", decimal.Parse(ProductLength.Text));
            cmd.Parameters.AddWithValue("@t8", (decimal.Parse(ProductHeight.Text)));
            cmd.Parameters.AddWithValue("@t9", (decimal.Parse(Range.Text)));
            cmd.Parameters.AddWithValue("@t11", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Inserted");
            string query = "select CustID,CustName from CustMaster";

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
            decimal t1 = decimal.Parse(ProductID.Text);
            string q = "select * from ProductMaster where ProductID='" + @t1 + "'";
           

            cmd = new SqlCommand(q, con);
            SqlDataReader myreader = cmd.ExecuteReader();

           

            while (myreader.Read())
            {
                ProductID.Text = myreader["ProductID"].ToString();
                ProductName.Text = myreader["ProductName"].ToString();
                ProductCategoryName.Text = myreader["ProductCategoryName"].ToString();
                ProductAlias.Text = myreader["ProductAlias"].ToString();
                Rate.Text = myreader["Rate"].ToString();

                UOM.Text = myreader["UOM"].ToString();

                ProductLength.Text = myreader["ProductLength"].ToString();

                ProductHeight.Text = myreader["ProductHeight"].ToString();
                Range.Text = myreader["Range"].ToString();

                byte[] getImg = new byte[0];
                getImg = ((byte[])myreader["ProductImage"]);

                //image.Image = null;
                //MemoryStream stream = new MemoryStream(getImg);
                //image.Image = Image.FromStream(stream);

                //  string strbase64 = Convert.ToBase64String(getImg);

                // image.Image = strbase64;


                 MemoryStream stream = new MemoryStream(getImg);
                 Image RetImage = Image.FromStream(stream);
                 image.Image = RetImage;



            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);

            return img;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Closed += (s, args) => this.Close();
            h.Show();
        }
    }
    }



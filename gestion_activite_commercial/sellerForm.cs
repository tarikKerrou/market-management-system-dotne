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

namespace gestion_activite_commercial
{
    public partial class sellerForm : Form
    {
        public sellerForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            con.Open();
            string query = "select * from seller";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (catego_id.Text == "")
                {
                    MessageBox.Show("select product to delete");
                }
                else
                    con.Open();
                string query = "delete from seller where seller_id= " + seller_id.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                MessageBox.Show("seller deleted successfully");
                con.Close();
                populate();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (prod_id.Text == "" || prod_name.Text == "" || prod_qte.Text == "" || prod_price.Text == "" || prod_catego.Text == "")
                {
                    MessageBox.Show("please select categhor for update");
                }
                else
                {
                    con.Open();
                    string query = "update seller set seller_name='" + seller_name.Text + "'seller_age='" + seller_age.Text + "'seller_phone='" + seller_phone.Text + "'seller_pass='" + seller_pass + "'where product_id='" + prod_id + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("categhory edited suscessfully");
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace gestion_activite_commercial
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PEC0I1N\SQLEXPRESS;Integrated Security=True");


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into product values(" + prod_id.Text + ",'" + prod_name.Text + "','" + prod_qte.Text + "','"+prod_price.Text+ "','"+prod_catego+ "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("product added succesfully ");

                con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            con.Open();
            string query = "select * from product";
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
                if (prod_id.Text == "")
                {
                    MessageBox.Show("select product to delete");
                }
                else
                    con.Open();
                string query = "delete from product where product_id= " + prod_id.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                MessageBox.Show("product deleted successfully");
                con.Close();
                populate();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (prod_id.Text == "" || prod_name.Text == "" || prod_qte.Text == "" || prod_price.Text == "" ||prod_catego.Text == "")
                {
                    MessageBox.Show("please select categhor for update");
                }
                else
                {
                    con.Open();
                    string query = "update product set product_name='" + prod_name.Text + "'product_qte='" +prod_qte.Text + "'product_price='"+prod_price.Text+ "'product_cat='" +prod_catego +"'where product_id='" + prod_id + ";";
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

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}

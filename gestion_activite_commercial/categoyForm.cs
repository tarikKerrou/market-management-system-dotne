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
    public partial class categoyForm : Form
    {
        public categoyForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PEC0I1N\SQLEXPRESS;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into categhory values(" + catego_id.Text + ",'" + catego_name.Text + "','" + catego_desc.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("category added succesfully ");

                con.Close();
                populate();
            } 
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void catego_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void populate() 
        {
        con.Open();
            string query = "select * from categhory";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds=new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
        con.Close() ;
        }
        private void categoyForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catego_id.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            catego_name.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            catego_desc.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (catego_id.Text == "") 
                {
                    MessageBox.Show("select category to delete");
                }
                else 
                    con.Open();
                string query = "delete from category where Id_catego= " + catego_id.Text + "";
                SqlCommand cmd=new SqlCommand(query,con);
                MessageBox.Show("category deleted successfully");
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
                if (catego_id.Text == "" || catego_name.Text == "" || catego_desc.Text == "") {
                    MessageBox.Show("please select categhor for update");
                }
                else { 
                    con.Open();
                    string query = "update category set name_catego='" + catego_name.Text + "'description='" + catego_desc.Text + "'where Id_catego='" + catego_id + ";";
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


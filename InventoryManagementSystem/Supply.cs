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

namespace InventoryManagementSystem
{
    public partial class Supply : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Supply()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menu = new Menu();
            Menu.Show();
        }

        private void Supply_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            conn = connect.getConnect();
            conn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("EXEC DISPLAYALLSTOCKS", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("EXEC DISPLAYSPECIFICALLSTOCKS "+ textBox4.Text +" ;", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numericUpDown1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)|| string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please fill out the form to Register");
            }
            else
            {
                if (numericUpDown1.Text.Equals("0"))
                {
                    MessageBox.Show("Please indicate how much quantity of rice to be register");
                }
                else
                {
                    conn = connect.getConnect();
                    conn.Open();
                    dataGridView1.Rows.Clear();
                    cmd = new SqlCommand("EXEC RESTOCKSUPPLIES '" + textBox1.Text + "','" + textBox2.Text + "'," + numericUpDown1.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "' ;", conn);
                    cmd.ExecuteNonQuery();
                    load();

                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "")
            {
                numericUpDown1.Text = "0";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();
            cmd = new SqlCommand("Exec DELETEINVENTORY  " + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)+ ";", conn);

            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();

                MessageBox.Show("Inventory Id has been deleted!");

                load();
            }
            catch (Exception x)
            {
                MessageBox.Show("Inventory Id does not exist!");
                load();
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }


        }

        private void Supply_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Are you sure you want to exit off the application", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

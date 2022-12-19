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
    public partial class SupplyHistory : Form
    {

        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public SupplyHistory()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SupplyHistory_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menu = new Menu();
            Menu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Input Supplier Name First!");
            }
            else
            {
                conn = connect.getConnect();
                conn.Open();
                dataGridView1.Rows.Clear();
                cmd = new SqlCommand("EXEC DisplaySpecificHistorySupplier " + textBox1.Text + " ;", conn);
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }


                    MessageBox.Show("Search Successfully!");
                }
                catch(Exception x)
                {
                    MessageBox.Show("Error Exception!\n\n" + x.Message);
                    load();
                }

                finally
                {
                    dr.Close();
                    cmd.Dispose();
                    conn.Close();
                }

            }

        }

        private void load()
        {
            conn = connect.getConnect();
            conn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("EXEC DisplaySupplyHistory;", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SupplyHistory_FormClosing(object sender, FormClosingEventArgs e)
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

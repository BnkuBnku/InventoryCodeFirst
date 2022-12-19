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


    public partial class PurchaseHistory : Form
    {

        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public PurchaseHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menu = new Menu();
            Menu.ShowDialog();
        }

        private void PurchaseHistory_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            conn = connect.getConnect();
            conn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("EXEC DISPLAYALLPURCHASEHISTORY;", conn);
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
            cmd = new SqlCommand("EXEC DISPLAYALLSPECIFICPURCHASEHISTORY '"+textBox1.Text+"';", conn);

            try
            {
                dr = cmd.ExecuteReader();
                while(dr.Read()){
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
                }
            
                

                MessageBox.Show("Search Successfully!");
            }
            catch (Exception x)
            {
                MessageBox.Show("Enter Customer's Name First!" + x.Message);
                load();
            }
            finally
            { 
            dr.Close();
            cmd.Dispose();
            conn.Close();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PurchaseHistory_FormClosing(object sender, FormClosingEventArgs e)
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

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
    public partial class Purchase : Form
    {

        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        double price;

        public Purchase()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            conn = connect.getConnect();
            conn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("EXEC DISPLAYALLSTOCKS;", conn);
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
            cmd = new SqlCommand("EXEC DISPLAYSPECIFICALLSTOCKS " + textBox4.Text + " ;", conn);


            try
            {
                dr = cmd.ExecuteReader();

                dr.Read();
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);

                MessageBox.Show("Search Successfully!");
            }
            catch (Exception x)
            {
                MessageBox.Show("Please Input Inventory ID First");
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
            textBox4.Clear();
            load();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

                if (String.IsNullOrEmpty(P_customer_name.Text) || String.IsNullOrEmpty(P_cusomter_info.Text) || String.IsNullOrEmpty(P_numericQuantity.Text) ||
            String.IsNullOrEmpty(P_riceName.Text))
                {
                    MessageBox.Show("Please fill out the form before Add to Cart!");
                }
                else
                {
                    cmd = new SqlCommand("USE InventoryCodeFirst select inventories.quantity from dbo.inventories where inventories.riceRefID = (SELECT Id from dbo.rice where rice.rice_name = '" + P_riceName.Text + "') ", conn);
                    try
                    {
                        dr = cmd.ExecuteReader();

                        dr.Read();

                        int quan = Convert.ToInt32(dr[0].ToString()); //Get the Value

                        if (quan == 0)
                        {
                            MessageBox.Show("There's No Stock Available");
                        }
                        else
                        {
                            dataGridView2.Rows.Add(P_customer_name.Text, P_cusomter_info.Text, P_riceName.Text, P_numericQuantity.Text, P_total.Text);
                            MessageBox.Show("Succcessfully Added to Cart");
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Error Exception \n" + x.Message);
                    }
                    finally
                    {
                        dr.Close();
                        cmd.Dispose();
                        conn.Close();
                    }
                }
     
        }

     
        private void button5_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();
            
            cmd = new SqlCommand("select rice.riceother_info from dbo.rice where rice.rice_name LIKE '%' + '" + P_riceName.Text + "' + '%' ", conn);
            try
            {
                int quan;
                int.TryParse(P_numericQuantity.Text, out quan);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    price = double.Parse(dr[0].ToString());
                }

                double total = price * quan;

                P_total.Text = total.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error in Computation \n" + x.Message);
            }
            finally{
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void P_total_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void P_deletebtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                if (!row.IsNewRow) dataGridView2.Rows.Remove(row);
        }

        private void P_confirmbtn_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            SqlCommand cmd = new SqlCommand("BUYRICE", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Customer_name", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@Customer_info", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@rice_name", SqlDbType.VarChar));

            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Your Cart is Empty!");
            }
            else
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@Customer_name"].Value = row.Cells[0].Value;
                            cmd.Parameters["@Customer_info"].Value = row.Cells[1].Value;
                            cmd.Parameters["@quantity"].Value = row.Cells[3].Value;
                            cmd.Parameters["@rice_name"].Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                        }
                       
                    }


                    MessageBox.Show("Confirm Successfuly");
                    
                    dataGridView2.Rows.Clear();

                }
                catch (Exception x)
                {
                    MessageBox.Show("Exception Error \n\n" + x.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    load();
                }
            }
        }

        private void Purchase_FormClosing(object sender, FormClosingEventArgs e)
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

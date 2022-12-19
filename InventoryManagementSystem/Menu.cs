using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supply Supply = new Supply();
            Supply.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase Purchase = new Purchase();
            Purchase.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PurchaseHistory PurchaseHistory = new PurchaseHistory();
            PurchaseHistory.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplyHistory SupplyHistory = new SupplyHistory();
            SupplyHistory.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit off the application", "Are you sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
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

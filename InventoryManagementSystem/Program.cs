using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace InventoryManagementSystem
{
    public class customer
    {
        public int Id { get; set; }
        public string customer_name { get; set; }
        public string customer_info { get; set; }

        public ICollection<purchase> purchase { get; set; }
    }

    public class inventory
    {
        public int Id { get; set; }
        public int quantity { get; set; }

        [ForeignKey("rice")]
        public int riceRefID { get; set; }
        public rice rice { get; set; }

        public ICollection<purchase> purchase { get; set; }
        public ICollection<supply> supply { get; set; }

    }

    public class purchase
    {
        public int Id { get; set; }
        public string purchase_date { get; set; }

        [ForeignKey("customer")]
        public int customerRefID { get; set; }
        public customer customer { get; set; }


        public int quantity { get; set; }


        [ForeignKey("inventory")]
        public int inventoryRefID { get; set; }
        public inventory inventory { get; set; }
    }

    public class rice
    {
        public int Id { get; set; }
        public string rice_name { get; set; }
        public decimal riceother_info { get; set; }

        public ICollection<inventory> inventory { get; set; }
    }

    public class supplier
    {
        public int Id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_company { get; set; }

        public ICollection<supply> supply { get; set; }
    }

    public class supply
    {
        public int Id { get; set; }
        public string supply_date { get; set; }

        [ForeignKey("supplier")]
        public int supplierRefID { get; set; }
        public supplier supplier { get; set; }

        [ForeignKey("inventory")]
        public int inventoryRefID { get; set; }
        public inventory inventory { get; set; }
    }

    public class supplyhistorylog
    {
        public int Id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_company { get; set; }
        public string supply_date { get; set; }
        public int quantity { get; set; }
        public string rice_name { get; set; }
        public decimal riceother_info { get; set; }
    }

    public class InventoryDbContext : DbContext
    {
        public DbSet<customer> customer { get; set; }
        public DbSet<inventory> inventory { get; set; }
        public DbSet<purchase> purchase { get; set; }
        public DbSet<rice> rice { get; set; }
        public DbSet<supplier> supplier { get; set; }
        public DbSet<supply> supply { get; set; }
        public DbSet<supplyhistorylog> supplyhistorylog { get; set; }
      }
        static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}

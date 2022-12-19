using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    class Connection
    {

        SqlConnection conn;

        public SqlConnection getConnect()
        {
            conn = new SqlConnection("Data Source=DESKTOP-R3P2SAF\\SQLEXPRESS;Initial Catalog=InventoryCodeFirst;Integrated Security=True");
            return conn;
        }
    }
}

using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Diákkezelõ
{
    static class Program
    {
        public static SqlConnection DbConnection = new SqlConnection(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DiakDB;Integrated Security=True");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}

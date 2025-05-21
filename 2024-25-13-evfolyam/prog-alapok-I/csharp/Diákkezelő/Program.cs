using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diákkezelõ
{
    internal static class Program
    {
        // Globális, mindenhol elérhetõ MySQL kapcsolat
        public static MySqlConnection DbConnection;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connStr = "Server=localhost;Database=adatbazisnev;Uid=root;Pwd=;";
            DbConnection = new MySqlConnection(connStr);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Reg());

            DbConnection.Dispose();
        }
    }
}

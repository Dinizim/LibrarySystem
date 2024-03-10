using Library_System.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public class LibrarySystem
    {
        public static void LoadDB()
        {
            DALlibrarySystem.CreateSQL();
        }
        public static DataTable ShowData()
        {
            DataTable dt = new DataTable();
            dt = DALlibrarySystem.GetBooks();
            return dt;
        }


        public static string UUID_Generate()
        {
            return Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
        }
    }
}

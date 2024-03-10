using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }
        
        private void LoadDB(object sender, EventArgs e)
        {
            LibrarySystem.LoadDB();
            ShowBooks();
        }
        private void ShowBooks()
        {
            DataTable dt = new DataTable();
            dt = LibrarySystem.ShowData();
            BookView.DataSource = dt;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            InsertBookForm form = new InsertBookForm();
            form.ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}

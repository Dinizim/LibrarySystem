using Library_System.DAL;
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

       
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            ShowBooks();
        }

        private void BookView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idbook = BookView.Rows[e.RowIndex].Cells["Cod"].Value.ToString();
            string Name = BookView.Rows[e.RowIndex].Cells["NameBook"].Value.ToString();
            string Author = BookView.Rows[e.RowIndex].Cells["Author"].Value.ToString();
            string Gender = BookView.Rows[e.RowIndex].Cells["Gender"].Value.ToString();

            if (BookView.Columns[e.ColumnIndex] == BookView.Columns["Edit"])
            {
                EditBookForm form = new EditBookForm();
                form.BookID = idbook;
                form.Gender = Gender;
                form.Name = Name;
                form.Author = Author;
                form.ShowDialog();
                
            }
            if (BookView.Columns[e.ColumnIndex] == BookView.Columns["Delete"])
            {
                if(MessageBox.Show("Do you want to delete book?","delete book", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DALlibrarySystem.DeleteBook(idbook);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string NameBook = txt_search.Text;
            DataTable dt = new DataTable();
            dt = DALlibrarySystem.GetBook(NameBook);
            BookView.DataSource = dt;
        }
    }
}

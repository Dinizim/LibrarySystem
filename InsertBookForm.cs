using Library_System.DAL;
using Library_System.Entities;
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
    public partial class InsertBookForm : Form
    {
        public InsertBookForm()
        {
            InitializeComponent();
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            Book book = new Book(txtName.Text, txtAuthor.Text, txtGender.Text, txtComboBox.Text);
            DALlibrarySystem.AddBooks(book);
            this.Close();

        }

        private void Clear_btn_Click_1(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAuthor.Clear();
            txtGender.Clear();
            txtComboBox.Text = string.Empty;
        }
    }
}

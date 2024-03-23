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
    public partial class EditBookForm : Form
    {
        public string BookID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Gender { get; set; }
        public EditBookForm()
        {
            InitializeComponent();
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtComboBox.Text = "Available";
            txtAuthor.Text = Author;
            txtGender.Text = Gender;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Book book = new Book(txtName.Text, txtAuthor.Text, txtGender.Text, txtComboBox.Text);
            DALlibrarySystem.UptadeBook(BookID,book);
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

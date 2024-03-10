using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System.Entities
{
    public class Book
    {
        public string NameBook { get; set; }
        public string AuthorBook { get; set; }
        public string GenderBook { get; set; }
        public string Cod { get; set; }
        public string Status { get; set; }

        public Book(string nameBook, string authorBook, string genderBook, string status)
        {
            NameBook = nameBook;
            AuthorBook = authorBook;
            GenderBook = genderBook;
            Cod = LibrarySystem.UUID_Generate();
            Status = status;
        }
    }
}

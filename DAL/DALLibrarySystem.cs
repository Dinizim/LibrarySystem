using Library_System.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System.DAL
{
    public class DALlibrarySystem
    {
        public static string path = Directory.GetCurrentDirectory() + "\\books.sqlite";
        private static SQLiteConnection sqliteconnection;

        private static SQLiteConnection DbConnection()
        {
            sqliteconnection = new SQLiteConnection("Data Source=" + path);
            sqliteconnection.Open();
            return sqliteconnection;


        }
        public static void CreateSQL()
        {
            try
            {
                if (File.Exists(path) == false)
                    SQLiteConnection.CreateFile(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Books(Name Varchar(100),Author Varchar(50), Gender Varchar(15), Cod Varchar(5), Status Varchar(20))";
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddBooks(Book book)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Books (Name, Author, Gender, Cod, Status) values (@Name, @Author, @Gender, @Cod, @Status )";
                    cmd.Parameters.AddWithValue("@Name", book.NameBook);
                    cmd.Parameters.AddWithValue("@Author", book.AuthorBook);
                    cmd.Parameters.AddWithValue("@Gender", book.GenderBook);
                    cmd.Parameters.AddWithValue("@Cod", book.Cod);
                    cmd.Parameters.AddWithValue("@Status", book.Status);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetBooks()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Books";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBook(string Namebook)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Books WHERE Name = @Name";
                    cmd.Parameters.AddWithValue("@Name", Namebook);

                    da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                  
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UptadeBook(string IDbook,Book EditBook)
        {
            try{
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "Update Books SET Name=@Name, Author=@Author, Gender =@Gender WHERE Cod=@Cod" ;
                    cmd.Parameters.AddWithValue("@Cod", IDbook);
                    cmd.Parameters.AddWithValue("@Name", EditBook.NameBook);
                    cmd.Parameters.AddWithValue("@Author", EditBook.AuthorBook);
                    cmd.Parameters.AddWithValue("@Gender", EditBook.GenderBook);
                    cmd.ExecuteNonQuery();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteBook(string IDbook)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Books WHERE Cod=@Cod";
                    cmd.Parameters.AddWithValue("@Cod", IDbook);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

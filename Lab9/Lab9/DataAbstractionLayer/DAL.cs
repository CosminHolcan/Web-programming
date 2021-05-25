using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lab9.Models;
using MySql.Data.MySqlClient;

namespace Lab9.DataAbstractionLayer
{
    public class DAL
    {
        public List<Book> getBooks(string author, string genre)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;


            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            List<Book> books = new List<Book>();
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText;
                if (author != "" && genre != "")
                {
                    commandText = "select * from books where author = @author and genre = @genre";
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@genre", genre);
                }
                else if (genre != "")
                {
                    commandText = "select * from books where genre = @genre";
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddWithValue("@genre", genre);
                }
                else if(author != "")
                {
                    commandText = "select * from books where author = @author";
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddWithValue("@author", author);
                }
                else
                {
                    commandText = "select * from books";
                    cmd.Connection = conn;
                    cmd.CommandText = commandText;
                }
                MySqlDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    Book book = new Book();
                    book.id = myreader.GetInt32("id");
                    book.author = myreader.GetString("author");
                    book.title = myreader.GetString("title");
                    book.pages = myreader.GetInt32("pages");
                    book.lended = myreader.GetString("lended");
                    book.genre = myreader.GetString("genre");
                    books.Add(book);
                }
                myreader.Close();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return books;
        }

        internal bool login(string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "select * from users where username = @username and password = @password";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader myreader = cmd.ExecuteReader();
                int cnt = 0;
                while (myreader.Read())
                {
                    cnt++;
                }
                conn.Close();
                return cnt == 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        internal bool updateBook(int id, int pages, string genre, string lended)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "update books set pages = @pages, genre = @genre, lended = @lended where id = @id";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pages", pages);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@lended", lended);
                int cnt = cmd.ExecuteNonQuery();
                conn.Close();
                return cnt == 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        internal Book getOneBook(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            Book book = new Book();

            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "select * from books where id = @id";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader myreader = cmd.ExecuteReader();
                myreader.Read();
                book.id = myreader.GetInt32("id");
                book.author = myreader.GetString("author");
                book.title = myreader.GetString("title");
                book.pages = myreader.GetInt32("pages");
                book.lended = myreader.GetString("lended");
                book.genre = myreader.GetString("genre");
                conn.Close();
                return book;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return book;
            }
        }

        internal bool deleteBook(int id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "delete from books where id = @id";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@id", id);
                int cnt = cmd.ExecuteNonQuery();
                conn.Close();
                return cnt == 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        internal bool addBook(Book book)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = booklibrary; ";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                string commandText = "insert into books(author, title, pages, genre, lended) VALUES (@author, @title, @pages, @genre, @lended)";
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@author", book.author);
                cmd.Parameters.AddWithValue("@title", book.title);
                cmd.Parameters.AddWithValue("@pages", book.pages);
                cmd.Parameters.AddWithValue("@genre", book.genre);
                cmd.Parameters.AddWithValue("@lended", book.lended);
                int cnt = cmd.ExecuteNonQuery();
                conn.Close();
                return cnt == 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
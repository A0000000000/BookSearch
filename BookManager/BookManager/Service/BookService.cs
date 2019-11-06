using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Dao;
using BookManager.Domain;

namespace BookManager.Service
{
    public class BookService
    {
        private BookService() { }

        public static BookService NewInstance()
        {
            return obj ?? (obj = new BookService());
        }
        public Book GetBookByBookName(string bookName)
        {
            return bookDao.QueryBookByBookName(bookName);
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            return bookDao.QueryBooksByAuthorId(author.Id);
        }

        public List<Book> GetBooks(string[] inputs)
        {
            List<Book> result = new List<Book>();
            foreach (string str in inputs)
            {
                Book book = bookDao.QueryBookByBookName(str);
                if (book != null)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public List<Book> GetBooksByPublisher(Publisher publisher)
        {
            return bookDao.QueryBooksByPublisherId(publisher.Id);
        }

        private static BookService obj = new BookService();
        private BookDao bookDao = BookDao.NewInstance();
        private AuthorDao authorDao = AuthorDao.NewInstance();

        public List<Book> GetBlurBooks(string[] inputs)
        {
            List<Book> res = new List<Book>();
            foreach (string str in inputs)
            {
                List<Book> books = bookDao.QueryBlurBookByBookName(str);
                if (books != null)
                {
                    foreach (Book book in books)
                    {
                        if (book != null)
                        {
                            res.Add(book);
                        }
                    }
                }
            }
            return res;
        }
    }
}
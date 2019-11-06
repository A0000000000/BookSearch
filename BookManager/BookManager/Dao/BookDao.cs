using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Domain;
using BookManager.Utils;

namespace BookManager.Dao
{
    public class BookDao
    {
        private BookDao() { }

        public static BookDao NewInstance()
        {
            return obj ?? (obj = new BookDao());
        }
        public Book QueryBookByBookName(string bookName)
        {
            List<Book> books = ORMUtils.GetBeans(new Book(){BookName = bookName});
            return books != null && books.Count > 0 ? books[0] : null;
        }

        public List<Book> QueryBooksByAuthorId(string authorId)
        {
            return ORMUtils.GetBeans(new Book() {Author = authorId});
        }

        public List<Book> QueryBooksByPublisherId(string publisherId)
        {
            return ORMUtils.GetBeans(new Book() {Publisher = publisherId});
        }

        private static BookDao obj = new BookDao();

        public List<Book> QueryBlurBookByBookName(string str)
        {
            return ORMUtils.GetBeans(new Book() {BookName = str}, true);
        }
    }
}
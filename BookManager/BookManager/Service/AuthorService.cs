using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Dao;
using BookManager.Domain;

namespace BookManager.Service
{
    public class AuthorService
    {
        private AuthorService() { }

        public static AuthorService NewInstance()
        {
            return obj ?? (obj = new AuthorService());
        }

        public Author GetAuthorByAuthorName(string authorName)
        {
            return authorDao.QueryAuthorByAuthorName(authorName);
        }

        public Author GetAuthorByBook(Book book)
        {
            return authorDao.QueryAuthorByAuthorId(book.Author);
        }


        private static AuthorService obj = new AuthorService();
        private AuthorDao authorDao = AuthorDao.NewInstance();

        public List<Author> GetAuthors(string[] inputs)
        {
            List<Author> result = new List<Author>();
            foreach (string str in inputs)
            {
                Author author = authorDao.QueryAuthorByAuthorName(str);
                if (author != null)
                {
                    result.Add(author);
                }
            }
            return result;
        }

        public Author GetAuthorById(string authorId)
        {
            return authorDao.QueryAuthorByAuthorId(authorId);
        }

        public List<Author> GetBlurAuthors(string[] inputs)
        {
            List<Author> res = new List<Author>();
            foreach (string str in inputs)
            {
                List<Author> authors = authorDao.QueryBlurAuthorByAuthorName(str);
                if (authors != null)
                {
                    foreach (Author author in authors)
                    {
                        if (author != null)
                        {
                            res.Add(author);
                        }
                    }
                }
            }
            return res;
        }
    }
}
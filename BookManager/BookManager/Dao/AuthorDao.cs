using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Domain;
using BookManager.Utils;

namespace BookManager.Dao
{
    public class AuthorDao
    {
        private AuthorDao() { }

        public static AuthorDao NewInstance()
        {
            return obj ?? (obj = new AuthorDao());
        }

        public Author QueryAuthorByAuthorName(string authorName)
        {
            List<Author> list = ORMUtils.GetBeans(new Author(){AuthorName = authorName});
            return list != null && list.Count > 0 ? list[0] : null;
        }

        public Author QueryAuthorByAuthorId(string authorId)
        {
            List<Author> list = ORMUtils.GetBeans(new Author(){Id = authorId});
            return list != null && list.Count > 0 ? list[0] : null;
        }

        private static AuthorDao obj = new AuthorDao();

        public List<Author> QueryBlurAuthorByAuthorName(string str)
        {
            return ORMUtils.GetBeans(new Author() {AuthorName = str}, true);
        }
    }
}
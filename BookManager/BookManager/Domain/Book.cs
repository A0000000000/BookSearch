using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Domain
{
    public class Book
    {
        public string Id
        {
            get => id;
            set => id = value;
        }
        public string BookName
        {
            get => bookName;
            set => bookName = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public string Publisher
        {
            get => publisher;
            set => publisher = value;
        }


        private String id;
        private String bookName;
        private String author;
        private String publisher;
    }
}
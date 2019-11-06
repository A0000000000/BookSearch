using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Domain
{    
    public class Author
    {       
        public string Id
        {
            get => id;
            set => id = value;
        }

        public string AuthorName
        {
            get => authorName;
            set => authorName = value;
        }

        private String id;
        private String authorName;
    }
}
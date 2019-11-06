using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Domain
{
    public class Publisher
    {        
        public string Id
        {
            get => id;
            set => id = value;
        }

        public string PublisherName
        {
            get => publisherName;
            set => publisherName = value;
        }

        private String id;
        private String publisherName;
    }
}
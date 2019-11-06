using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Dao;
using BookManager.Domain;

namespace BookManager.Service
{
    public class PublisherService
    {
        private PublisherService() { }

        public static PublisherService NewInstance()
        {
            return obj ?? (obj = new PublisherService());
        }

        public Publisher GetPublisherByPublisherName(string publisherName)
        {
            return publisherDao.QueryPublisherByPublisherName(publisherName);
        }

        public Publisher GetPublisherByBook(Book book)
        {
            return publisherDao.GetPublisherByPublisherId(book.Publisher);
        }

        private static PublisherService obj = new PublisherService();
        private PublisherDao publisherDao = PublisherDao.NewInstance();

        public List<Publisher> GetPublishers(params string[] inputs)
        {
            List<Publisher> result = new List<Publisher>();
            foreach (string str in inputs)
            {
                Publisher publisher = publisherDao.QueryPublisherByPublisherName(str);
                if (publisher != null)
                {
                    result.Add(publisher);
                }
            }
            return result;
        }

        public Publisher GetPublisherById(string publisherId)
        {
            return publisherDao.GetPublisherByPublisherId(publisherId);
        }

        public List<Publisher> GetBlurPublisherByPublisherName(string[] inputs)
        {
            List<Publisher> res = new List<Publisher>();
            foreach (string str in inputs)
            {
                List<Publisher> publishers = publisherDao.QueryBlurPublisherByPublisherName(str);
                if (publishers != null)
                {
                    foreach (Publisher publisher in publishers)
                    {
                        if (publisher != null)
                        {
                            res.Add(publisher);
                        }
                    }
                }
            }
            return res;
        }
    }
}
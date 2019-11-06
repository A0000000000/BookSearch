using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManager.Domain;
using BookManager.Utils;

namespace BookManager.Dao
{
    public class PublisherDao
    {
        private PublisherDao() { }

        public static PublisherDao NewInstance()
        {
            return obj ?? (obj = new PublisherDao());
        }

        public Publisher QueryPublisherByPublisherName(string publisherName)
        {
            List<Publisher> list = ORMUtils.GetBeans(new Publisher(){PublisherName = publisherName});
            return list != null && list.Count > 0 ? list[0] : null;
        }

        public Publisher GetPublisherByPublisherId(string publisherId)
        {
            List<Publisher> list = ORMUtils.GetBeans(new Publisher() {Id = publisherId});
            return list != null && list.Count > 0 ? list[0] : null;
        }

        
        private static PublisherDao obj = new PublisherDao();

        public List<Publisher> QueryBlurPublisherByPublisherName(string str)
        {
            return ORMUtils.GetBeans(new Publisher() {PublisherName = str}, true);
        }
    }
}
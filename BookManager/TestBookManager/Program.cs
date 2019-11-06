using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManager.Domain;
using BookManager.Utils;

namespace TestBookManager
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<Author> list = ORMUtils.GetBeans<Author>();
            foreach (Author author in list)
            {
                Console.WriteLine(author.Id + " " + author.AuthorName);
            }
            Console.WriteLine("=============");
            list = ORMUtils.GetBeans(new Author() {AuthorName = "%0"}, true);
            foreach (Author author in list)
            {
                Console.WriteLine(author.Id + " " + author.AuthorName);
            }
            Console.WriteLine("=============");
            List<Publisher> beans = ORMUtils.GetBeans<Publisher>();
            foreach (Publisher bean in beans)
            {
                Console.WriteLine(bean.Id + " " + bean.PublisherName);
            }
            Console.WriteLine("=============");
            beans = ORMUtils.GetBeans(new Publisher() {Id = "2"});
            foreach (Publisher bean in beans)
            {
                Console.WriteLine(bean.Id + " " + bean.PublisherName);
            }
            Console.ReadKey();
        }
    }
}

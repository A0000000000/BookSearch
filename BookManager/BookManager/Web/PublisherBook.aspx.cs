using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookManager.Domain;
using BookManager.Service;

namespace BookManager.Web
{
    public partial class PublisherBook : BasePage
    {
        private BookService bookService = BookService.NewInstance();
        private AuthorService authorService = AuthorService.NewInstance();
        private PublisherService publisherService = PublisherService.NewInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            string publisherId = Request.Params["publisherId"];
            Publisher publisher =  publisherService.GetPublisherById(publisherId);
            List<Book> books = bookService.GetBooksByPublisher(publisher);
            Literal literal = new Literal() { Text = @"<h4>该出版社的书</h4>" };
            Result.Controls.Add(literal);
            foreach (Book book in books)
            {
                Literal bookLiteral = new Literal();
                bookLiteral.Text = $"书名: {book.BookName}, 作者: {authorService.GetAuthorByBook(book)?.AuthorName}, 出版社: {publisher?.PublisherName}<br/>";
                Result.Controls.Add(bookLiteral);
            }
        }
    }
}
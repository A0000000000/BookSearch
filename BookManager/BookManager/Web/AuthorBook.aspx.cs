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
    public partial class AuthorBook : BasePage
    {
        private BookService bookService = BookService.NewInstance();
        private AuthorService authorService = AuthorService.NewInstance();
        private PublisherService publisherService = PublisherService.NewInstance(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            string authorId = Request.Params["authorId"];
            Author author =  authorService.GetAuthorById(authorId);
            List<Book> books = bookService.GetBooksByAuthor(author);
            Literal literal = new Literal(){Text = @"<h4>该作者的书</h4>"};
            Result.Controls.Add(literal);
            foreach (Book book in books)
            {
                Literal bookLiteral = new Literal();
                bookLiteral.Text = $"书名: {book.BookName}, 作者: {author?.AuthorName}, 出版社: {publisherService.GetPublisherByBook(book)?.PublisherName}<br/>";
                Result.Controls.Add(bookLiteral);
            }
        }
    }
}
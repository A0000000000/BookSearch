using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Web.UI.WebControls;
using BookManager.Domain;
using BookManager.Service;

namespace BookManager.Web
{
    public partial class Index : BasePage
    {
        private BookService bookService = BookService.NewInstance();
        private AuthorService authorService = AuthorService.NewInstance();
        private PublisherService publisherService = PublisherService.NewInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Search.Click += (searchSender, searchE) =>
            {
                string[] inputs = inputMessage.Text.Trim().Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                string type = SearchType.Text.Trim();
                if ("Book".Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    Literal title = new Literal();
                    title.Text = @"<h3>查询到书的结果</h3>";
                    Result.Controls.Add(title);
                    List<Book> books = bookService.GetBooks(inputs);
                    foreach (Book book in books)
                    {
                        Literal literal = new Literal();
                        literal.Text = $"书名: {book.BookName}, 作者: {authorService.GetAuthorByBook(book)?.AuthorName}, 出版社: {publisherService.GetPublisherByBook(book)?.PublisherName}<br/>";
                        Result.Controls.Add(literal);
                    }
                }
                else if("Author".Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    Literal title = new Literal();
                    title.Text = @"<h3>查询到作者的结果</h3>";
                    List<Author> authors = authorService.GetAuthors(inputs);
                    foreach (Author author in authors)
                    {
                        Literal literal = new Literal();
                        literal.Text = $"作者: {author.AuthorName}, 写了{bookService.GetBooksByAuthor(author)?.Count}本书, <a href='AuthorBook.aspx?authorId=" + author.Id + $"' target='_blank'>查看该作者的书</a>";
                        Result.Controls.Add(literal);
                        Result.Controls.Add(new Literal(){Text = @"<br/>"});
                    }
                }
                else if ("Publisher".Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    Literal title = new Literal();
                    title.Text = @"<h3>查询到出版社的结果</h3>";
                    List<Publisher> publishers = publisherService.GetPublishers(inputs);
                    foreach (Publisher publisher in publishers)
                    {
                        Literal literal = new Literal();
                        literal.Text = $"出版设: {publisher.PublisherName}, 出版了{bookService.GetBooksByPublisher(publisher)?.Count}本书, <a href='PublisherBook.aspx?publisherId=" + publisher.Id + $"' target='_blank'>查看该出版社的书</a>";
                        Result.Controls.Add(literal);
                        Result.Controls.Add(new Literal() { Text = @"<br/>" });
                    }
                }
                else
                {
                    Session.Add("input", inputs);
                    Response.Redirect("All.aspx");
                }
            };
        }
        

    }
}
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
    public partial class All : BasePage
    {
        private BookService bookService = BookService.NewInstance();
        private AuthorService authorService = AuthorService.NewInstance();
        private PublisherService publisherService = PublisherService.NewInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] inputs = (Session["input"] as string[]) ?? new string[0];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = $"%{inputs[i]}%";
            }
            List<Book> books = bookService.GetBlurBooks(inputs);
            List<Author> authors = authorService.GetBlurAuthors(inputs);
            List<Publisher> publishers = publisherService.GetBlurPublisherByPublisherName(inputs);
            Literal title = new Literal();
            title.Text = @"<h2>查询到的结果</h2>";
            Result.Controls.Add(title);
            Literal bookTitle = new Literal();
            bookTitle.Text = @"<h4>有关输入的模糊搜索到的书</h4>";
            Result.Controls.Add(bookTitle);
            foreach (Book book in books)
            {
                Literal literal = new Literal();
                literal.Text = $"书名: {book.BookName}, 作者: {authorService.GetAuthorByBook(book)?.AuthorName}, 出版社: {publisherService.GetPublisherByBook(book)?.PublisherName}<br/>";
                Result.Controls.Add(literal);
            }
            Literal authorTitle = new Literal();
            authorTitle.Text = @"<h4>有关输入的模糊搜索到的作者</h4>";
            Result.Controls.Add(authorTitle);
            foreach (Author author in authors)
            {
                Literal literal = new Literal();
                literal.Text = $"作者: {author.AuthorName}, 写了{bookService.GetBooksByAuthor(author)?.Count}本书, <a href='AuthorBook.aspx?authorId=" + author.Id + $"' target='_blank'>查看该作者的书</a><br/>";
                Result.Controls.Add(literal);
            }
            Literal publisherTitle = new Literal();
            publisherTitle.Text = @"<h4>有关输入的模糊搜索到的出版社</h4>";
            Result.Controls.Add(publisherTitle);
            foreach (Publisher publisher in publishers)
            {
                Literal literal = new Literal();
                literal.Text = $"出版设: {publisher.PublisherName}, 出版了{bookService.GetBooksByPublisher(publisher)?.Count}本书, <a href='PublisherBook.aspx?publisherId=" + publisher.Id + $"' target='_blank'>查看该出版社的书</a><br/>";
                Result.Controls.Add(literal);
            }
        }
    }
}
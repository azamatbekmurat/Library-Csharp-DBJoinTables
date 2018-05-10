using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
      [HttpGet("/books")]
      public ActionResult Index()
      {
          List<Book> allBooks = Book.GetAllBooks();
          return View(allBooks);
      }
      [HttpGet("/books/new")]
      public ActionResult CreateForm()
      {
        return View("BookForm");
      }
      [HttpPost("/bookForm")]
      public ActionResult Create()
      {
        Book newBook = new Book(Request.Form["bookName"], Request.Form["bookGenre"]);
        newBook.Save();
        return RedirectToAction("Success", "Home");
      }
      [HttpGet("/books/{id}")]
      public ActionResult BookDetails(int id)
      {
        Dictionary<string, object> foundBookDetails = new Dictionary<string, object> ();
        Book selectedBook = Book.Find(id);
        List<Author> bookAuthors = selectedBook.GetAuthors();
        List<Author> allAuthors = Author.GetAllAuthors();
        foundBookDetails.Add("selectedBook", selectedBook);
        foundBookDetails.Add("bookAuthors", bookAuthors);
        foundBookDetails.Add("allAuthors", allAuthors);
        return View(foundBookDetails);
      }
      [HttpPost("/books/{bookId}/authors/new")]
      public ActionResult AddAnAuthor(int bookId)
      {
        Book book = Book.Find(bookId);
        Author author = Author.Find(Int32.Parse(Request.Form["author-id"]));
        book.AddAuthor(author);
        return RedirectToAction("BookDetails", new { id = bookId });
      }

    }
}

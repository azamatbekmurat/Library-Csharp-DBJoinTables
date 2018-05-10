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
      // [HttpGet("/books/search")]
      // public ActionResult SearchResult()
      // {
      //   Dictionary<string, object> foundBookDetails = new Dictionary<string, object> ();
      //   string searchString = Request.Query["bookTitle"];
      //   Book foundBookByName = Book.FindByBookName(searchString);
      //   List<Author> bookAuthors = foundBookByName.GetAuthors();
      //   List<Author> allAuthors = Author.GetAllAuthors();
      //   foundBookDetails.Add("foundBook", foundBookByName);
      //   foundBookDetails.Add("bookAuthors", bookAuthors);
      //   foundBookDetails.Add("allAuthors", allAuthors);
      //   return View(foundBookByName);
      // }

    }
}

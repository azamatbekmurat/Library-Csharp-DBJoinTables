using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System;

namespace Library.Controllers
{
    public class AuthorsController : Controller
    {
      [HttpGet("/authors")]
      public ActionResult Index()
      {
          List<Author> allAuthors = Author.GetAllAuthors();
          return View(allAuthors);
      }
      [HttpGet("/authors/new")]
      public ActionResult CreateForm()
      {
        return View("authorForm");
      }
      [HttpPost("/authorForm")]
      public ActionResult Create()
      {
        Author newAuthor = new Author(Request.Form["authorName"]);
        newAuthor.Save();
        return RedirectToAction("Success", "Home");
      }


      [HttpGet("/authors/{id}")]
      public ActionResult AuthorDetails(int id)
      {
        Dictionary<string, object> foundAuthorDetails = new Dictionary<string, object> ();
        Author selectedAuthor = Author.Find(id);
        List<Book> authorBooks = selectedAuthor.GetBooks();
        List<Book> allBooks = Book.GetAllBooks();
        foundAuthorDetails.Add("selectedAuthor", selectedAuthor);
        foundAuthorDetails.Add("authorBooks", authorBooks);
        foundAuthorDetails.Add("allBooks", allBooks);
        return View(foundAuthorDetails);
      }
      [HttpPost("/authors/{authorId}/books/new")]
      public ActionResult AddABook(int authorId)
      {
        Author author = Author.Find(authorId);
        Book book = Book.Find(Int32.Parse(Request.Form["book-id"]));
        author.AddBook(book);
        return RedirectToAction("AuthorDetails", new { id = authorId });
      }

      [HttpPost("/authors/{authorId}/delete")]
      public ActionResult DeleteAuthor(int authorId)
      {
        Author selectedAuthor = Author.Find(authorId);
        selectedAuthor.Delete();
        return RedirectToAction("Delete", "Home");
      }

    }
}

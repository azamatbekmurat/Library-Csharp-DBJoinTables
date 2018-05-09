using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
          return View();
      }
      [HttpGet("/success")]
      public ActionResult Success()
      {
          return View();
      }
      [HttpGet("/books/info/{bookId}")]
      public ActionResult Info(int bookId)
      {
        Book foundBook = Book.Find(bookId);
        return View("Index",foundBook);
      }
      // [HttpGet("/books/search")]
      // public ActionResult SearchByName()
      // {
      //   string searchString = [Request.Query("bookTitle")];
      //   Book foundBook = Book.FindByBookName(searchString);
      //   return View("",foundBook);
      // }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksAndAuthors.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {   
            ViewModel ViewModels = CreateViewModel();

            return View(ViewModels);
        }

        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(ViewModel FormData)
        {
            if(ModelState.IsValid)
            {
                _context.Add(FormData.Author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.Book = FormData.Book;
                return View("Index", ViewModels);
            }
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(ViewModel FormData)
        {
            if(ModelState.IsValid)
            {
                Author Author = _context.Authors.SingleOrDefault(author => author.AuthorId == FormData.Book.AuthorId);
                // FormData.Author = Author;
                // add the author object to the book
                // add the book to the authors book list
                _context.Add(FormData.Book);
                Author.Books.Add(FormData.Book);

                _context.SaveChanges();


                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.Book = FormData.Book;

                return View("Index", ViewModels);
            }
        }

        [HttpPost("book/delete/{BookId}")]
        public IActionResult DeleteBook(int BookId)
        {
            _context.Books.Remove(_context.Books.SingleOrDefault(book => book.BookId == BookId));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("AddPublisher")]
        public IActionResult AddPublisher(ViewModel FormData)
        {
            Publisher FormPublisher = FormData.Publisher;

            if(ModelState.IsValid)
            {
                _context.Add(FormPublisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.Publisher = FormPublisher;

                return View("Index", ViewModels);
            }
        }

        [HttpPost("AddPublisherToBook")]
        public IActionResult AddPublisherToBook(ViewModel FormData)
        {
            Publication Checker = _context.Publications.SingleOrDefault(p => p.BookId == FormData.Publication.BookId && p.PublisherId == FormData.Publication.PublisherId);
            if(Checker != null)
            {
                ModelState.AddModelError("Publication.BookId", "The Book was already published by the Publisher!");
            }
            if(ModelState.IsValid)
            {
                _context.Publications.Add(FormData.Publication);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.Publication = FormData.Publication;

                return View("Index", ViewModels);
            }
        }

        [HttpPost("AddUser/{userId}")]
        public IActionResult AddUser(ViewModel FormData, int userId)
        {
            System.Console.WriteLine("--------------------------------------------------------------");
            System.Console.WriteLine(userId);
            if(ModelState.IsValid)
            {
                _context.Users.Add(FormData.User);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.User = FormData.User;

                return View("Index", ViewModels);
            }
        }

        [HttpPost("CreateFriend")]
        public IActionResult CreateFriend(ViewModel FormData)
        {
            if(FormData.FriendShip.FriendeeId == FormData.FriendShip.FrienderId)
            {
                ModelState.AddModelError("FriendShip.FrienderId", "You can't friend yourself");
            }
            if(ModelState.IsValid)
            {
                _context.FriendShips.Add(FormData.FriendShip);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel ViewModels = CreateViewModel();
                ViewModels.FriendShip = FormData.FriendShip;

                return View("Index", ViewModels);
            }
        }

        private ViewModel CreateViewModel()
        {
            ViewModel ViewModels = new ViewModel()
            {
                AllAuthors = _context.Authors.Include(Author => Author.Books).ToList(),
                AllBooks = _context.Books
                .Include(Book => Book.Publications)
                .ThenInclude(Publications => Publications.Publisher)
                .ToList(),
                AllPublishers = _context.Publishers
                .Include(Publisher => Publisher.Publications)
                .ThenInclude(Publications => Publications.Book)
                .ToList(),
                AllUsers = _context.Users
                .Include(Friender => Friender.FrienderList)
                .ThenInclude(FrienderList => FrienderList.Friendee)
                .ToList(),
                AllFriendships = _context.FriendShips.ToList()
            };

            return ViewModels;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperation.CreateBook;
using WebApi.BookOperation.GetBooks;
using WebApi.DbOperations;
using static WebApi.BookOperation.CreateBook.CreateBookCommand;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbCondex _context;

        public BookController(BookStoreDbCondex context)
        {
            _context = context;
        }


        /* private static List<Book> BookList = new List<Book>()
         {
             new Book
             {
                 Id=1,
                 Title="sava  barıis",
                 GenerateId=1,
                 PageCount=260,
                  BublishDate =DateTime.Now.AddDays(1),


             },

              new Book
             {
                 Id=2,
                 Title="sava  barıis",
                 GenerateId=2,
                 PageCount=210,
                 BublishDate =DateTime.Now.AddDays(1),


             },

               new Book
             {
                 Id=3,
                 Title="Kumarbaz",
                 GenerateId=3,
                 PageCount=270,
                BublishDate =DateTime.Now.AddDays(1),


             },
                new Book
             {
                 Id=4,
                 Title="gümn olur asra bdele",
                 GenerateId=4,
                 PageCount=200,
                 BublishDate =DateTime.Now.AddDays(1),


             }


         };*/


        [HttpGet]
        public  IActionResult GetBooks()
        {
            /*var BookListi = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return BookListi;*/

            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

      [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).SingleOrDefault();
            return book;
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel Newbook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = Newbook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
         
            return Ok();
        }






        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updatebook)
        {

            var book = _context.Books.SingleOrDefault(x => x.Id == updatebook.Id);
           
            if (book == null)
                return BadRequest();
            book.GenerateId = updatebook.GenerateId != default ? updatebook.GenerateId : book.GenerateId;
            book.PageCount = updatebook.PageCount != default ? updatebook.PageCount : book.PageCount;
            book.BublishDate = updatebook.BublishDate != default ? updatebook.BublishDate : book.BublishDate;
            book.Title = updatebook.Title != default ? updatebook.Title : book.Title;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("id")]
    
        public IActionResult DeleteBook(int id)
        {
         
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }


    }
}

using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperation.CreateBook;
using WebApi.BookOperation.DeleteBookCommand;
using WebApi.BookOperation.GetBookDetail;
using WebApi.BookOperation.GetBooks;
using WebApi.BookOperation.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperation.CreateBook.CreateBookCommand;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbCondex _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbCondex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult GetBooks()
        {
            /*var BookListi = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return BookListi;*/

            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooDetailViewModel result;
            try
            {
                GetBookdetailQuery query = new GetBookdetailQuery(_context, _mapper);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }




            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel Newbook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = Newbook;

                CreateBookCommandValidator validations = new CreateBookCommandValidator();
                validations.ValidateAndThrow(command);


                
                    command.Handle();
                


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok();
        }






        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatebook)
        {

            try
            {
                UptadeBookCommand command = new UptadeBookCommand(_context);
                command.BookId = id;
                command.Model = updatebook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }




            return Ok();
        }


        [HttpDelete("id")]

        public IActionResult DeleteBook(int id)
        {

            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validations = new DeleteBookCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }


    }
}

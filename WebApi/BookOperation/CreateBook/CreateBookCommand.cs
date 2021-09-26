using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.BookOperation.CreateBook
{
    public class CreateBookCommand
    {


        private readonly BookStoreDbCondex _dbContext;
        private readonly IMapper _mapper;
        public CreateBookModel Model { get; set; }

        public CreateBookCommand(BookStoreDbCondex context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }



        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut");
            book = new Book();
            book = _mapper.Map<Book>(Model);
           /* book.Title = Model.Title;
            book.BublishDate = Model.BublishDate;
            book.GenerateId = Model.GenerateId;
            book.PageCount = Model.PageCount;*/
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            

        }


        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenerateId { get; set; }
            public int PageCount { get; set; }
            public DateTime BublishDate { get; set; }
        }
    }




}

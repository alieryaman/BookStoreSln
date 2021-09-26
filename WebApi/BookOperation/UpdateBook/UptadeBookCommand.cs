using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.BookOperation.UpdateBook
{
    public class UptadeBookCommand
    {




        private readonly BookStoreDbCondex _dbContext;
        public int BookId { get; set; }
       public  UpdateBookModel Model { get; set; }
        public UptadeBookCommand(BookStoreDbCondex context)
        {
            _dbContext = context;
        }


        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
                throw new InvalidOperationException("Kitap Eklenmedi");
            book.GenerateId = Model.GenerateId != default ? Model.GenerateId : book.GenerateId;
            
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
       

        }

        }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenerateId { get; set; }
        }
    }






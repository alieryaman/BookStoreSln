using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.BookOperation.DeleteBookCommand
{
    public class DeleteBookCommand
    {



        private readonly BookStoreDbCondex _dbContext;
        public int BookId { get; set; }
      
        public DeleteBookCommand(BookStoreDbCondex context)
        {
            _dbContext = context;
        }


        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Kitap Eklenmedi");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
          ;

        }







        }
}

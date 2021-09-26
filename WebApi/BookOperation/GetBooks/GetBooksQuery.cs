using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperation.GetBooks
{
    public class GetBooksQuery
    {

               private readonly BookStoreDbCondex _dbContext;

        public GetBooksQuery(BookStoreDbCondex context)
        {
            _dbContext = context;
        }

    
    public List<BooksViewModel> Handle()
        {
            var BookListi = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in BookListi)
            {
                vm.Add(new BooksViewModel() {


                    Title = book.Title,
                    Genre = ((GemreEnum)book.GenerateId).ToString(),
                    PublishDate=book.BublishDate.Date.ToString("dd/MM/yyyy"),

                
                });

            }
            return vm;
        }
    

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }

            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperation.GetBookDetail
{
    public class GetBookdetailQuery
    {


        private readonly BookStoreDbCondex _dbContext;
        public int BookId { get; set; }

        public GetBookdetailQuery(BookStoreDbCondex context)
        {
            _dbContext = context;
        }


        public BooDetailViewModel Handle()
        {

            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (book ==null)
            {
                throw new InvalidOperationException("Kitap bulunamdı");
            }
            BooDetailViewModel vm = new BooDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.BublishDate = book.BublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GemreEnum)book.GenerateId).ToString();




            return vm;

        }


        }



    public class BooDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string BublishDate { get; set; }
    }








}

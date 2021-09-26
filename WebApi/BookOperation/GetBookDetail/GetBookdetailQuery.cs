using AutoMapper;
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
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookdetailQuery(BookStoreDbCondex context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public BooDetailViewModel Handle()
        {

            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (book ==null)
            {
                throw new InvalidOperationException("Kitap bulunamdı");
            }
            BooDetailViewModel vm = _mapper.Map<BooDetailViewModel>(book);

            /* BooDetailViewModel vm = new BooDetailViewModel();
           vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.BublishDate = book.BublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GemreEnum)book.GenerateId).ToString();
           */



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

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;
using WebApplication1.DBOperations;

namespace WebApplication1.BookOperations.GetBookId
{
    public class GetBookIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int Bookid { get; set; }
        private readonly IMapper _maper;
        public GetBookIdQuery(BookStoreDbContext dbContext, IMapper maper)
        {
            _dbContext = dbContext;
            _maper = maper;
        }

        public BooksIdViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.ID == Bookid).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Bu id'ye sahip kitap yoktur");
            }
            BooksIdViewModel vm = _maper.Map<BooksIdViewModel>(book); 
            /*new BooksIdViewModel();
            vm.Title = book.Title;
            vm.PublishDate = book.PublishDate.ToString("dd/mm/yyyy");
            vm.PageCount = book.PageCount;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            */
                return vm;
        }
    }
    public class BooksIdViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }

    }
}

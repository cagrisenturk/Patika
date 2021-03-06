using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBOperations;

namespace WebApplication1.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public CreateBookModel Model { get; set; }
        private readonly IMapper _maper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper maper)
        {
            _dbContext = dbContext;
            _maper = maper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.Where(x => x.Title == Model.Title).SingleOrDefault();
            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }
            book = _maper.Map<Book>(Model); //new Book();
           // book.GenreId = Model.GenreId;
           // book.PageCount = Model.PageCount;
           // book.Title = Model.Title;
           // book.PublishDate = Model.PublishDate;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}

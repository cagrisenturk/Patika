using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBOperations;

namespace WebApplication1.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.ID == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Bu id'ye ait kitap bulunamadı");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }
}

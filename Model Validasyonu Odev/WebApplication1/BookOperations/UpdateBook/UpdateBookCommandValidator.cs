using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Bookid).GreaterThan(0);
            RuleFor(command => command.model.GenreId).GreaterThan(0);
            RuleFor(command => command.model.PageCount).GreaterThan(0);
            RuleFor(command => command.model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.model.Title).NotEmpty().MinimumLength(4);
        }
    

    }
}

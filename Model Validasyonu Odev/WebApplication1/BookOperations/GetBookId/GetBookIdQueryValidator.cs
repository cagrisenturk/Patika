using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BookOperations.GetBookId
{
    public class GetBookIdQueryValidator : AbstractValidator<GetBookIdQuery>
    {
        public GetBookIdQueryValidator()
        {
            RuleFor(command => command.Bookid).GreaterThan(0);
        } 
    
    }
}

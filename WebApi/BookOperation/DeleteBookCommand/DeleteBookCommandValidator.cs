﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperation.DeleteBookCommand
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {

        public DeleteBookCommandValidator()
        {

            RuleFor(command=>command.BookId).GreaterThan(0);

        }
    }
}

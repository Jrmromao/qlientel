﻿using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OfficeServices
{
    public class UpdateOffice
    {


        public class Command : IRequest
        {

            public string OfficeId { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;

                public Handler(DataContext context)
                {
                    _context = context;
                }

                public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    throw new NotImplementedException();
                }
            }
        }

    }
}

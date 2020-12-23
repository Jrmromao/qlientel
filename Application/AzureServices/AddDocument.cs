using Application.Errors;
using Azure.BlobOps;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AzureServices
{
    public class AddDocument
    {
        public class Command : IRequest
        {
            public IFormFile File { get; set; }
            public Guid EmployeeId { get; set; }
            public Guid CompanyId { get; set; }
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

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var company = await _context.Company.FirstOrDefaultAsync(c => c.Id == request.CompanyId);
                    var containerName = company.Name + company.Id;
                    var success = await UploadBlob.UploadBlopToContainner(containerName.ToLower(),"", request.EmployeeId.ToString(), request.File);

                    if (success != null)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Failed to Upload Document!" });
                }
            }
        }
    }
}
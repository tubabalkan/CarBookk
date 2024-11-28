
using CarBook.Application.Features.Mediator.Queries.FooterAddresQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterAddresResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddresHandlers
{
    public class GetFooterAddresQueryHandler : IRequestHandler<GetFooterAddresQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddresQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddresQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
               FooterAddressId=x.FooterAddressId,
               Address=x.Address,
               Description=x.Description,
               Email = x.Email,
               PhoneNumber = x.PhoneNumber
              

            }).ToList();
        }
    }
}

using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterAddresResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddresQueries
{
    public class GetFooterAddresByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public GetFooterAddresByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

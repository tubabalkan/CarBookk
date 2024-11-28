﻿using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
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
    public class UpdateFooterAddresCommandHandler : IRequestHandler<UpdateFooterAddresCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddresCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddresCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressId);
            values.Address = request.Address;
            values.PhoneNumber = request.PhoneNumber;
            values.Email = request.Email;
            values.Description = request.Description;

            await _repository.UpdateAsync(values);
        }
    }
}

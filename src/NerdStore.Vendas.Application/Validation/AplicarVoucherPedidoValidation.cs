using FluentValidation;
using NerdStore.Vendas.Application.Commands;
using System;

namespace NerdStore.Vendas.Application.Validation
{
    public class AplicarVoucherPedidoValidation : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AplicarVoucherPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.CodigoVoucher)
                .NotEmpty()
                .WithMessage("O código do voucher não pode ser vazio");
        }
    }
}
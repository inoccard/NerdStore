﻿using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Validation;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public string CodigoVoucher { get; private set; }

        public AplicarVoucherPedidoCommand(Guid clienteId, string codigoVoucher)
        {
            ClienteId = clienteId;
            CodigoVoucher = codigoVoucher;
        }

        public override bool EhValido() => new AplicarVoucherPedidoValidation().Validate(this).IsValid;
    }
}
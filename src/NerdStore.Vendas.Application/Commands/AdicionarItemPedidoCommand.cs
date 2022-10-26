using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Validation;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    /// <summary>
    /// Tem uma intensão única, validar o item do pedido
    /// </summary>
    public class AdicionarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool EhValido() => new AdicionarItemPedidoValidation().Validate(this).IsValid;
    }
}
using FluentValidation.Results;
using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Validar um comando
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        protected Command() => Timestamp = DateTime.Now;

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
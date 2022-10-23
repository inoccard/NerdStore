using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        private List<Event> _notificacoes;

        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        protected Entity() => Id = Guid.NewGuid();

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

        /// <summary>
        /// Verificar se dois objetos são iguais
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// operator de comparação de igualdade
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// operator de comparação de diferença
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b) => !(a == b);

        /// <summary>
        /// se o id for diferente, os dados também serão
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";

        public virtual bool EhValido() => throw new NotImplementedException();
    }
}
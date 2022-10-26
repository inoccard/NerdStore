using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Infra
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, VendasContext ctx)
        {
            /* pega todas as entidades do tipo entity, que possuam alguma notificação
             * ChangeTracker: somente o que foi modificado
             */
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            //seleciona todos os eventos de domínio
            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            // transforma numa lista e limpa em seguida
            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            // cria uma task onde os eventos selecionados serão publicados, um por vez
            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
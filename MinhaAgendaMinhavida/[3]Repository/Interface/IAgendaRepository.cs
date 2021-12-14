using MinhaAgendaMinhavida.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaMinhavida.Repository.Interface
{
    public interface IAgendaRepository
    {
        Task CriarAgenda(Agenda agenda);
        Task<Agenda> BuscaAgendaPorID(int id);
        Task<Agenda> BuscaAgendaPorDesc(string desc);
        Task AtualizarAgendaPorID(Agenda agenda);
        Task DeletarAgendaPorID(int iD);
        Task<IEnumerable<Agenda>> BuscarAgendas();
    }
}

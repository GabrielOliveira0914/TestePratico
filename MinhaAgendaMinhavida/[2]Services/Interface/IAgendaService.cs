using MinhaAgendaMinhavida.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaMinhavida.Services.Interface
{
    public interface IAgendaService
    {
        Task CriarAgenda(Agenda agenda);
        Task<Agenda> BuscaAgendaPorID(int id);
        Task<Agenda> BuscaAgendaPorDesc(string desc);
        Task AtualizarAgendaPorID(Agenda agenda);
        Task DeletarAgendaPorID(int ID);
        Task<IEnumerable<Agenda>> BuscarAgendas();
    }
}

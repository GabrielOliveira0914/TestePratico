using MinhaAgendaMinhavida.Model;
using MinhaAgendaMinhavida.Repository.Interface;
using MinhaAgendaMinhavida.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaMinhavida.Services
{
    public class AgendaService : IAgendaService
    {
        readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task CriarAgenda(Agenda agenda)
        {
            await _agendaRepository.CriarAgenda(agenda);
        }
        public async Task<Agenda> BuscaAgendaPorID(int id)
        {
            return await _agendaRepository.BuscaAgendaPorID(id);
        }
        public async Task<Agenda> BuscaAgendaPorDesc(string desc)
        {
            return await _agendaRepository.BuscaAgendaPorDesc(desc);
        }

        public async Task AtualizarAgendaPorID(Agenda agenda)
        {
            await _agendaRepository.AtualizarAgendaPorID(agenda);
        }

        public async Task DeletarAgendaPorID(int ID)
        {
            await _agendaRepository.DeletarAgendaPorID(ID);
        }

        public async Task<IEnumerable<Agenda>> BuscarAgendas()
        {
            return await _agendaRepository.BuscarAgendas();
        }
    }
}

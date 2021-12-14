using Microsoft.Extensions.Configuration;
using MinhaAgendaMinhavida.Model;
using MinhaAgendaMinhavida.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MinhaAgendaMinhavida.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IConfiguration _config;
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MinhaAgendaMinhaVida"));
            }
        }

        public AgendaRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task CriarAgenda(Agenda agenda)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"INSERT INTO [dbo].[Agenda]
                                    ([Titulo]
                                    ,[Descricao]
                                    ,[DataInicio]
                                    ,[DataTermino])
                                VALUES
                                    (@Titulo
                                    ,@Descricao
                                    ,@DataInicio
                                    ,@DataTermino)";

                conn.Open();

                await conn.ExecuteAsync(sQuery, new { agenda.Titulo, agenda.Descricao, agenda.DataInicio, agenda.DataTermino });
            }
        }

        public async Task<Agenda> BuscaAgendaPorID(int id)
        {
            using (IDbConnection conn = Connection)
            {

                string sQuery = $@"SELECT [ID]
                                       ,[Titulo]
                                       ,[Descricao]
                                       ,[DataInicio]
                                       ,[DataTermino]
                                   FROM [dbo].[Agenda]
                                   WHERE ID = @id;";

                conn.Open();
                return await conn.QueryFirstOrDefaultAsync<Agenda>(sQuery, new { id });
            }
        }

        public async Task<Agenda> BuscaAgendaPorDesc(string desc)
        {
            using (IDbConnection conn = Connection)
            {

                string sQuery = $@"SELECT [ID]
                                    ,[Titulo]
                                    ,[Descricao]
                                    ,[DataInicio]
                                    ,[DataTermino]
                                FROM [dbo].[Agenda]
                                WHERE Descricao like '%@desc%';";

                conn.Open();
                Agenda a = await conn.QueryFirstOrDefaultAsync<Agenda>(sQuery, new { desc });
                return a;
            }
        }

        public async Task AtualizarAgendaPorID(Agenda agenda)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"UPDATE [dbo].[Agenda]
                                     SET [Titulo] = @Titulo
                                        ,[Descricao] = @Descricao
                                        ,[DataInicio] = @DataInicio
                                        ,[DataTermino] = @DataTermino
                                   WHERE ID = @ID";

                conn.Open();

                await conn.ExecuteAsync(sQuery, new { agenda.Titulo, agenda.Descricao, agenda.DataInicio, agenda.DataTermino, agenda.ID });
            }
        }

        public async Task DeletarAgendaPorID(int ID)
        {
            using (IDbConnection conn = Connection)
            {

                string sQuery = $@"DELETE FROM [dbo].[Agenda]
                                    WHERE ID = @ID";

                conn.Open();
                await conn.QueryFirstOrDefaultAsync<Agenda>(sQuery, new { ID });
            }
        }

        public async Task<IEnumerable<Agenda>> BuscarAgendas()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = $@" SELECT [ID]
                                        ,[Titulo]
                                        ,[Descricao]
                                        ,[DataInicio]
                                        ,[DataTermino]
                                    FROM [dbo].[Agenda]";

                conn.Open();
                var result = await conn.QueryAsync<Agenda>(sQuery);

                return result;
            }
        }
    }
}

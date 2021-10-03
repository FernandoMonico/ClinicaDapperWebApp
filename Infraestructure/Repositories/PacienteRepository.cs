using Application.Interfaces;
using Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IConfiguration _configuration;

        public PacienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Paciente entity)
        {
            var sql = "SP_PacienteCreate";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var result = await connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "SP_PacienteDelete";
            using (var connection = new SqlConnection(GetConnectionString())) {
                var result = await connection.ExecuteAsync(sql, new { id = id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

        public async Task<IReadOnlyList<Paciente>> GetAllAsync()
        {
            var sql = "SP_PacienteGetAll";
            using (var connection = new SqlConnection(GetConnectionString())) {
                var result = await connection.QueryAsync<Paciente>(sql, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result.ToList();
            }
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            var sql = "SP_PacienteGetById";
            using (var connection = new SqlConnection(GetConnectionString())) {
                var result = await connection.QueryAsync<Paciente>(sql, new { id = id }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result.FirstOrDefault();
            }
        }

        public async Task<int> UpdateAsync(Paciente entity)
        {
            var sql = "SP_PacienteUpdate";
            using (var connection = new SqlConnection(GetConnectionString())) {
                var result = await connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
        }

        private string GetConnectionString() {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}

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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _configuration;

        public DoctorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Doctor entity)
        {
            var sql = "INSERT INTO Doctor (Nombre, Apellido, Especialidad) VALUES (@Nombre, @Apellido, @Especialidad)";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> AddListAsync(List<Doctor> doctorList)
        {
            var sql = "INSERT INTO Doctor (Nombre, Apellido, Especialidad) VALUES (@Nombre, @Apellido, @Especialidad)";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var result = await connection.ExecuteAsync(sql, doctorList);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE Doctor WHERE Id = @Id";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Doctor>> GetAllAsync()
        {
            var sql = "SELECT * FROM Doctor";
            using (var connection = new SqlConnection(GetConnectionString())) {
                connection.Open();
                var result = await connection.QueryAsync<Doctor>(sql);
                return result.ToList();
            }
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Doctor WHERE Id = @Id";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = await connection.QueryAsync<Doctor>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<int> UpdateAsync(Doctor entity)
        {
            var sql = "UPDATE Doctor SET Nombre = @Nombre, Apellido = @Apellido, Especialidad = @Especialidad WHERE Id = @Id";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        private string GetConnectionString() {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}

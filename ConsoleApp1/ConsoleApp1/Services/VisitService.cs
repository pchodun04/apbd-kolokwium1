using ConsoleApp1.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Services;

public class VisitService : IVisitService
{
    private readonly string _connectionString =
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;";

    public async Task<List<VisitDTO>> GetVisits(int Id)
    {
        var visits = new List<VisitDTO>();
        
        string commandToSql = "SELECT DATE FROM Appointment where Id = @Id";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        { 
            await connection.OpenAsync();

            using (SqlCommand command = new SqlCommand(commandToSql, connection))
            {
                command.Parameters.AddWithValue("@Id", Id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        visits.Add(new VisitDTO()
                        {
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                        });
                    }
                }
            }
        }
        return visits;
    }
}
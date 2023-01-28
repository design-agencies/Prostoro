using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorInfoController : ControllerBase
    {
        private readonly string _connectionString = "";

        [HttpPost]
        public void LogError([FromBody] string errorMessage)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO ErrorLog (Message, ErrorTime) VALUES (@Message, @ErrorTime)", connection);
                command.Parameters.AddWithValue("@Message", errorMessage);
                command.Parameters.AddWithValue("@ErrorTime", DateTime.UtcNow);

                command.ExecuteNonQuery();
            }
        }
    }
}

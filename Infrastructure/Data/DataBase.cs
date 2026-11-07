using System.Data.Common;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase
{
    private string connection = "Host=localhost;Port=5432;DataBase=ClinicQueue;Username=postgres;Password=1234";
    public DbConnection Connection() => new NpgsqlConnection(connection);
}

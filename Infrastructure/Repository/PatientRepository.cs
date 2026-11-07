using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PatientRepository(DataBase dataBase) : IPatientRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddPatient(Patient patient)
    {
        var conn = data.Connection();
        var query = "insert into patients(fullname, phone, birthdate, isactive, createdat)values(@fullname, @phone, @birthdate, @isactive, @createdat)";
        var res = await conn.ExecuteAsync(query, patient);
        return res>0;
    }

    public async Task<bool> DeletePatient(int id)
    {
        var conn = data.Connection();
        var query = "delete from patients where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res>0;
    }

    public async Task<Patient> GetPatient(int id)
    {
        var conn = data.Connection();
        var query = "select * from patients where id = @id";
        var res = await conn.QuerySingleOrDefaultAsync<Patient>(query, new{id});
        return res!;
    }

    public async Task<List<Patient>> GetPatients()
    {
        var conn = data.Connection();
        var qeury = "select * from patients";
        var res = await conn.QueryAsync<Patient>(qeury);
        return res.ToList();
    }

    public async Task<bool> UpdatePatient(Patient patient)
    {
        var conn = data.Connection();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate, isactive = @isactive, createdat = @createdat where id = @id";
        var res = await conn.ExecuteAsync(query, patient);
        return res>0;
    }

}

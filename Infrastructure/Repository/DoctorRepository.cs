using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class DoctorRepository(DataBase dataBase) : IDoctorRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddDoctor(Doctor doctor)
    {
        var conn = data.Connection();
        var query = "insert into doctors(fullname, specialty, isactive, hiredat)values(@fullname, @specialty, @isactive, @hiredat)";
        var res = await conn.ExecuteAsync(query, doctor);
        return res>0;
    }

    public async Task<bool> DeleteDoctor(int id)
    {
        var conn = data.Connection();
        var query = "delete from doctors where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res>0;
    }

    public async Task<Doctor> GetDoctor(int id)
    {
        var conn = data.Connection();
        var query = "select * from doctors where id = @id";
        var res = await conn.QuerySingleOrDefaultAsync<Doctor>(query, new{id});
        return res!;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        var conn = data.Connection();
        var query = "select * from doctors";
        var res = await conn.QueryAsync<Doctor>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateDoctor(Doctor doctor)
    {
        var conn = data.Connection();
        var query = "update doctors set fullname = @fullname, specialty = @specialty, isactive = @isactive, hiredat = @hiredat where id = @id";
        var res = await conn.ExecuteAsync(query, doctor);
        return res>0;
    }

}

using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class RoomRepository(DataBase dataBase) : IRoomRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddRoom(Room room)
    {
        var conn = data.Connection();
        var query = "insert into rooms(name, isactive)values(@name, @isactive)";
        var res = await conn.ExecuteAsync(query, room);
        return res>0;
    }

    public async Task<bool> DeleteRoom(int id)
    {
        var conn = data.Connection();
        var query = "delete from rooms where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res>0;
    }

    public async Task<Room> GetRoom(int id)
    {
        var conn = data.Connection();
        var query = "select * from rooms where id = @id";
        var res = await conn.QuerySingleOrDefaultAsync<Room>(query, new{id});
        return res!;
    }

    public async Task<List<Room>> GetRooms()
    {
        var conn = data.Connection();
        var query = "select * from rooms";
        var res = await conn.QueryAsync<Room>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateRoom(Room room)
    {
        var conn = data.Connection();
        var query = "update rooms set name = @name, isactive = @isactive where id = @id";
        var res = await conn.ExecuteAsync(query, room);
        return res>0;
    }

}

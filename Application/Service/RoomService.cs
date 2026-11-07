using System.Data;
using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private readonly IRoomRepository repository = roomRepository;

    public async Task<ApiResponses<bool>> AddRoom(Room room)
    {
        if (room == null)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "Room can't be null");
        }

        var conn = await repository.AddRoom(room);
        return conn
            ? new ApiResponses<bool>(HttpStatusCode.OK, "Room Added !!", conn)
            : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not added !!", false);
    }

    public async Task<ApiResponses<bool>> DeleteRoom(int id)
    {
        if (id <= 0)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }

        var conn = await repository.DeleteRoom(id);
        return conn
            ? new ApiResponses<bool>(HttpStatusCode.OK, "Room deleted !!", conn)
            : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not deleted !!", false);
    }

    public async Task<ApiResponses<Room>> GetRoom(int id)
    {
        if (id <= 0)
        {
            return new ApiResponses<Room>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }

        var conn = await repository.GetRoom(id);
        if (conn == null)
        {
            return new ApiResponses<Room>(HttpStatusCode.NotFound, "Room not found !!");
        }

        return new ApiResponses<Room>(HttpStatusCode.OK, "Room by id.", conn);
    }

    public async Task<ApiResponses<List<Room>>> GetRooms()
    {
        var conn = await repository.GetRooms();
        return new ApiResponses<List<Room>>(HttpStatusCode.OK, "List rooms.", conn);
    }

    public async Task<ApiResponses<bool>> UpdateRoom(Room room)
    {
        if (room == null)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "Room can't be null");
        }

        // Инҷо ислоҳ шуд: ба ҷои AddRoom UpdateRoom истифода шуд
        var conn = await repository.UpdateRoom(room);
        return conn
            ? new ApiResponses<bool>(HttpStatusCode.OK, "Room Updated !!", conn)
            : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not updated !!", false);
    }


}
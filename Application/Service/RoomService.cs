using System.Data;
using System.Net;
using Application.DTOs.Room;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private readonly IRoomRepository repository = roomRepository;

    public async Task<ApiResponses<bool>> AddRoom(RoomCreateDto room)
    {
        var rm = new Room()
        {
            Name = room.Name,
            Isactive = room.Isactive
        };
        var res = await repository.AddRoom(rm);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Room added !")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not added !");
    }

    public async Task<ApiResponses<bool>> DeleteRoom(int id)
    {
        var conn = await repository.DeleteRoom(id);
        return conn
            ? new ApiResponses<bool>(HttpStatusCode.OK, "Room deleted !!", conn)
            : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not deleted !!", false);
    }

    public async Task<ApiResponses<RoomResponseDto>> GetRoom(int id)
    {
        var res = await repository.GetRoom(id);
        var rm = new RoomResponseDto
        {
            Name = res.Name,
            Isactive = res.Isactive
        };
        return new ApiResponses<RoomResponseDto>(HttpStatusCode.OK, "Room by id. ", rm);
    }

    public async Task<ApiResponses<List<RoomResponseDto>>> GetRooms()
    {
        var conn = await repository.GetRooms();
        var rm = conn.Select(s => new RoomResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            Isactive = s.Isactive
        }).ToList();
        return new ApiResponses<List<RoomResponseDto>>(HttpStatusCode.OK, "List of room", rm);
    }

    public async Task<ApiResponses<bool>> UpdateRoom(int id, RoomUpdateDto room)
    {
        var rm = new Room()
        {
            Id = id,
            Name = room.Name,
            Isactive = room.Isactive
        };
        var res = await repository.UpdateRoom(rm);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Room updated !")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Room not updated !");
    }
}
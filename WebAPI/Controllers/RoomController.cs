using Application.DTOs.Room;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService roomService) : Controller
{
    private readonly IRoomService service = roomService;

    [HttpGet]
    public async Task<ApiResponses<List<RoomResponseDto>>> GetRooms()
    {
        return await service.GetRooms();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<RoomResponseDto>> GetRoom(int id)
    {
        return await service.GetRoom(id);
    }

    [HttpPost]
    public async Task<ApiResponses<bool>> AddRoom(RoomCreateDto room)
    {
        return await service.AddRoom(room);
    }

    [HttpPut]
    public async Task<ApiResponses<bool>> UpdateRoom(int id, RoomUpdateDto room)
    {
        return await service.UpdateRoom(id, room); 
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<RoomResponseDto>> Pathid(int id)
    {
        return await service.GetRoom(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeleteRoom(int id)
    {
        return await service.DeleteRoom(id);
    }
}
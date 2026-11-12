using Application.DTOs.Room;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(
    IRoomService roomService,
    ILogger<RoomsController> logger
    ) : Controller
{
    private readonly IRoomService service = roomService;
    private ILogger<RoomsController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponses<List<RoomResponseDto>>> GetRooms()
    {
        // _logger.LogInformation("List Room {Time}", DateTime.Now);
        return await service.GetRooms();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<RoomResponseDto>> GetRoom(int id)
    {
        // _logger.LogInformation("Room by id {Time}", DateTime.Now);
        return await service.GetRoom(id);
    }

    [HttpPost]
    public async Task<ApiResponses<bool>> AddRoom(RoomCreateDto room)
    {
        // _logger.LogInformation("Room added ! {Time}", DateTime.Now);
        return await service.AddRoom(room);
    }

    [HttpPut]
    public async Task<ApiResponses<bool>> UpdateRoom(int id, RoomUpdateDto room)
    {
        // _logger.LogInformation("Room updated ! {Time}", DateTime.Now);
        return await service.UpdateRoom(id, room); 
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<RoomResponseDto>> Pathid(int id)
    {
        // _logger.LogInformation("Room patch {Time}", DateTime.Now);
        return await service.GetRoom(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeleteRoom(int id)
    {
        // _logger.LogInformation("Room deleted {Time}", DateTime.Now);
        return await service.DeleteRoom(id);
    }
}
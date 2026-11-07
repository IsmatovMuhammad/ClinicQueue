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

    // GET /api/rooms
    [HttpGet]
    public async Task<ApiResponses<List<Room>>> GetRooms()
    {
        return await service.GetRooms();
    }

    // GET /api/rooms/{id}
    [HttpGet("{id:int}")]
    public async Task<ApiResponses<Room>> GetRoom(int id)
    {
        return await service.GetRoom(id);
    }

    // POST /api/rooms
    [HttpPost]
    public async Task<ApiResponses<bool>> AddRoom([FromBody] Room room)
    {
        return await service.AddRoom(room);
    }

    // PUT /api/rooms
    [HttpPut]
    public async Task<ApiResponses<bool>> UpdateRoom([FromBody] Room room)
    {
        return await service.UpdateRoom(room); 
    }

    // PATCH /api/rooms/{id}/deactivate
    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<Room>> Pathid(int id)
    {
        return await service.GetRoom(id);
    }

    // DELETE /api/rooms/{id}
    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeleteRoom(int id)
    {
        return await service.DeleteRoom(id);
    }
}
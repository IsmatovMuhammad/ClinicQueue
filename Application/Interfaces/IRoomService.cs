using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponses<bool>> AddRoom(Room room);
    Task<ApiResponses<bool>> DeleteRoom(int id);
    Task<ApiResponses<bool>> UpdateRoom(Room room);
    Task<ApiResponses<Room>> GetRoom(int id);
    Task<ApiResponses<List<Room>>> GetRooms();
}

using Application.DTOs.Room;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponses<bool>> AddRoom(RoomCreateDto room);
    Task<ApiResponses<bool>> DeleteRoom(int id);
    Task<ApiResponses<bool>> UpdateRoom(int id, RoomUpdateDto room);
    Task<ApiResponses<RoomResponseDto>> GetRoom(int id);
    Task<ApiResponses<List<RoomResponseDto>>> GetRooms();
}

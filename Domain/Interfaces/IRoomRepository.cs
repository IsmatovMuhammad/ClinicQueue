using Domain.Models;

namespace Domain.Interfaces;

public interface IRoomRepository
{
    Task<bool> AddRoom(Room room);
    Task<bool> DeleteRoom(int id);
    Task<bool> UpdateRoom(Room room);
    Task<Room> GetRoom(int id);
    Task<List<Room>> GetRooms();
}

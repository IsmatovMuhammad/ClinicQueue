using Domain.Models;

namespace Domain.Interfaces;

public interface IDoctorRepository
{
    Task<bool> AddDoctor(Doctor doctor);
    Task<bool> DeleteDoctor(int id);
    Task<bool> UpdateDoctor(Doctor doctor);
    Task<Doctor> GetDoctor(int id);
    Task<List<Doctor>> GetDoctors();
}

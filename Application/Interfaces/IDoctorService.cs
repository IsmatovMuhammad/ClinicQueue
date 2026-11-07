using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponses<bool>> AddDoctor(Doctor doctor);
    Task<ApiResponses<bool>> DeleteDoctor(int id);
    Task<ApiResponses<bool>> UpdateDoctor(Doctor doctor);
    Task<ApiResponses<Doctor>> GetDoctor(int id);
    Task<ApiResponses<List<Doctor>>> GetDoctors();
}

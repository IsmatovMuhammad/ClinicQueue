using Application.DTOs.Doctor;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponses<bool>> AddDoctor(DoctorCreateDto doctor);
    Task<ApiResponses<bool>> DeleteDoctor(int id);
    Task<ApiResponses<bool>> UpdateDoctor(int id, DoctorUpdateDto doctor);
    Task<ApiResponses<DoctorResponseDto>> GetDoctor(int id);
    Task<ApiResponses<List<DoctorResponseDto>>> GetDoctors();
}

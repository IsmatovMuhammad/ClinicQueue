using Application.DTOs.Patient;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponses<bool>> AddPatient(PatientCreateDto patient);
    Task<ApiResponses<bool>> DeletePatient(int id);
    Task<ApiResponses<bool>> UpdatePatient(int id, PatientUpdateDto patient);
    Task<ApiResponses<PatientResponseDto>> GetPatient(int id);
    Task<ApiResponses<List<PatientResponseDto>>> GetPatients();
}

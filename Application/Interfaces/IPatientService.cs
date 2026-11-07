using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponses<bool>> AddPatient(Patient patient);
    Task<ApiResponses<bool>> DeletePatient(int id);
    Task<ApiResponses<bool>> UpdatePatient(Patient patient);
    Task<ApiResponses<Patient>> GetPatient(int id);
    Task<ApiResponses<List<Patient>>> GetPatients();
}

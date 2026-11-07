using Domain.Models;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    Task<bool> AddPatient(Patient patient);
    Task<bool> DeletePatient(int id);
    Task<bool> UpdatePatient(Patient patient);
    Task<Patient> GetPatient(int id);
    Task<List<Patient>> GetPatients();
}

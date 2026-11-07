using System.Data;
using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository repository = patientRepository;
    public async Task<ApiResponses<bool>> AddPatient(Patient patient)
    {
        var con = await repository.AddPatient(patient);
        if(con == null)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "Patient can not null !!");
        }
        return con == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient Added !!", con)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Petient not Added !!");
    }

    public async Task<ApiResponses<bool>> DeletePatient(int id)
    {
        if(id == null || id<=0)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "ID is invalid");
        }
        var con = await repository.DeletePatient(id);
        return con == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient deleted !!", con)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Petient not deleted !!");
    }

    public async Task<ApiResponses<Patient>> GetPatient(int id)
    {
        if(id <= 0 || id == null)
        {
            return new ApiResponses<Patient>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }
        var con = await repository.GetPatient(id);
        return new ApiResponses<Patient>(HttpStatusCode.OK, "Patient by id.", con);
    }

    public async Task<ApiResponses<List<Patient>>> GetPatients()
    {
        var con = await repository.GetPatients();
        return new ApiResponses<List<Patient>>(HttpStatusCode.OK, "List Patients", con);
    }

    public async Task<ApiResponses<bool>> UpdatePatient(Patient patient)
    {
        if(patient.Id == null || patient.Id <= 0)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "ID is invalid");
        }
        var con = await repository.AddPatient(patient);
        return con == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient Updated !!", con)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Petient not Updated !!");
    }

}

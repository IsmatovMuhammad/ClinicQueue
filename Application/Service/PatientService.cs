using System.Data;
using System.Net;
using Application.DTOs.Patient;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository repository = patientRepository;
    public async Task<ApiResponses<bool>> AddPatient(PatientCreateDto patient)
    {
        var pt = new Patient()
        {
            FullName = patient.FullName,
            Phone = patient.Phone,
            Birthdate = patient.Birthdate,
            Isactive = patient.Isactive,
            Createdat = patient.Createdat
        };
        var res = await repository.AddPatient(pt);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient added ")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Patient not added !");
    }

    public async Task<ApiResponses<bool>> DeletePatient(int id)
    {
        var con = await repository.DeletePatient(id);
        return con == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient deleted !!", con)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Petient not deleted !!");
    }

    public async Task<ApiResponses<PatientResponseDto>> GetPatient(int id)
    {
        var res = await repository.GetPatient(id);
        var pt = new PatientResponseDto
        {
            FullName = res.FullName,
            Phone = res.Phone,
            Birthdate = res.Birthdate,
            Isactive = res.Isactive,
            Createdat = res.Createdat
        };
        return new ApiResponses<PatientResponseDto>(HttpStatusCode.OK, "Patient by id. ", pt);
    }

    public async Task<ApiResponses<List<PatientResponseDto>>> GetPatients()
    {
        var res = await repository.GetPatients();
        var pt = res.Select(s => new PatientResponseDto
        {
            Id = s.Id,
            FullName = s.FullName,
            Phone = s.Phone,
            Birthdate = s.Birthdate,
            Isactive = s.Isactive,
            Createdat = s.Createdat
        }).ToList();
        return new ApiResponses<List<PatientResponseDto>>(HttpStatusCode.OK, "List of patient. ", pt);
    }

    public async Task<ApiResponses<bool>> UpdatePatient(int id, PatientUpdateDto patient)
    {
        var pt = new Patient()
        {
            Id = id,
            FullName = patient.FullName,
            Phone = patient.Phone,
            Birthdate = patient.Birthdate,
            Isactive = patient.Isactive,
            Createdat = patient.Createdat
        };
        var res = await repository.UpdatePatient(pt);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Patient updated !")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Patient not updated !");
    }
}

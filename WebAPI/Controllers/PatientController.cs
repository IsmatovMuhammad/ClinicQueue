using Application.DTOs.Patient;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(IPatientService patientService) : Controller
{
    private readonly IPatientService service = patientService;

    [HttpGet]
    public async Task<ApiResponses<List<PatientResponseDto>>> GetPatients()
    {
        return await service.GetPatients();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<PatientResponseDto>> GetPatient(int id)
    {
        return await service.GetPatient(id);
    }

    [HttpPost]
    public async Task<ApiResponses<bool>> AddPatient( PatientCreateDto patient)
    {
        return await service.AddPatient(patient);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponses<bool>> UpdatePatient( int id, PatientUpdateDto patient)
    {
        return await service.UpdatePatient(id, patient); 
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<PatientResponseDto>> PathId(int id)
    {
        return await service.GetPatient(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeletedPatient(int id)
    {
        return await service.DeletePatient(id);
    }
}
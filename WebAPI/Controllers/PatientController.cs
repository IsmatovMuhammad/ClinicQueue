using Application.DTOs.Patient;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(
    IPatientService patientService,
    ILogger<PatientsController> logger
    ) : Controller
{
    private IPatientService service = patientService;
    private ILogger<PatientsController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponses<List<PatientResponseDto>>> GetPatients()
    {
        // _logger.LogInformation("List Patient {Time}", DateTime.Now);
        return await service.GetPatients();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<PatientResponseDto>> GetPatient(int id)
    {
        // _logger.LogInformation("Patient by id {Time}", DateTime.Now);
        return await service.GetPatient(id);
    }

    [HttpPost]
    public async Task<ApiResponses<bool>> AddPatient(PatientCreateDto patient)
    {
        // _logger.LogInformation("Patient added ! {Time}", DateTime.Now);
        return await service.AddPatient(patient);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponses<bool>> UpdatePatient(int id, PatientUpdateDto patient)
    {
        // _logger.LogInformation("Patient Updated ! {Time}", DateTime.Now);
        return await service.UpdatePatient(id, patient);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<PatientResponseDto>> PathId(int id)
    {
        // _logger.LogInformation("Patient patch. {Time}", DateTime.Now);
        return await service.GetPatient(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeletedPatient(int id)
    {
        // _logger.LogInformation("Patient deleted ! {Time}", DateTime.Now);
        return await service.DeletePatient(id);
    }
}
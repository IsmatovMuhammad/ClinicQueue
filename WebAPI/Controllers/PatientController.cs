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
    public async Task<ApiResponses<List<Patient>>> GetPatients()
    {
        return await service.GetPatients();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<Patient>> GetPatient(int id)
    {
        return await service.GetPatient(id);
    }

    [HttpPost]
    public async Task<ApiResponses<bool>> AddPatient([FromBody] Patient patient)
    {
        return await service.AddPatient(patient);
    }

    [HttpPut]
    public async Task<ApiResponses<bool>> UpdatePatient([FromBody] Patient patient)
    {
        return await service.UpdatePatient(patient); 
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponses<Patient>> PathId(int id)
    {
        return await service.GetPatient(id);
    }
}
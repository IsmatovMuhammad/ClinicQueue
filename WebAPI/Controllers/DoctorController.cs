using Application.DTOs.Doctor;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorController(
    IDoctorService doctorService,
    ILogger<DoctorController> logger
    ) : ControllerBase
{
    private IDoctorService service = doctorService;
    private ILogger<DoctorController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponses<List<DoctorResponseDto>>> GetDoctors()
    {
        // _logger.LogInformation("List of Doctor {Time}", DateTime.Now);
        return await service.GetDoctors();
    } 

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<DoctorResponseDto>> GetDoctor(int id)
    {
        // _logger.LogInformation("Doctor by id {Time}", DateTime.Now);
        return await service.GetDoctor(id);
    } 

    [HttpPost]
    public async Task<ApiResponses<bool>> AddDoctor(DoctorCreateDto doctor)
    {
        // _logger.LogInformation("Doctor added {TIme}", DateTime.Now);
        return await service.AddDoctor(doctor);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponses<bool>> UpdateDoctor(int id, DoctorUpdateDto doctor)
    {
        // _logger.LogInformation("Doctor updated {Time}", DateTime.Now);
        return await service.UpdateDoctor(id, doctor); 
    }


    [HttpPatch]
    public async Task<ApiResponses<DoctorResponseDto>> PathId (int id)
    {
        // _logger.LogInformation("Doctor patch {Time}", DateTime.Now);
        return await service.GetDoctor(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeleteDoctor(int id)
    {
        // _logger.LogInformation("Delete Doctor {Time}", DateTime.Now);
        return await service.DeleteDoctor(id);
    }
}

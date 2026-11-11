using Application.DTOs.Doctor;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService) : Controller
{
    private IDoctorService service = doctorService;

    [HttpGet]
    public async Task<ApiResponses<List<DoctorResponseDto>>> GetDoctors()
    {
        return await service.GetDoctors();
    } 

    [HttpGet("{id:int}")]
    public async Task<ApiResponses<DoctorResponseDto>> GetDoctor(int id)
    {
        return await service.GetDoctor(id);
    } 

    [HttpPost]
    public async Task<ApiResponses<bool>> AddDoctor(DoctorCreateDto doctor)
    {
        return await service.AddDoctor(doctor);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponses<bool>> UpdateDoctor(int id, DoctorUpdateDto doctor)
    {
        return await service.UpdateDoctor(id, doctor); 
    }


    [HttpPatch]
    public async Task<ApiResponses<DoctorResponseDto>> PathId (int id)
    {
        return await service.GetDoctor(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponses<bool>> DeleteDoctor(int id)
    {
        return await service.DeleteDoctor(id);
    }
}

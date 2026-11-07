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
    public async Task<ApiResponses<List<Doctor>>> GetDoctors()
    {
        return await service.GetDoctors();
    } 
    [HttpGet("{id:int}")]
    public async Task<ApiResponses<Doctor>> GetDoctor(int id)
    {
        return await service.GetDoctor(id);
    } 

    [HttpPost]
    public async Task<ApiResponses<bool>> AddDoctor(Doctor doctor)
    {
        return await service.AddDoctor(doctor);
    }

    [HttpPut]
    public async Task<ApiResponses<bool>> UpdateDoctor(Doctor doctor)
    {
        return await service.UpdateDoctor(doctor); 
    }


    [HttpPatch]
    public async Task<ApiResponses<Doctor>> PathId (int id)
    {
        return await service.GetDoctor(id);
    }
}

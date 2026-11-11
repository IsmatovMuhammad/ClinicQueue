using System.Data;
using System.Net;
using Application.DTOs.Doctor;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository repository = doctorRepository;
    public async Task<ApiResponses<bool>> AddDoctor(DoctorCreateDto doctor)
    {
        var dc = new Doctor()
        {
            FullName = doctor.FullName,
            Specialty = doctor.Specialty,
            Isactive = doctor.Isactive,
            Hiredat = doctor.Hiredat
        };
        var res = await repository.AddDoctor(dc);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor added !")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not added !");
    }

    public async Task<ApiResponses<bool>> DeleteDoctor(int id)
    {
        var conn = await repository.DeleteDoctor(id);
        return conn == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor deleted !!", conn)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not deleted !!");
    }

    public async Task<ApiResponses<DoctorResponseDto>> GetDoctor(int id)
    {
        var res = await repository.GetDoctor(id);

        var dc = new DoctorResponseDto
        {
            FullName = res.FullName,
            Specialty = res.Specialty,
            Isactive = res.Isactive,
            Hiredat = res.Hiredat
        };
        return new ApiResponses<DoctorResponseDto>(HttpStatusCode.OK, "Doctor by id. ", dc);
    }

    public async Task<ApiResponses<List<DoctorResponseDto>>> GetDoctors()
    {
        var conn = await repository.GetDoctors();
        var dc = conn.Select(s => new DoctorResponseDto
        {
            Id = s.Id,
            FullName = s.FullName,
            Specialty = s.Specialty,
            Isactive = s.Isactive,
            Hiredat = s.Hiredat
        }).ToList();
        return new ApiResponses<List<DoctorResponseDto>>(HttpStatusCode.OK, "List of Doctor", dc);
    }

    public async Task<ApiResponses<bool>> UpdateDoctor(int id, DoctorUpdateDto doctor)
    {
        var dc = new Doctor()
        {
            Id = id,
            FullName = doctor.FullName,
            Specialty = doctor.Specialty,
            Isactive = doctor.Isactive,
            Hiredat = doctor.Hiredat
        };
        var res = await repository.UpdateDoctor(dc);
        return res == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor update")
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not update");
    }

}

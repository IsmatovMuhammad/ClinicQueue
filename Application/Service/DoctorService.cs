using System.Data;
using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository repository = doctorRepository;
    public async Task<ApiResponses<bool>> AddDoctor(Doctor doctor)
    {
        var conn = await repository.AddDoctor(doctor);
        if(conn == null)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "Doctor can't null");
        }
        return conn == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor Added !!", conn)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not added !!");
    }

    public async Task<ApiResponses<bool>> DeleteDoctor(int id)
    {
        if(id <= 0 || id == null!)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }
        var conn = await repository.DeleteDoctor(id);
        return conn == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor deleted !!", conn)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not deleted !!");
    }

    public async Task<ApiResponses<Doctor>> GetDoctor(int id)
    {
        if(id == null || id <= 0)
        {
            return new ApiResponses<Doctor>(HttpStatusCode.BadRequest, "ID is invalid !!");
        }
        var conn = await repository.GetDoctor(id);
        return new ApiResponses<Doctor>(HttpStatusCode.OK, "Doctor by id.", conn);
    }

    public async Task<ApiResponses<List<Doctor>>> GetDoctors()
    {
        var conn = await repository.GetDoctors();
        return new ApiResponses<List<Doctor>>(HttpStatusCode.OK, "List doctors.", conn);
    }

    public async Task<ApiResponses<bool>> UpdateDoctor(Doctor doctor)
    {
        var conn = await repository.AddDoctor(doctor);
        if(conn == null!)
        {
            return new ApiResponses<bool>(HttpStatusCode.BadRequest, "Doctor can't null");
        }
        return conn == true
        ? new ApiResponses<bool>(HttpStatusCode.OK, "Doctor Added !!", conn)
        : new ApiResponses<bool>(HttpStatusCode.InternalServerError, "Doctor not added !!", false);
    }

}

namespace Application.DTOs.Doctor;

public class DoctorCreateDto
{
    public string FullName { get; set; }
    public string Specialty { get; set; }
    public bool Isactive { get; set; } = true;
    public DateOnly Hiredat { get; set; }
}
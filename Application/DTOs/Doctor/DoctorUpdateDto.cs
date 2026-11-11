namespace Application.DTOs.Doctor;

public class DoctorUpdateDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Specialty { get; set; }
    public bool Isactive { get; set; } = true;
    public DateOnly Hiredat { get; set; }
}

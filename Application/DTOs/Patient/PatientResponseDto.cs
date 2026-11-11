namespace Application.DTOs.Patient;

public class PatientResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public DateOnly Birthdate { get; set; }
    public bool Isactive { get; set; }
    public DateTime Createdat { get; set; } = DateTime.Now;
}

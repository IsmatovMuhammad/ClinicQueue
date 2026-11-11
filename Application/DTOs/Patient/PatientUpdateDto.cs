namespace Application.DTOs.Patient;

public class PatientUpdateDto
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public DateOnly Birthdate { get; set; }
    public bool Isactive { get; set; }
    public DateTime Createdat { get; set; } = DateTime.Now;
}

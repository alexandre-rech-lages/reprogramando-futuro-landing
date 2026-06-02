namespace ReprogramandoFuturo.WebApi.Models;
public record EnrollmentRequest(
    string StudentName,
    int? Age,
    string GuardianName,
    string Email,
    string Phone,
    string City,
    string Modality);

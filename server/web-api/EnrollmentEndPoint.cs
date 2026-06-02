
using ReprogramandoFuturo.WebApi.Models;
using ReprogramandoFuturo.WebApi.Services;

namespace ReprogramandoFuturo.WebApi.EndPoints;
public class EnrollmentEndPoint
{    
    public static async Task<IResult> HandleEnrollmentAsync(EnrollmentRequest request, 
        ISheetDbService sheetDbService,
        IEmailService emailService)
    {
        await sheetDbService.SaveEnrollmentAsync(request);

        await emailService.SendEnrollmentNotificationAsync(request);

        await emailService.SendConfirmationAsync(request);                   

        return Results.Ok(new { message = "Inscrição realizada com sucesso!" });
    }
}


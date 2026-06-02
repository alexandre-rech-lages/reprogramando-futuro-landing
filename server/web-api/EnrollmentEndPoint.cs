
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

        try
        {

            await emailService.SendEnrollmentNotificationAsync(request);

            await emailService.SendConfirmationAsync(request);
        }
        catch
        {
            return Results.Ok(new { message = "Inscrição realizada, mas houve um problema ao enviar os e-mails de confirmação." });
        }

        return Results.Ok(new { message = "Inscrição realizada com sucesso!" });
    }
}


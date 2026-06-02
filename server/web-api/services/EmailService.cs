using ReprogramandoFuturo.WebApi.Models;
using Resend;

namespace ReprogramandoFuturo.WebApi.Services;

public interface IEmailService
{
  Task SendEnrollmentNotificationAsync(EnrollmentRequest request);
  Task SendConfirmationAsync(EnrollmentRequest request);
}

public class EmailService : IEmailService
{
  private readonly IResend _resend;

  public EmailService(IConfiguration configuration)
  {
    _resend = ResendClient.Create(configuration["resend_key"] ??
      throw new InvalidOperationException("ResendApiKey não configurada"));
  }

  public async Task SendEnrollmentNotificationAsync(EnrollmentRequest request)
  {
    var resp1 = await _resend.EmailSendAsync(new EmailMessage()
    {
      From = "rech@reprogramandofuturo.com.br",
      To = "rech@academiadoprogramador.net",
      Subject = "Reprogramando Futuro - Nova Inscrição",
      HtmlBody = $"<p>Nova inscrição recebida.</p><ul>" +
            $"<li><strong>Aluno:</strong> {request.StudentName}</li>" +
            $"<li><strong>Responsável:</strong> {request.GuardianName}</li>" +
            $"<li><strong>Email:</strong> {request.Email}</li>" +
            $"<li><strong>Telefone:</strong> {request.Phone}</li>" +
            $"<li><strong>Cidade:</strong> {request.City}</li>" +
            $"<li><strong>Modalidade:</strong> {request.Modality}</li>" +
            $"</ul>"
    });

  }

  public async Task SendConfirmationAsync(EnrollmentRequest request)
  {
    var resp2 = await _resend.EmailSendAsync(new EmailMessage()
    {
      From = "rech@reprogramandofuturo.com.br",
      To = new[] { request.Email },
      Subject = "Reprogramando Futuro - Confirmação de Inscrição",

      Template = new EmailMessageTemplate()
      {
          TemplateId = Guid.Parse("717eaa77-5450-47d4-9ed1-0b5a1c7af415"),
          Variables = new Dictionary<string, object> { { "NOME_RESPONSAVEL", request.GuardianName } }
      }
    });
  }

}

using ReprogramandoFuturo.WebApi.Models;

namespace ReprogramandoFuturo.WebApi.Services;

public interface ISheetDbService
{
  Task SaveEnrollmentAsync(EnrollmentRequest request);
}

public class SheetDbService : ISheetDbService
{
  private readonly HttpClient _httpClient;

  public SheetDbService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task SaveEnrollmentAsync(EnrollmentRequest request)
  {
    var payload = new
    {
      nome_aluno = request.StudentName,
      idade = request.Age?.ToString() ?? "",
      nome_responsavel = request.GuardianName,
      email = request.Email,
      telefone = request.Phone,
      cidade = request.City,
      modalidade = request.Modality,
      data_inscricao = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
    };

    var response = await _httpClient.PostAsJsonAsync("https://sheetdb.io/api/v1/v86z0sv7xbqle", payload);

    if (!response.IsSuccessStatusCode)
        throw new Exception("Erro ao gravar os dados. Tente novamente.");
  }
}
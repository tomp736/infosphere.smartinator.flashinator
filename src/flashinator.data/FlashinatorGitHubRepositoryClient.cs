using System.Text.Json;

using flashinator.core;

namespace flashinator.data;

public class FlashinatorGitHubRepositoryClient
{
    private readonly HttpClient _httpClient;

    public FlashinatorGitHubRepositoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<FlashinatorGitHubRepositoryResponse> GetFlashinatorsAsync(FlashinatorGitHubRepositoryConfig flashinatorGitHubRepositoryConfig)
    {
        FlashinatorGitHubRepositoryResponse flashinatorRepositoryResponse
            = new FlashinatorGitHubRepositoryResponse();

        try
        {
            var response = await _httpClient.GetAsync(flashinatorGitHubRepositoryConfig.Url);
            var jsonContent = await response.Content.ReadAsStringAsync();
            var flashinators = JsonSerializer.Deserialize<List<Flashinator>>(jsonContent);
            if (flashinators is not null)
            {
                flashinatorRepositoryResponse.Flashinators = flashinators;
            }
        }
        catch (HttpRequestException ex)
        {
            flashinatorRepositoryResponse.Message = ex.Message;
        }
        catch (JsonException ex)
        {
            flashinatorRepositoryResponse.Message = ex.Message;
        }
        catch (Exception ex)
        {
            flashinatorRepositoryResponse.Message = ex.Message;
        }

        return flashinatorRepositoryResponse;
    }
}
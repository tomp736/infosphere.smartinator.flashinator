using flashinator.core;

namespace flashinator.data;

public class FlashinatorDataProvider
{
    private readonly FlashinatorGitHubRepositoryClient _flashinatorGitHubRepositoryClient;
    private readonly List<FlashinatorGitHubRepositoryConfig> _flashinatorGitHubRepositoryConfig;
    private readonly Lazy<List<Flashinator>> _flashinatorsLazy;

    public FlashinatorDataProvider(FlashinatorGitHubRepositoryClient flashinatorGitHubRepositoryClient, List<FlashinatorGitHubRepositoryConfig> flashinatorGitHubRepositoryConfig)
    {
        _flashinatorGitHubRepositoryClient = flashinatorGitHubRepositoryClient;
        _flashinatorGitHubRepositoryConfig = flashinatorGitHubRepositoryConfig;
        _flashinatorsLazy = new Lazy<List<Flashinator>>(() => LoadFlashinatorsAsync().Result);
    }

    private async Task<List<Flashinator>> LoadFlashinatorsAsync()
    {
        var tasks = _flashinatorGitHubRepositoryConfig.Select(config => _flashinatorGitHubRepositoryClient.GetFlashinatorsAsync(config));
        var results = await Task.WhenAll(tasks);
        var allFlashinators = results.SelectMany(r => r.Flashinators).ToList();
        return allFlashinators;
    }

    public List<Flashinator> GetFlashinators()
    {
        return _flashinatorsLazy.Value;
    }

    public Flashinator RandomFlashinator()
    {
        Random r = new Random();
        int next = r.Next(0, _flashinatorsLazy.Value.Count);
        return _flashinatorsLazy.Value[next];        
    }
}
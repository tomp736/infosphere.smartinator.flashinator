namespace flashinator.data;

public class FlashinatorGitHubRepositoryConfig
{
    public string? GithubUser { get; set; }
    public string? RepositoryName { get; set; }
    public string? BranchName { get; set; }
    public string? FilePath { get; set; }

    public string Url => $"https://raw.githubusercontent.com/{GithubUser}/{RepositoryName}/{BranchName}/{FilePath}";
}

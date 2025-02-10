namespace WrapperBuilder.Models;

public class AppOptions
{
    public string Name { get; init; } = "Default-Name";
    public string Service { get; init; } = "Default-Service";
    public string Version { get; init; } = "1.0.0";
    public bool DisplayBanner { get; init; } = true;
    public bool DisplayVersion { get; init; } = true;
}
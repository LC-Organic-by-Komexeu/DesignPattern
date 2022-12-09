//TODO can changed to interface
public class APISearchInfo
{
    public string tfsUri { get; set; } = "10.10.10.144:8080/tfs";
    public string organization { get; set; } = "DefaultCollection";
    public string project { get; set; } = "PJ2022007";
    public string team { get; set; } = "";
    public string query { get; set; } = "65b44b11-3f06-4ac1-bcbe-bf48865bd464";
    public string apiVersion { get; set; } = "6.0";
}

public static class APISearchInfoExtension
{
    public static string ToURI_WiqlQueryById(this APISearchInfo apiInfo)
    => $"http://{apiInfo.tfsUri}/{apiInfo.organization}/{apiInfo.project}/_apis/wit/wiql/{apiInfo.query}?api-version={apiInfo.apiVersion}";
}
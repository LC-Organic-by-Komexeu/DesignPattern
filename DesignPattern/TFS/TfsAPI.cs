/// <summary>
/// 介接DepOps API
/// </summary>
public class TFSAPI
{
    public string AccessName { get; } = "Jhen.syuAccess";
    public string AccessKey { get; } = "gqqay5aa4ktyp6oxifyfgdfaknctyqpr46l5m52x472f2q7ojoca";
    APISearchInfo _searchInfo;
    public TFSAPI(APISearchInfo searchInfo)
    {
        _searchInfo = searchInfo;
    }

    //TODO parameter use enum type ,use Factory Pattern    
    public string Query() => _searchInfo.ToURI_WiqlQueryById();
}

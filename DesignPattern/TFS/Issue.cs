public class Issue
{
    /// <summary>
    /// 議題ID
    /// </summary>
    /// <value></value>
    public int ID { get; set; }
    /// <summary>
    /// 議題名稱
    /// </summary>
    /// <value></value>
    public string issueName { get; set; }
    /// <summary>
    /// 狀況
    /// </summary>
    /// <value></value>
    public IssueStatusEnum status { get; set; }
}

public enum IssueStatusEnum
{
    UnStart = 0,
    Working = 1,
    Finish = 2,
}
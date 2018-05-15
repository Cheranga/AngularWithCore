namespace ASPCoreWithAngular.Models.VPlates
{
    public enum FlowType
    {
        StartsWith,
        StartsWithPattern,
        Contains,
        ContainsPattern,
        EndsWith,
        EndsWithPattern
    }

    public enum PatternType
    {
        Invalid = -1,
        WildCard = 0,
        Full = 1
    }
}
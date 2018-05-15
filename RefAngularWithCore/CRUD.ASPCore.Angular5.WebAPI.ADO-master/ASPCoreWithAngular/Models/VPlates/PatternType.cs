namespace ASPCoreWithAngular.Models.VPlates
{
    public enum FlowType
    {
        StartsWith,
        StartsWithPattern,
        Contains,
        ContainsPattern,
        ThenHas,
        ThenHasPattern,
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
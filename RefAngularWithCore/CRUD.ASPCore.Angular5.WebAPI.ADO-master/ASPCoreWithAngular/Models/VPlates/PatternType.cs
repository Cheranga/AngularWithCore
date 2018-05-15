using System.ComponentModel.DataAnnotations;

namespace ASPCoreWithAngular.Models.VPlates
{
    public enum FlowType
    {
        [Display(Name = "Starts With")]
        StartsWith,

        [Display(Name = "Starts With Pattern")]
        StartsWithPattern,

        [Display(Name = "Contains")]
        Contains,

        [Display(Name = "Contains Pattern")]
        ContainsPattern,

        [Display(Name = "Ends With")]
        EndsWith,

        [Display(Name = "Ends With Pattern")]
        EndsWithPattern
    }

    public enum PatternType
    {
        Invalid = -1,
        WildCard = 0,
        Full = 1
    }
}
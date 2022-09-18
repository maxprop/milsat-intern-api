using System.ComponentModel;

namespace MilsatInternAPI.Enums
{
    public enum DepartmentType
    {
        [Description("Analytics")]
        Analytics,
        [Description("Backend")]
        Backend,
        [Description("Cybersecurity")]
        Cybersecurity,
        [Description("DevOps")]
        DevOps,
        [Description("Frontend")]
        Frontend,
        [Description("UIUX")]
        UIUX,
        [Description("Staff")]
        Staff
    }
}

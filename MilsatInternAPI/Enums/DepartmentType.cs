using System.ComponentModel;

namespace MilsatInternAPI.Enums
{
    public enum DepartmentType
    {
        [Description("Backend")]
        Backend,
        [Description("Branding and Communication")]
        Branding,
        [Description("Community")]
        Community,
        [Description("Frontend")]
        Frontend,
        [Description("Mobile")]
        Mobile,
        [Description("Staff")]
        Staff,
        [Description("UIUX")]
        UIUX
    }
}

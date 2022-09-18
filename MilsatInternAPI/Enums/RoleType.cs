using System.ComponentModel;

namespace MilsatInternAPI.Enums
{
    public enum RoleType
    {
        [Description("Admin Role")]
        Admin,
        [Description("Intern Role")]
        Intern,
        [Description("Mentor Role")]
        Mentor
    }
}

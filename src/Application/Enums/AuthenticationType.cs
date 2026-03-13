using System.Runtime.Serialization;

namespace Application.Enums
{
    public enum AuthenticationType
    {
        [EnumMember(Value = "3ds")] ThreeDSecure = 1,
        [EnumMember(Value = "google_spa")] GoogleSpa = 2
    }
}
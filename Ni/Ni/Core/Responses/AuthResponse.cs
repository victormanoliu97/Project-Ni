namespace Ni.Core.Responses
{
    public class AuthResponse : GenericResponse
    {
        public int UserId { get; set; }
        public string AuthKey { get; set; }
    }
}
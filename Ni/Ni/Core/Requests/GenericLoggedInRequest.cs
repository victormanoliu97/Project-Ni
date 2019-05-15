namespace Ni.Core.Requests
{
    public class GenericLoggedInRequest
    {
        public int RequesterId { get; set; }
        public string AuthKey { get; set; }
    }
}

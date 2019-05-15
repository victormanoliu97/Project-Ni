using System.Collections.Generic;

namespace Ni.Core.Responses
{
    public class GenericResponse
    {
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
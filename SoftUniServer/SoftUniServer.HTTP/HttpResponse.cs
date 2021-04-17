using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class HttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();
        }
        public ICollection<Header> Headers { get; set; }

        public StatusCode StatusCode { get; set; }

        public ICollection<ResponseCookie> Cookies { get; set; }
    }
}

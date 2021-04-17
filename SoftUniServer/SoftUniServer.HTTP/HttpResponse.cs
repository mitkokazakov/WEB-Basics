using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, StatusCode statusCode = StatusCode.OK)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();

            this.Body = body;
            this.StatusCode = statusCode;

            this.AddHeader("Content-Type", contentType);
            this.AddHeader("Content-Length", this.Body.Length.ToString());
        }
        public ICollection<Header> Headers { get; set; }

        public StatusCode StatusCode { get; set; }

        public ICollection<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public void AddHeader(string name, string value)
        {
            
            if (this.Headers.Any(h => h.Name == name))
            {
                throw new ArgumentException("Already exsit header with this name");
            }

            Header header = new Header(name,value);
            this.Headers.Add(header);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + "\r\n");

            foreach (var header in this.Headers)
            {
                sb.Append(header.ToString() + "\r\n");
            }

            sb.Append("\r\n");

            return sb.ToString();
        }
    }
}

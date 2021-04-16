using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string request)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            var requestParts = request.Split(new string[] { "\r\n" },StringSplitOptions.None);

            string firstLine = requestParts[0];

            var firstLineParts = firstLine.Split(new string[] { " " }, StringSplitOptions.None);
        }
        public string Path { get; set; }

        public MethodType Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }
    }
}

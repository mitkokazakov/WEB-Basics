using System;
using System.Collections.Generic;
using System.Linq;
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

            this.Method = (MethodType)Enum.Parse(typeof(MethodType), firstLineParts[0],true);

            this.Path = firstLineParts[1];

            bool isHeader = true;

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < requestParts.Length; i++)
            {
                var currentLine = requestParts[i];

                if (String.IsNullOrEmpty(currentLine))
                {
                    isHeader = false;
                    continue;
                }

                if (isHeader)
                {
                    Header header = new Header(currentLine);
                    this.Headers.Add(header);

                }
                else 
                {
                    sb.Append(currentLine + "\r\n");
                }
            }

            this.Body = sb.ToString();

            Header cookieHeader = this.Headers.FirstOrDefault(h => h.Name == "Cookie");

            if (cookieHeader != null)
            {
                var cookieParts = cookieHeader.Value.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in cookieParts)
                {
                    Cookie cookie = new Cookie(part);
                    this.Cookies.Add(cookie);
                }
                
            }
        }
        public string Path { get; set; }

        public MethodType Method { get; set; }

        public string Body { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Method} {this.Path}" + "\r\n");

            foreach (var header in this.Headers)
            {
                sb.Append(header + "\r\n");
            }

            //if (this.Cookies.Count > 0)
            //{
            //    sb.Append("Cookie: ");

            //    foreach (var cookie in this.Cookies)
            //    {

            //        sb.Append(cookie);
            //    }
            //}

            sb.Append("\r\n");

            return sb.ToString();
        }
    }
}

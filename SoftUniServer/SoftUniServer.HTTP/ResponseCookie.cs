using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SoftUniServer.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) : base(name, value)
        {
            this.Path = "/";
        }

        public bool IsHttpOnly { get; set; }

        public int MaxAge { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name}={this.Value}; Path={this.Path};");

            if (this.IsHttpOnly)
            {
                sb.Append($" HttpOnly;");
            }

            if (this.MaxAge != 0)
            {
                sb.Append($" Max-Age={this.MaxAge};");
            }


            return sb.ToString();
        }
    }
}

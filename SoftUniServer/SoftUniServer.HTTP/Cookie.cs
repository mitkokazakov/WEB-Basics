using System;
using System.Text;

namespace SoftUniServer.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Cookie(string cookieString)
        {
                var singleCookie = cookieString.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                this.Name = singleCookie[0];
                this.Value = singleCookie[1];
            
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {

            return $"{this.Name}={this.Value};";
        }
    }
}
using System;

namespace SoftUniServer.HTTP
{
    public class Cookie
    {
        public Cookie(string cookieString)
        {
            var cookieParts = cookieString.Split(new string[] {"; "},StringSplitOptions.RemoveEmptyEntries);

            foreach (var c in cookieParts)
            {
                var singleCookie = c.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                this.Name = singleCookie[0];
                this.Value = singleCookie[1];
            }
        }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
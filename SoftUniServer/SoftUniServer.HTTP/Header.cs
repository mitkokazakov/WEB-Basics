using System;

namespace SoftUniServer.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Header(string headerLine)
        {
            var currentHeader = headerLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);

            this.Name = currentHeader[0];
            this.Value = currentHeader[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
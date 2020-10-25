using System;

namespace BE
{
    public class ProEasyException : Exception
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public ProEasyException(int code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}

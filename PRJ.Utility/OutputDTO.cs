using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Utility
{
    public class OutputDTO<T>
    {
        public bool Succeeded { get; set; } = true;
        public int HttpStatusCode { get; set; } = 200;
        public string Message { get; set; }
        public T Data { get; set; }
        public long TotalData { get; set; } = 0;
    }
}

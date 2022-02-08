﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Utilities
{
    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }

    public class ErrorModelResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}

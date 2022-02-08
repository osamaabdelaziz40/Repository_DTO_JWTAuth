using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Utility
{
    public static class Results
    {
        public static OutputDTO<dynamic> Unauthorized()
        {
            return new OutputDTO<dynamic>()
            {
                Succeeded = false,
                Message = "Unauthorized",
                Data = null
            };
        }

        public static OutputDTO<T> BadRequest<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Succeeded = false,
                Message = string.Format("{0}", message),
                Data = data
            };
        }

        public static OutputDTO<T> OK<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0}", message),
                Data = data
            };
        }

        public static OutputDTO<T> OKGet<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0} get successfully", message),
                Data = data
            };
        }

        public static OutputDTO<T> OKGetAll<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0}s get successfully", message),
                Data = data
            };
        }

        public static OutputDTO<T> OKAdded<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0} added successfully", message),
                Data = data
            };
        }

        public static OutputDTO<T> OKUpdated<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0} updated successfully", message),
                Data = data
            };
        }

        public static OutputDTO<T> OKDeleted<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Message = string.Format("{0} deleted successfully", message),
                Data = data
            };
        }

        public static OutputDTO<T> NotFound<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Succeeded = false,
                Message = string.Format("This {0} not found in our database", message),
                Data = data
            };
        }

        public static OutputDTO<T> SomethingWentWrong<T>(string message, T data)
        {
            return new OutputDTO<T>()
            {
                Succeeded = false,
                Message = string.Format("Something went wrong <b>{0}</b>", message),
                Data = data
            };
        }
    }
}

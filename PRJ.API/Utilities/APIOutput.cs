using Microsoft.AspNetCore.Mvc;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PRJ.API.Utilities
{
    public static class APIOutput
    {
        public static ObjectResult Result<T>(OutputDTO<T> data)
        {
            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.NotFound))
                return new NotFoundObjectResult(data);

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.BadRequest))
                return new BadRequestObjectResult(data);

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.InternalServerError))
            {
                return new ObjectResult(data)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError)
                };
            }

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.Forbidden))
            {
                return new ObjectResult(data)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden)
                };
            }

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.Locked))
            {
                return new ObjectResult(data)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.Locked)
                };
            }

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.NoContent))
            {
                return new ObjectResult(data)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.NoContent)
                };
            }

            if (data.HttpStatusCode == Convert.ToInt32(HttpStatusCode.Unauthorized))
                return new UnauthorizedObjectResult(data);


            return new OkObjectResult(data);

        }
    }
}

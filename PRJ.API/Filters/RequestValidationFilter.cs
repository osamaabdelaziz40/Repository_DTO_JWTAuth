﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PRJ.API.Utilities;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Filters
{
    public class RequestValidationFilter : OutputDTO<ErrorModelResponse>
    {
        public RequestValidationFilter(ActionContext context)
        {
            ConstructErrorModel(context);
        }
        public void ConstructErrorModel(ActionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Succeeded = false;
                HttpStatusCode = 400;
                Message = ResponseMessages.BAD_REQUEST;

                var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var response = new ErrorModelResponse();
                foreach (var item in errorsInModelState)
                {
                    var key = string.Empty;
                    foreach (var subError in item.Value)
                    {
                        if (!key.Equals(item.Key))
                        {
                            var errorModel = new ErrorModel
                            {
                                FieldName = item.Key,
                                Message = string.IsNullOrEmpty(subError) ? "The input was not valid." : subError
                            };
                            response.Errors.Add(errorModel);
                        }

                        key = item.Key;
                    }
                }
                Data = response;
            }
        }
    }
}

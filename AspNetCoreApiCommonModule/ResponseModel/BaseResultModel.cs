﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiCommonModule.ResponseModel
{
    public class BaseResultModel
    {
        public BaseResultModel(int? code = null, string message = null,
            object result = null, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            this.Code = code;
            this.Result = result;
            this.Message = message;
            this.ReturnStatus = returnStatus;
        }
        public int? Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ReturnStatus ReturnStatus { get; set; }
    }
}

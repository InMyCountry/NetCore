using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiCommonModule.ResponseModel
{
    public enum ReturnStatus
    {
        Fail = 0,
        Success = 1,
        ConfirmIsContinue = 2,
        Error = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class CAResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<ResponseError> ErrorList { get; set; }
        public dynamic Result { get; set; }

        public class ResponseError
        {
            public string ValueField { get; set; }
            public string ErrorDescription { get; set; }

        }
    }
}

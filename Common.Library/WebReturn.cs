using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library
{
    public class WebReturn
    {
        public bool status { get; set; }
        public string msg { get; set; }
        public dynamic data { get; set; }

        public static WebReturn Error(string msg, object data)
        {
            return new WebReturn()
            {
                status = false,
                msg = msg,
                data = data
            };
        }
        public static WebReturn Success(string msg, object data)
        {
            return new WebReturn()
            {
                status = true,
                msg = msg,
                data = data
            };
        }
    }
}

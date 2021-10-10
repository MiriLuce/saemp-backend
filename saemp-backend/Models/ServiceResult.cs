using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saemp_backend.Models
{

    public class ServiceResult
    {
        public String error { get; set; }
        public object data { get; set; }

        public void setMessage(string message)
        {
            this.error = "Lo sentimos, surgió un error. " + message;
        }
    }
}

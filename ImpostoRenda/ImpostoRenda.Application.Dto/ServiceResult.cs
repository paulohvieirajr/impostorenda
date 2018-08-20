using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Application.Dto
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Messages = new List<string>();
        }

        public bool Result { get; set; }

        public List<string> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPAssignmentAPI
{
    public class ResultViewModel
    {
        public bool IsSucess { get; set; } = false;
        public string Message { get; set; } = "";
        public object Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Domain.Base {
    public class ReturnClass {
        public ReturnClass() {
            Error = false;
            Message = "";
        }
        public ReturnClass(bool error, string message) {
            Error = error;
            Message = message;
        }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}

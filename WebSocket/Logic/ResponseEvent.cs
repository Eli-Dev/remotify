using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class ResponseEvent<T>
    {

        public String Command { get; set; }
        public T parameters { get; set; }
    }
}

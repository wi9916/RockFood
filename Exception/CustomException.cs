using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Exeption
{
    class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
            Speaker.Output(message, "Error");
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
            Speaker.Output(message, innerException.ToString());
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

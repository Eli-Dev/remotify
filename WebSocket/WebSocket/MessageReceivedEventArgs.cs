using System;

namespace WebApplication
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
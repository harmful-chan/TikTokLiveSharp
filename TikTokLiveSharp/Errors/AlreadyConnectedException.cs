﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Errors
{
    public class AlreadyConnectedException : Exception
    {
        public AlreadyConnectedException()
        {
        }

        public AlreadyConnectedException(string message) : base(message)
        {
        }

        public AlreadyConnectedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

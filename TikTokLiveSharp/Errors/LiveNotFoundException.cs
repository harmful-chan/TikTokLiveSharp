﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokLiveSharp.Errors
{
    public class LiveNotFoundException : Exception
    {
        public LiveNotFoundException()
        {
        }

        public LiveNotFoundException(string message) : base(message)
        {
        }

        public LiveNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

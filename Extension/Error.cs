﻿using System.Text.Json;

namespace RentalVideoSystem.Extension
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}

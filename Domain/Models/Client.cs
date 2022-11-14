using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string IPAddress { get; set; }

        public string Message { get; set; }
    }
}


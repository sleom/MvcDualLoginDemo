﻿namespace MvcDualLoginDemo.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPrimary { get; set; }
    }
}
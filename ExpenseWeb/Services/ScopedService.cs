﻿using System;

namespace ExpenseWeb.Services
{
    public class ScopedService : IScopedService
    {
        private string _datum;
        public ScopedService()
        {
            _datum = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string ToonDatum()
        {
            return _datum;
        }
    }
}

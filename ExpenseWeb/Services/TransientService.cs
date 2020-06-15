using System;

namespace ExpenseWeb.Services
{
    public class TransientService : ITransientService
    {
        private string _datum;
        public TransientService()
        {
            _datum = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string ToonDatum()
        {
            return _datum;
        }
    }
}

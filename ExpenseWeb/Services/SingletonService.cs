using System;

namespace ExpenseWeb.Services
{
    public class SingletonService : ISingletonService
    {
        private string _datum;
        public SingletonService()
        {
            _datum = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string ToonDatum()
        {
            return _datum;
        }
    }
}

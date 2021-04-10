using System;

namespace InterfaceER_API
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceER_API interfaceER_API = new InterfaceER_API();

            try
            {
                interfaceER_API.IniciarEnvioER();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace InterfaceER_API
{
    public class InterfaceER_API
    {
        public void IniciarEnvioER()
        {
            HttpClient client = new HttpClient();
            string URI = ConfigurationManager.AppSettings["uriBase"].ToString();
            client.BaseAddress = new System.Uri(URI);
            client.DefaultRequestHeaders.Accept.Clear();

            #region USP_LISTA_VENTAS_DIFERENCIAS_CANTIDAD_BDI_OFISIS
            var VentasDiferenciasCantidadResponse = JsonConvert.DeserializeObject(GetSync($"/api/ListaER?envioCorreo=true", client));
            #endregion            
        }
        private string GetSync(string apiMetodo, HttpClient http)
        {
            string retorno = "";

            try
            {
                var response = http.GetAsync(apiMetodo).Result;

                if (response.IsSuccessStatusCode)
                {
                    retorno = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    retorno = "";
                }
            }
            catch (Exception ex)
            {
                return retorno = "Error crítico: " + ex.Message;

            }

            return retorno;
        }
    }
}

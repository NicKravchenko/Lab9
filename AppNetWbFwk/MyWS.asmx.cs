using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppNetWbFwk
{
    /// <summary>
    /// Summary description for MyWS
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IDSTest1Entities entities = new IDSTest1Entities();

        [WebMethod]
        public string HelloWorld()
        {
            log.Debug("Hello world fue llamado");
            return "Hello World";
        }

        [WebMethod]
        public int Suma(int i, int j)
        {
            log.Debug("SUMMA fue llamado");

            return i + j ;
        }

        [WebMethod]
        public Respuesta RegistrarCliente(Cliente cliente)
        {
            log.Debug("Reg de cliente fue llamado");

            //TODO: Guargar el cliente en la base de datos
            Respuesta respuesta = new Respuesta() { Codigo = 0, Mensaje = "Transaccion procesada", Tipo = 0 };
            entities.InsertClient(cliente.Nombres);

            return respuesta;
        }
    }
}


using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class PlaceOrder : ICommand
    {
        public string OrderId { get; set; }
        public string Nombre { get; set; }
        public float Monto { get; set; }
        public int Cantidad { get; set; }

        public float Total { get; set; }


        public string Descripcion { get; set; }

    }
}


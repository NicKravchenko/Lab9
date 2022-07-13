using Messages;
using NServiceBus;
using NServiceBus.Logging;
using Sales.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            SalesTableAdapter salesTB = new SalesTableAdapter();

            salesTB.Insert(message.OrderId, message.Nombre, message.Monto, message.Cantidad, message.Total, message.Descripcion);


            log.Info($"Received PlaceOrder, " +
                $"\nOrderId = {message.OrderId}" +
                $"\nNombre = {message.Nombre}" +
                $"\nMonto = {message.Monto}" +
                $"\nCantidad = {message.Cantidad}" +
                $"\nTotal = {message.Total}" +
                $"\nDescripcion = {message.Descripcion}");

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId,
                Total = message.Total
            };
            //return Task.CompletedTask;

            return context.Publish(orderPlaced);

        }
    }
}

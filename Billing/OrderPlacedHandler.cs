using Billing.MyDataSetTableAdapters;
using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card for {message.Total} pesos");

            BillingTableAdapter billingTB = new BillingTableAdapter();

            billingTB.Insert(message.OrderId, message.Total.ToString());


            var orderBilled = new OrderBilled
            {
                OrderId = message.OrderId
            };

            return Task.CompletedTask;
        }
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace NorthwindData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //var ordersQuery =
                //    from order in db.Orders.Include(o => o.Customer)
                //    where order.Freight > 750
                //    select order;
                //foreach(var order in ordersQuery)
                //{
                //    if(order.Customer != null)
                //    {
                //        Console.WriteLine($"{order.Customer.CompanyName} of {order.Customer} " +
                //            $"paid {order.Freight} for shipping");
                //    }
                //}
                //var orderQuery2 =
                //    db.Orders.Include(o => o.Customer).Include(c => c.OrderDetails).Where(o => o.Freight > 750).Select(o => o);

                //foreach(var o in orderQuery2)
                //{
                //    Console.WriteLine($"Order {o.OrderId} was made by {o.Customer.CompanyName}");
                //    foreach(var od in o.OrderDetails)
                //    {
                //        Console.WriteLine($"\tProductId {od.ProductId}");
                //    }
                //}

                //var orderQuery3 =
                //    db.Orders.Include(o =>
                //    o.Customer).Include(c =>
                //    c.OrderDetails).ThenInclude(od =>
                //    od.Product).Where(o =>
                //    o.Freight > 750);

                //foreach(var order in orderQuery3)
                //{
                //    Console.WriteLine($"OrderId {order.OrderId}\t was made by: {order.Customer}");
                //    foreach(var od in order.OrderDetails)
                //    {
                //        Console.WriteLine($"\tProductId {od.ProductId}\tProduct name: {od.Product.ProductName}");
                //    }
                //}

                var orderQueryJoin =
                    from order in db.Orders
                    where order.Freight > 750
                    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                    select new
                    {
                        CustomerContactName = customer.ContactName,
                        City = customer.City,
                        Freight = order.Freight
                    };

                foreach(var result in orderQueryJoin)
                {
                    Console.WriteLine($"{result.CustomerContactName} of {result.City} paid" +
                        $" {result.Freight:.000} for shipping");
                }

                var orderCustomerBerlinParisQuery =
                    from order in db.Orders
                    join c in db.Customers on order.CustomerId equals c.CustomerId
                    where c.City == "Berlin" || c.City == "Paris"
                    select new
                    {
                        OrderId = order.OrderId,
                        CompanyName = c.CompanyName
                    };

                foreach(var result in orderCustomerBerlinParisQuery)
                {
                    Console.WriteLine($"OrderID:{result.OrderId}, ordered by {result.CompanyName}");
                }
            }
        }
    }
}

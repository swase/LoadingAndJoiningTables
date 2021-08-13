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

                //var orderQueryJoin =
                //    from order in db.Orders
                //    where order.Freight > 750
                //    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                //    select new
                //    {
                //        CustomerContactName = customer.ContactName,
                //        City = customer.City,
                //        Freight = order.Freight
                //    };

                //foreach(var result in orderQueryJoin)
                //{
                //    Console.WriteLine($"{result.CustomerContactName} of {result.City} paid" +
                //        $" {result.Freight:.000} for shipping");
                //}

                //var orderCustomerBerlinParisQuery =
                //    from order in db.Orders
                //    join c in db.Customers on order.CustomerId equals c.CustomerId
                //    where c.City == "Berlin" || c.City == "Paris"
                //    select new
                //    {
                //        OrderId = order.OrderId,
                //        CompanyName = c.CompanyName
                //    };

                //foreach(var result in orderCustomerBerlinParisQuery)
                //{
                //    Console.WriteLine($"OrderID:{result.OrderId}, ordered by {result.CompanyName}");
                //}

                /*SQL Query Lab*/
                //Method Syntax

                ///*****************************                       1.1     ***********************************************/
                //Console.WriteLine("Question 1.1" +
                //    "\n..............................................................................\n");
                //Console.WriteLine("Customers in Paris or London, Query" +
                //    "\n.........................");
                //var customerParisLondonQuery =                  //query Syntax
                //    from customer in db.Customers
                //    where customer.City == "Paris" || customer.City == "London"
                //    select new
                //    {
                //        CustomerId = customer.CustomerId,
                //        CompanyName = customer.CompanyName,
                //        address = $"{customer.Address}, {customer.City}, " +
                //        $"{customer.City} {customer.PostalCode}"
                //    };

                //foreach (var result in customerParisLondonQuery)
                //{
                //    Console.WriteLine($"Customer with id: '{result.CustomerId}' and " +
                //        $"name: '{result.CompanyName}'. Adress: {result.address}");
                //}

                //Console.WriteLine("\nCustomers in Paris or London, Method" +              
                //    "\n.........................");
                //var customerParisLondonQuery2 =
                //    db.Customers.Where(c => c.City == "Paris" || c.City == "London");
                //foreach (var result in customerParisLondonQuery2)
                //{
                //    Console.WriteLine($"Customer with id: '{result.CustomerId}' and " +
                //        $"name: '{result.CompanyName}'. Adress: {result.Address}, {result.City}, " +
                //        $"{result.City} {result.PostalCode}");
                //}
                /*****************************                       1.2     ***********************************************/
                //
                //            Console.WriteLine("\nQuestion 1.2" +
                //"\n..............................................................................\n");
                //            var bottleProductQuery =
                //                from p in db.Products
                //                where p.QuantityPerUnit.Contains("bottle")
                //                select p.ProductName;
                //            Console.WriteLine("\nProducts in a bottle, Query Syntax" +
                //                "\n...............................");
                //            foreach(var p in bottleProductQuery)
                //            {
                //                Console.WriteLine($"{p}");
                //            }

                //            Console.WriteLine("\nProducts in a bottle, Method Syntax" +
                //             "\n...............................");
                //            var bottleProductQuery2 =
                //                db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).Select(p => p.ProductName);
                //            foreach (var result in bottleProductQuery)
                //            {
                //                Console.WriteLine($"{result}");
                //            }

                /*****************************                       1.3     ***********************************************/
                //            Console.WriteLine("\nQuestion 1.3" +
                //"\n..............................................................................\n");
                //                Console.WriteLine("\nProducts in a bottle Extended, Query Syntax" +
                //"\n...............................");
                //                var bottleProductQueryExtended =
                //                    from p in db.Products
                //                    where p.QuantityPerUnit.Contains("bottle")
                //                    join s in db.Suppliers on p.SupplierId equals s.SupplierId

                //                    select new
                //                    {
                //                        ProductName = p.ProductName,
                //                        SupplierName = p.Supplier.CompanyName,
                //                        Country = p.Supplier.Country
                //                    };

                //                foreach (var result in bottleProductQueryExtended)
                //                {
                //                    Console.WriteLine($"Product: {result.ProductName} supplied by {result.SupplierName}" +
                //                        $"from{result.Country}");
                //                }
                //                Console.WriteLine("\nProducts in a bottle Extended, Method Syntax" +
                //                "\n...............................");

                //                //var bottleProductQueryExtended2 =
                //                //    db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).Include(p => p.Supplier).Select(p => p.ProductName);

                //                var bottleProductQueryExtended2 =
                //                    db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).Join(db.Suppliers
                //                    , p => p.SupplierId
                //                    , s => s.SupplierId
                //                    ,(p, s) => new
                //                    {
                //                        p.ProductName, s.CompanyName, s.Country
                //                    });


                //                foreach (var result in bottleProductQueryExtended2)
                //                {
                //                    Console.WriteLine($"Product: {result.ProductName}, Supplied by {result.CompanyName}" +
                //                        $"shipped from {result.Country}.");
                //                }

                /*****************************                       1.4     ***********************************************/
                //                Console.WriteLine("\nNumber of Products In Each Category, Query Syntax" +
                //                  "\n...............................");
                //            Console.WriteLine("\nQuestion 1.4" +
                //"\n..............................................................................\n");
                //                var numProductsInCategories =
                //                    from p in db.Products
                //                    join c in db.Categories
                //                    on p.CategoryId equals c.CategoryId
                //                    group p by new { CategoryId = p.CategoryId, CategoryName = p.Category.CategoryName }
                //                    into newGroup
                //                    select new
                //                    {
                //                        CategoryId = newGroup.Key.CategoryId,
                //                        CategoryName = newGroup.Key.CategoryName,
                //                        CountCategory = newGroup.Count()
                //                    };

                //                foreach(var result in numProductsInCategories)
                //                {
                //                    Console.WriteLine($"CategoryId: {result.CategoryId}, " +
                //                        $"CategoryName: {result.CategoryName}, " +
                //                        $"Number of Products: {result.CountCategory}");
                //                }
                //var prodGroupedByCategory =
                //    from product in db.Products
                //    join category in db.Categories on product.CategoryId equals category.CategoryId
                //    group product by category.CategoryName into newGroup
                //    select new { Category = newGroup.Key, NumOfProd = newGroup.Count() };




                //foreach (var result in prodGroupedByCategory)
                //{
                //    Console.WriteLine($"{result.Category} - {result.NumOfProd}");
                //}

                //Console.WriteLine("\nProducts in a bottle Extended, Query Syntax" +
                //"\n...............................");
                //var numProductsInCategories2 =
                //    db.Products     //from table
                //    .Join(db.Categories
                //    , p => p.CategoryId
                //    , c => c.CategoryId
                //    , (p, c) =>
                //    new
                //    {
                //        c.CategoryId, c.CategoryName, p.ProductId
                //    }).GroupBy(g => new { g.CategoryName, g.CategoryId })
                //    .Select(g => new { 
                //        CategoryId = g.Key.CategoryId,
                //        CategoryName = g.Key.CategoryName,
                //        NumProducts = g.Count()

                //    });

                //foreach (var result in numProductsInCategories2)
                //{
                //    Console.WriteLine($"CategoryId: {result.CategoryId}, " +
                //        $"CategoryName: {result.CategoryName}, " +
                //        $"Number of Products: {result.NumProducts}");
                //}

                /*****************************                       1.5     ***********************************************/
                Console.WriteLine("\nQuestion 1.5" +
    "\n..............................................................................\n");
                Console.WriteLine("\nEmployees in uk, Query Syntax" +
                "\n...............................");
                var employeesInUKQuery =
                    from e in db.Employees
                    where e.Country == "UK"
                    select new {
                        nameAndTitle = $"{e.Title} {e.FirstName} {e.LastName}",
                        city = e.City
                    };

                foreach(var result in employeesInUKQuery)
                {
                    Console.WriteLine($"{result.nameAndTitle} living in {result.city}");
                }

                Console.WriteLine("\nEmployees in uk, Method Syntax" +
"\n...............................");

                var employeesInUKQuery2 =
                    db.Employees.Where(e => e.Country.Equals("UK")).Select(e => new
                    {
                        nameAndTitle = $"{e.Title} {e.FirstName} {e.LastName}",
                        city = e.City
                    });

                foreach (var result in employeesInUKQuery2)
                {
                    Console.WriteLine($"{result.nameAndTitle} living in {result.city}");
                }

                /*****************************                       1.7     ***********************************************/

                Console.WriteLine("\nQuestion 1.7" +
"\n..............................................................................\n");
                Console.WriteLine("\nFreight amount > 100. Uk || USA, Query Syntax" +
                "\n...............................");
                var freightAmountQuery =
                    from o in db.Orders
                    where o.Freight > 100 && (o.ShipCountry == "USA" || o.ShipCountry == "UK")
                    group o by o.OrderId into newGroup
                    select newGroup;
                
                Console.WriteLine($"Number of freights with amount > 100 and either in USA or UK: {freightAmountQuery.Count()}");

                Console.WriteLine("\nFreight amount > 100. Uk || USA, Method Syntax" +
                "\n...............................");
                var freightAmountQuery2 =
                    db.Orders.Where(o => o.Freight > 100)
                    .Where(o => o.ShipCountry == "UK" || o.ShipCountry == "USA");

                Console.WriteLine($"Number of freights with amount > 100 and either in USA or UK: {freightAmountQuery2.Count()}");
            }

            /*****************************                       1.8     ***********************************************/

            Console.WriteLine("\nQuestion 1.8" +
"\n..............................................................................\n");
            Console.WriteLine("\nFinding the order number of the order with the highest discount, Method Syntax" +
            "\n...............................");


        }
    }
}

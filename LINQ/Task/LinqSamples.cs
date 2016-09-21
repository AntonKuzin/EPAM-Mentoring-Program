// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;
using System.Globalization;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Task 1")]
		[Description("This method finds all client with annual turnover more that X.")]
		public void Linq1()
		{
		    var limit = 100000;
		    var customers = dataSource.Customers.Where(customer => customer.Orders.Sum(order => order.Total) > limit);

			Console.WriteLine($"Client with annual turnover more than {limit}");
            Console.WriteLine();
            foreach (var x in customers)
			{
                ObjectDumper.Write(x);
            }
		}

        [Category("Restriction Operators")]
        [Title("Task 2")]
        [Description("All suppliers in the same country and city with the customer.")]
        public void Linq2()
        {
            var customers = dataSource.Customers;

            foreach (var p in customers)
            {
                var suppliers = dataSource.Suppliers.Where(t => t.Country == p.Country && t.City == p.City);
                Console.WriteLine("Customer:");
                ObjectDumper.Write(p);
                Console.WriteLine("Suppliers:");
                foreach (var supplier in suppliers)
                {
                    ObjectDumper.Write(supplier);
                }
                Console.WriteLine();
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 3")]
        [Description("All clients who has orders with cost more than X.")]
        public void Linq3()
        {
            var limit = 10000;
            var clients = dataSource.Customers.Where(c => c.Orders.Any(o => o.Total > limit));

            Console.WriteLine($"Client with at least one order with price more than {limit}");
            foreach (var p in clients)
            {
                ObjectDumper.Write(p);
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 4")]
        [Description("All clients with the date when they became a clients.")]
        public void Linq4()
        {
            var clients =
                dataSource.Customers.Select(
                    c => new {customer = c, date = c.Orders.Select(o => o.OrderDate).OrderBy(d => d).FirstOrDefault()});

            foreach (var p in clients)
            {
                ObjectDumper.Write(p.date);
                ObjectDumper.Write(p.customer);
                Console.WriteLine();
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 5")]
        [Description("All clients with the date when they became a clients ordered in some way.")]
        public void Linq5()
        {
            var clients =
                dataSource.Customers.Select(
                    c => new { customer = c, date = c.Orders.Select(o => o.OrderDate).OrderBy(o => o).FirstOrDefault() })
                    .OrderBy(t => t.date.Year)
                    .ThenBy(t => t.date.Month)
                    .ThenByDescending(t => t.customer.Orders.Sum(o => o.Total))
                    .ThenBy(t => t.customer.CustomerID);

            foreach (var p in clients)
            {
                ObjectDumper.Write(p.date);
                ObjectDumper.Write(p.customer);
                Console.WriteLine();
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 6")]
        [Description("All clients who has empty or incorrect region, phone number.")]
        public void Linq6()
        {
            var clients = dataSource.Customers.Where(
                c => Regex.IsMatch(c.PostalCode, @"\d+") || string.IsNullOrWhiteSpace(c.Region) || Regex.IsMatch(c.Phone, @"^([(]\d{1,3}[)])"));

            foreach (var p in clients)
            {
                ObjectDumper.Write(p);
                Console.WriteLine();
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 7")]
        [Description("Group products by categories, inside the groups - by availability, sort the last group by the price.")]
        public void Linq7()
        {
            var products = dataSource.Products.GroupBy(p => p.Category)
                .Select(gr => gr.GroupBy(p => p.UnitsInStock));

            foreach (var groups in products)
            {
                foreach (var group in groups)
                {
                    ObjectDumper.Write(group); 
                }
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 8")]
        [Description("Group products in three groups by the price")]
        public void Linq8()
        {
            var products = dataSource.Products.OrderBy(p => p.UnitPrice)
                .GroupBy(p =>
                {
                    if (p.UnitPrice < 30)
                        return "дешевый";
                    if (p.UnitPrice >= 30 && p.UnitPrice < 60)
                        return "средний";
                    if (p.UnitPrice >= 60)
                        return "дорогой";
                    return "";
                });

            foreach (var item in products)
            {
                ObjectDumper.Write(item);
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 9")]
        [Description("Calculate average order price per city and the average orders count per city.")]
        public void Linq9()
        {
            var data = dataSource.Customers.GroupBy(c => c.City)
                .Select(gr => new { city = gr.Key,
                    averagePrice = gr.Average(c => c.Orders.Sum(o => o.Total)),
                    averageCount = gr.Average(c => c.Orders.Count()) });

            foreach (var item in data)
            {
                ObjectDumper.Write(item);
            }
        }

        [Category("Restriction Operators")]
        [Title("Task 10")]
        [Description("")]
        public void Linq10()
        {
            var data = dataSource.Customers.Select(c => new { name = c.CompanyName, orders = c.Orders});

            foreach (var item in data)
            {
                ObjectDumper.Write(item);
            }
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    class Program
    {
        // Get an entire entity set.
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                System.Diagnostics.Debug.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
                //Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(Default.Container container, ODataTest2017.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                System.Diagnostics.Debug.WriteLine("Response: {0}", operationResponse.StatusCode);
                //Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }

        static void Main(string[] args)
        {
            string serviceUri = "50927";
            var container = new Default.Container(new Uri(serviceUri));

            var product = new ODataTest2017.Models.Product()
            {
                Name = "Yo-yo",
                Category = "Toys",
                Price = 4.95M
            };

            AddProduct(container, product);
            ListAllProducts(container);
        }
    }
}

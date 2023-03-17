using DataTablePrettyPrinter;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Lab.EF.UI
{
    public class Menu
    {
        public void Encabezado()
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("**************************************");
            Console.WriteLine("*********    MENÚ PRINCIPAL  *********");
            Console.WriteLine("**************************************");
            Console.WriteLine("**************************************");
            Console.WriteLine("1. Ejercicio 1");
            Console.WriteLine("2. Ejercicio 2");
            Console.WriteLine("3. Ejercicio 3");
            Console.WriteLine("4. Ejercicio 4");
            Console.WriteLine("5. Ejercicio 5");
            Console.WriteLine("6. Ejercicio 6");
            Console.WriteLine("7. Ejercicio 7");
            Console.WriteLine("8. Ejercicio 8");
            Console.WriteLine("9. Ejercicio 9");
            Console.WriteLine("10. Ejercicio 10");
            Console.WriteLine("11. Ejercicio 11");
            Console.WriteLine("12. Ejercicio 12");
            Console.WriteLine("13. Ejercicio 13");
            Console.WriteLine("14. Salir\n");
        }

        public void Opciones()
        {
            int opcion;
            bool salir = false;

            while (!salir)
            {
                Encabezado();
                Console.Write("Ingrese su opción: ");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Ejercicio1();
                            break;

                        case 2:
                            Ejercicio2();
                            break;

                        case 3:
                            Ejercicio3();
                            break;

                        case 4:
                            Ejercicio4();
                            break;

                        case 5:
                            Ejercicio5();
                            break;

                        case 6:
                            Ejercicio6();
                            break;

                        case 7:
                            Ejercicio7();
                            break;

                        case 8:
                            Ejercicio8();
                            break;

                        case 9:
                            Ejercicio9();
                            break;

                        case 10:
                            Ejercicio10();
                            break;

                        case 11:
                            Ejercicio11();
                            break;

                        case 12:
                            Ejercicio12();
                            break;

                        case 13:
                            Ejercicio13();
                            break;

                        case 14:
                            salir = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Opss! solo se permiten valores númericos");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Ops ocurrió un error " + ex.Message);
                    Console.ReadKey();
                }
            }
        }

        public void Ejercicio1()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver objeto customer\n\n");

                CustomersLogic customerLogic = new CustomersLogic();

                List<Customers> listCustomers = customerLogic.GetAll();

                var query = listCustomers.Take(1);

                DataTable table = new DataTable("Clientes");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre cliente", typeof(String));
                table.Columns.Add("Nombre contacto", typeof(String));
                table.Columns.Add("Dirección cliente", typeof(String));
                table.Columns.Add("Ciudad cliente", typeof(String));
                table.Columns.Add("Teléfono", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.CustomerID, item.CompanyName, item.ContactName, item.Address, item.City, item.Phone);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void Ejercicio2()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver todos los productos sin stock\n\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = from product in listProducts
                            where product.UnitsInStock == 0
                            select new ProductDto
                            {
                                productId = product.ProductID,
                                productName = product.ProductName,
                                unitsInStock = product.UnitsInStock
                            };

                DataTable table = new DataTable("Productos");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre producto", typeof(String));
                table.Columns.Add("Stock producto", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.productId, item.productName, item.unitsInStock);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio3()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = listProducts.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3).ToList();

                DataTable table = new DataTable("Productos");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre producto", typeof(String));
                table.Columns.Add("Stock producto", typeof(String));
                table.Columns.Add("Precio por unidad", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.ProductID, item.ProductName, item.UnitsInStock, item.UnitPrice);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio4()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver todos los customers de la Región WA\n");

                CustomersLogic customerLogic = new CustomersLogic();

                List<Customers> listCustomers = customerLogic.GetAll();

                var query = from customer in listCustomers
                            where customer.Region == "WA"
                            select new CustomerDto
                            {
                                customerId = customer.CustomerID,
                                companyName = customer.CompanyName,
                                contactName = customer.ContactName,
                                customerAdress = customer.Address,
                                customerCity = customer.City,
                                customerPhone = customer.Phone,
                                customerRegion = customer.Region
                            };

                DataTable table = new DataTable("Clientes");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre cliente", typeof(String));
                table.Columns.Add("Dirección cliente", typeof(String));
                table.Columns.Add("Ciudad cliente", typeof(String));
                table.Columns.Add("Teléfono", typeof(String));
                table.Columns.Add("Región", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.customerId, item.companyName, item.customerAdress, item.customerCity, item.customerPhone, item.customerRegion);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio5()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = listProducts.Where(p => p.ProductID == 789).FirstOrDefault();

                if (query != null)
                {
                    Console.WriteLine(query);
                }
                else
                {
                    Console.WriteLine("Null");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio6()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula\n");

                CustomersLogic customerLogic = new CustomersLogic();

                List<Customers> listCustomers = customerLogic.GetAll();

                var query = from customer in listCustomers
                            select new CustomerDto
                            {
                                customerId = customer.CustomerID,
                                companyName = customer.CompanyName
                            };

                DataTable table = new DataTable("Clientes");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre cliente minúscula", typeof(String));
                table.Columns.Add("Nombre cliente mayusculas", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.customerId, item.companyName, item.companyName.ToUpper());
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio7()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.\n");

                CustomersLogic customerLogic = new CustomersLogic();
                OrdersLogic orderLogic = new OrdersLogic();

                List<Customers> listCustomers = customerLogic.GetAll();
                List<Orders> listOrders = orderLogic.GetAll();

                var query = from customer in listCustomers
                            join order in listOrders
                            on customer.CustomerID equals order.CustomerID
                            where order.OrderDate > Convert.ToDateTime("1997/1/1") && customer.Region == "WA"
                            select new CustomerDto
                            {
                                customerId = customer.CustomerID,
                                companyName = customer.CompanyName,
                                customerRegion = customer.Region,
                                OrderDate = order.OrderDate
                            };

                DataTable table = new DataTable("Clientes y ordenes");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre cliente", typeof(String));
                table.Columns.Add("Región cliente", typeof(String));
                table.Columns.Add("Fecha orden", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.customerId, item.companyName, item.customerRegion, item.OrderDate);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio8()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver los primeros 3 Customers de la  Región WA\n");

                CustomersLogic customerLogic = new CustomersLogic();

                List<Customers> listCustomers = customerLogic.GetAll();

                var query = listCustomers.Where(c => c.Region == "WA").Take(3);

                DataTable table = new DataTable("Clientes WA");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre cliente", typeof(String));
                table.Columns.Add("Región cliente", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.CustomerID, item.CompanyName, item.Region);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio9()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver lista de productos ordenados por nombre\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = from product in listProducts
                            orderby product.ProductName
                            select new ProductDto
                            {
                                productId = product.ProductID,
                                productName = product.ProductName
                            };

                DataTable table = new DataTable("Productos");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre producto", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.productId, item.productName);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un erro: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio10()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver lista de productos ordenados por unit in stock de mayor a menor.\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = listProducts.OrderByDescending(p => p.UnitsInStock);

                DataTable table = new DataTable("Productos");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre producto", typeof(String));
                table.Columns.Add("Unidades stock", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.ProductID, item.ProductName, item.UnitsInStock);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        public void Ejercicio11()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver las distintas categorías asociadas a los productos\n");

                ProductsLogic productLogic = new ProductsLogic();
                CategoriesLogic categoriesLogic = new CategoriesLogic();

                List<Products> listProducts = productLogic.GetAll();
                List<Categories> listCategories = categoriesLogic.GetAll();

                var query = (from product in listProducts
                             select new
                             {
                                 CategoryID = Convert.ToInt32(product.CategoryID)
                             }).Distinct().ToList();

                var query2 = from product in query
                             join category in listCategories
                             on new { product.CategoryID } equals
                             new { category.CategoryID }
                             select category;

                DataTable table = new DataTable("Categorías");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Nombre categoría", typeof(String));

                foreach (var item in query2)
                {
                    table.Rows.Add(item.CategoryID, item.CategoryName);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio12()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver el primer elemento de una lista de productos\n");

                ProductsLogic productLogic = new ProductsLogic();

                List<Products> listProducts = productLogic.GetAll();

                var query = listProducts.FirstOrDefault();

                Console.WriteLine($"Id producto: {query.ProductID}");
                Console.WriteLine($"Nombre producto: {query.ProductName}\n");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void Ejercicio13()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Query para devolver los customer con la cantidad de ordenes asociadas\n");

                OrdersLogic orderLogic = new OrdersLogic();

                List<Orders> listOrders = orderLogic.GetAll();

                var query = listOrders
                .GroupBy(c => c.CustomerID)
                .Select(o => new CustomerDto
                {
                    customerId = o.Key,
                    customerCountOrders = o.Count()
                });

                DataTable table = new DataTable("Ordenes");

                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Número de ordenes", typeof(String));

                foreach (var item in query)
                {
                    table.Rows.Add(item.customerId, item.customerCountOrders);
                }

                Console.WriteLine(table.ToPrettyPrintedString());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
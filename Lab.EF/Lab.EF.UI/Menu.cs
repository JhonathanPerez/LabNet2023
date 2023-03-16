using DataTablePrettyPrinter;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Utils;
using System;
using System.Collections.Generic;
using System.Data;

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
            Console.WriteLine("1. Listar Categorias");
            Console.WriteLine("2. Adicionar nueva categoria");
            Console.WriteLine("3. Eliminar categoría");
            Console.WriteLine("4. Actualizar categoría");
            Console.WriteLine("5. Listar Expedidores");
            Console.WriteLine("6. Adicionar nuevo Expedidor");
            Console.WriteLine("7. Eliminar Expedidor");
            Console.WriteLine("8. Actualizar Expedidor");
            Console.WriteLine("9. Salir\n");
        }

        public void printTableCategories(List<Categories> categories)
        {
            DataTable table = new DataTable("Categories");
            table.Columns.Add("#", typeof(String));
            table.Columns.Add("Nombre Categoría", typeof(String));
            table.Columns.Add("Descripción Categoría", typeof(String));

            foreach (Categories cat in categories)
            {
                table.Rows.Add(cat.CategoryID, cat.CategoryName, cat.Description);
            }

            Console.WriteLine(table.ToPrettyPrintedString());
        }

        public void printTableShippers(List<Shippers> shippers)
        {
            DataTable table = new DataTable("Shippers");
            table.Columns.Add("#", typeof(String));
            table.Columns.Add("Nombre Compañia", typeof(String));
            table.Columns.Add("Teléfono Compañia", typeof(String));

            foreach (Shippers ship in shippers)
            {
                table.Rows.Add(ship.ShipperID, ship.CompanyName, ship.Phone);
            }

            Console.WriteLine(table.ToPrettyPrintedString());
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
                            ListCategories();
                            break;

                        case 2:
                            AddCategory();
                            break;

                        case 3:
                            DeleteCategory();
                            break;

                        case 4:
                            UpdateCategory();
                            break;
                        case 5:
                            ListShippers();
                            break;
                        case 6:
                            AddShipper();
                            break;

                        case 7:
                            DeleteShipper();
                            break;
                        case 8:
                            UpdateShipper();
                            break;
                        case 9:
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
                    Console.WriteLine("Ops ocurrió un error " + ex.Message);
                    Console.ReadKey();
                }
            }
        }

        public void ListCategories()
        {
            try
            {
                CategoriesLogic categorias = new CategoriesLogic();

                List<Categories> listCategories = categorias.GetAll();

                Console.Clear();

                printTableCategories(listCategories);

                Console.WriteLine("Presione una tecla para continuar...");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void AddCategory()
        {
            string categoryName;

            CategoriesLogic categoryLogic = new CategoriesLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el nombre de la categoría: ");
                categoryName = Console.ReadLine();

                ValidateDataAddCategory(categoryName, categoryLogic);

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al ingresar el dato: No se permiten datos nulos");
                Console.ReadKey();
            }
        }

        public void DeleteCategory()
        {
            int idCategory;

            CategoriesLogic categoriaLogic = new CategoriesLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el id de la categoría a eliminar: ");
                idCategory = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (categoriaLogic.Delete(idCategory))
                {
                    Console.WriteLine("Categoría eliminada exitosamente!!");
                }

                Console.ReadKey();
            }
            catch (WrongIdException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error " + ex.Message);
                Console.ReadKey();
            }
        }

        public void UpdateCategory()
        {
            int idCategory;

            CategoriesLogic categoriaLogic = new CategoriesLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el id de la categoría a editar: ");
                idCategory = Convert.ToInt32(Console.ReadLine());

                validateDataUpdateCategory(idCategory, categoriaLogic);

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al ingresar el dato: No se permiten datos nulos");
                Console.ReadKey();
            }
        }

        public void ListShippers()
        {
            try
            {
                ShippersLogic shippers = new ShippersLogic();

                List<Shippers> listShippers = shippers.GetAll();

                Console.Clear();

                printTableShippers(listShippers);

                Console.WriteLine("Presione una tecla para continuar...");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void AddShipper()
        {
            string companyName;

            ShippersLogic shippersLogic = new ShippersLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el nombre de la compañia: ");
                companyName = Console.ReadLine();

                ValidateDataAddShipper(companyName, shippersLogic);


            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al ingresar el dato: No se permiten datos nulos");
                Console.ReadKey();
            }
        }

        public void DeleteShipper()
        {
            int idShipper;

            ShippersLogic shipperLogic = new ShippersLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el id de la compañia a eliminar: ");
                idShipper = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (shipperLogic.Delete(idShipper))
                {
                    Console.WriteLine("Compañia eliminada exitosamente!!");
                }

                Console.ReadKey();
            }
            catch (WrongIdException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.ReadKey();
            }
        }

        public void UpdateShipper()
        {
            int idShipper;

            ShippersLogic shippersLogic = new ShippersLogic();

            Console.Clear();

            try
            {
                Console.Write("Ingrese el id de la compañia a editar: ");
                idShipper = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                validateDataUpdateShipper(idShipper, shippersLogic);

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error al ingresar el dato: No se permiten datos nulos");
                Console.ReadKey();
            }
        }

        public void ValidateDataAddCategory(string categoryName, CategoriesLogic categoriesLogic)
        {
            string categoryDescription;

            if (categoriesLogic.ItemExist(categoryName) != null)
            {
                Console.Clear();
                Console.WriteLine("El nombre de la categoría ya existe en la base de datos");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write("Ingrese la descripción de la categoría: ");
            categoryDescription = Console.ReadLine();

            Categories categoria = new Categories
            {
                CategoryName = categoryName,
                Description = categoryDescription

            };

            categoriesLogic.Add(categoria);

            Console.Clear();
            Console.WriteLine("Categoría agregada exitosamente");
            Console.ReadKey();
        }

        public void validateDataUpdateCategory(int idCategory, CategoriesLogic categoryLogic)
        {
            string categoryName;
            string categoryDescription;

            if (categoryLogic.ItemExist(idCategory) == null)
            {
                Console.Clear();
                Console.WriteLine($"La categoría con id {idCategory} no existe en el sistema");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write("Ingrese el nuevo nombre de la categoría: ");
            categoryName = Console.ReadLine();

            if (categoryLogic.ItemExist(categoryName) != null)
            {
                Console.Clear();
                Console.WriteLine("El nombre de la categoria ya existe en la base de datos");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            Console.Write("Ingrese la nueva descripción de la categoria: ");
            categoryDescription = Console.ReadLine();

            Categories updateCategory = new Categories
            {
                CategoryID = idCategory,
                CategoryName = categoryName,
                Description = categoryDescription

            };

            categoryLogic.Update(updateCategory);

            Console.Clear();
            Console.WriteLine("Categoría actualizada exitosamente");
            Console.ReadKey();
        }

        public void ValidateDataAddShipper(string companyName, ShippersLogic shippersLogic)
        {
            string companyPhone;

            if (shippersLogic.ItemExist(companyName) != null)
            {
                Console.Clear();
                Console.WriteLine("El nombre de la compañia ya existe en la base de datos");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el teléfono de la compañia: ");
            companyPhone = Console.ReadLine();

            if (!companyPhone.ContainLetters())
            {
                Console.Clear();
                Console.WriteLine("El campo de teléfono solo acepta valores númericos");
                Console.ReadKey();
                return;
            }

            Shippers shipper = new Shippers
            {
                CompanyName = companyName,
                Phone = companyPhone

            };

            shippersLogic.Add(shipper);

            Console.Clear();
            Console.WriteLine("Compañia agregada exitosamente");
            Console.ReadKey();
        }

        public void validateDataUpdateShipper(int idShipper, ShippersLogic shippersLogic)
        {
            string shipperName;
            string shipperPhone;

            if (shippersLogic.ItemExist(idShipper) == null)
            {
                Console.WriteLine($"La compañia con id {idShipper} no existe en el sistema");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el nuevo nombre de la compañia: ");
            shipperName = Console.ReadLine();

            if (shippersLogic.ItemExist(shipperName) != null)
            {
                Console.Clear();
                Console.WriteLine("El nombre de la compañia ya existe en la base de datos");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el nuevo teléfono de la compañia: ");
            shipperPhone = Console.ReadLine();

            if (!shipperPhone.ContainLetters())
            {
                Console.Clear();
                Console.WriteLine("El campo de teléfono solo acepta valores númericos");
                Console.ReadKey();
                return;
            }

            Shippers updatedShipper = new Shippers
            {
                ShipperID = idShipper,
                CompanyName = shipperName,
                Phone = shipperPhone

            };

            shippersLogic.Update(updatedShipper);

            Console.Clear();
            Console.WriteLine("Compañia actualizada exitosamente");
            Console.ReadKey();
        }

    }
}

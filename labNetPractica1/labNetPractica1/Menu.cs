using System;
using System.Collections.Generic;

namespace Poo
{
    public class Menu
    {
        public const int TipoTaxi = 1;
        public const int TipoOminBus = 2;

        List<TransportePublico> listaTransportes = new List<TransportePublico>();

        public void MostrarEncabezado()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("**************************************");
                Console.WriteLine("**************************************");
                Console.WriteLine("*********    MENÚ PRINCIPAL  *********");
                Console.WriteLine("**************************************");
                Console.WriteLine("**************************************");
                Console.WriteLine("1. Cargar pasajeros taxi");
                Console.WriteLine("2. Cargar pasajeros omnibus");
                Console.WriteLine("3. Mostrar detalles de los vehículos");
                Console.WriteLine("4. Poner en marcha vehículos");
                Console.WriteLine("5. Detener vehículos");
                Console.WriteLine("6. Salir\n");

                Console.Write("Ingrese su opción: ");

                try
                {
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();

                            AgregarVehiculos(TipoTaxi);

                            break;
                        case 2:

                            AgregarVehiculos(TipoOminBus);
                            break;
                        case 3:

                            Console.Clear();

                            if (listaTransportes.Count != 0)
                            {
                                for (int i = 0; i < listaTransportes.Count; i++)
                                {
                                    listaTransportes[i].MostrarPasajeros();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay vehículos registrados");
                            }

                            Console.WriteLine("\n Presione una tecla para continuar..");
                            Console.ReadKey();

                            break;
                        case 4:

                            Console.Clear();

                            if (listaTransportes.Count != 0)
                            {
                                for (int i = 0; i < listaTransportes.Count; i++)
                                {
                                    listaTransportes[i].Avanzar();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay vehículos registrados");
                            }

                            Console.WriteLine("\n Presione una tecla para continuar..");
                            Console.ReadKey();

                            break;

                        case 5:
                            Console.Clear();

                            if (listaTransportes.Count != 0)
                            {
                                for (int i = 0; i < listaTransportes.Count; i++)
                                {
                                    listaTransportes[i].Detenerse();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay vehículos registrados");
                            }

                            Console.WriteLine("\n Presione una tecla para continuar..");
                            Console.ReadKey();

                            break;

                        case 6:
                            salir = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(
                                "La opción ingresada no es valida, presione una tecla para continuar.."
                            );
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ops solo se pueden ingresar valores númericos!!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void AgregarVehiculos(int tipoVehiculo)
        {
            Console.Clear();

            int Npasajeros;

            if (tipoVehiculo == TipoTaxi)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Ingrese la cantidad de pasajeros para el taxi {i + 1}: ");
                    Npasajeros = Convert.ToInt32(Console.ReadLine());

                    if (Taxi.ValidarNumeroPasajeros(Npasajeros))
                    {
                        listaTransportes.Add(new Taxi(Npasajeros, i + 1));
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("El número de pasajeros no es válido");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Ingrese la cantidad de pasajeros para el Omnibus {i + 1}: ");
                    Npasajeros = Convert.ToInt32(Console.ReadLine());

                    if (OmniBus.ValidarNumeroPasajeros(Npasajeros))
                    {
                        listaTransportes.Add(new OmniBus(Npasajeros, i + 1));
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("El número de pasajeros no es válido");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}

using System;

namespace labNetPractica2
{
    public class Menu
    {
        public const int CERO = 0;

        Operaciones operacion = new Operaciones();
        Logic logic = new Logic();

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
            Console.WriteLine("5. Salir\n");
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

                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción no valida");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Opss! solo se permiten valores númericos");
                    Console.ReadKey();
                }
            }
        }

        public void Ejercicio1()
        {
            try
            {
                Console.Clear();

                decimal valor;

                Console.Write("Ingrese un valor: ");
                valor = Convert.ToDecimal(Console.ReadLine());

                operacion.Dividir(valor, CERO);
            }
            catch (Exception ex)
            {
                Console.Clear();

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("\nTermina ejecución");
                Console.ReadKey();
            }
        }

        public void Ejercicio2()
        {
            try
            {
                Console.Clear();

                decimal resultado;
                decimal dividendo;
                decimal divisor;

                Console.Write("Ingrese el dividendo: ");
                dividendo = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Ingrese el divisor: ");
                divisor = Convert.ToDecimal(Console.ReadLine());

                Console.Clear();

                resultado = operacion.Dividir(dividendo, divisor);
                Console.WriteLine(
                    $"El resultado de dividir {dividendo} / {divisor} = {Math.Round(resultado,2)} "
                );

                Console.ReadKey();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
            }
            finally
            {
                Console.WriteLine("\nTermina ejecución");
                Console.ReadKey();
            }
        }

        public void Ejercicio3()
        {
            try
            {
                logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.Clear();

                Console.Write("Mensaje de la excepción: ");
                Console.WriteLine(ex.Message.ToString());

                Console.Write("Tipo de execpcioón: ");
                Console.WriteLine(ex.GetType().ToString());

                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("\nTermina ejecución");
                Console.ReadKey();
            }
        }

        public void Ejercicio4()
        {
            try
            {
                Console.Clear();
                int numero;

                Console.Write("Ingrese un número par: ");
                numero = Convert.ToInt32((Console.ReadLine()));

                logic.NumeroPar(numero);
            }
            catch (Exception ex)
            {
                Console.Write("Mensaje de la excepción personalizada: ");
                Console.WriteLine(ex.Message.ToString());

                Console.Write("Tipo de execpción personalizada: ");
                Console.WriteLine(ex.GetType().ToString());
            }
            finally
            {
                Console.WriteLine("\nTermina ejecución");
                Console.ReadKey();
            }
        }
    }
}

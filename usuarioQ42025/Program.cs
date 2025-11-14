using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int cantidadNotas = 0;
        bool cantidadValida = false;

        // Paso 1: Pedir la cantidad de notas (validando con try-catch)
        do
        {
            Console.Write("Ingrese la cantidad de notas a promediar: ");
            string entrada = Console.ReadLine();

            try
            {
                // Intentar convertir a entero
                cantidadNotas = int.Parse(entrada);

                // Validaciones
                if (cantidadNotas <= 0)
                {
                    // Evita dividir por cero y notas negativas en cantidad
                    throw new Exception("La cantidad de notas debe ser un número entero mayor que cero.");
                }

                cantidadValida = true; // pasó todas las validaciones
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debes ingresar un número entero válido (no texto). Intenta de nuevo.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: El número ingresado es demasiado grande. Intenta con un valor más pequeño.");
            }
            catch (Exception ex)
            {
                // Captura el throw manual y otros errores generales
                Console.WriteLine("Error: " + ex.Message);
            }
        } while (!cantidadValida);

        // Paso 2: Pedir cada nota y validarlas
        List<double> notas = new List<double>();
        for (int i = 1; i <= cantidadNotas; i++)
        {
            bool notaValida = false;
            do
            {
                Console.Write($"Ingrese la nota #{i} (0 - 100): ");
                string entradaNota = Console.ReadLine();

                try
                {
                    double nota = double.Parse(entradaNota);

                    // Validar rango
                    if (nota < 0 || nota > 100)
                    {
                        throw new Exception("La nota debe estar entre 0 y 100.");
                    }

                    notas.Add(nota);
                    notaValida = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Debes ingresar un número válido para la nota (ej: 85.5). Intenta de nuevo.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: El número ingresado es demasiado grande. Intenta con un valor razonable (0 - 100).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (!notaValida);
        }

        // Paso 3: Calcular suma y promedio (ya que cantidadNotas > 0, no hay división por cero)
        try
        {
            double suma = 0.0;
            foreach (var n in notas)
            {
                suma += n;
            }

            double promedio = suma / cantidadNotas;

            Console.WriteLine();
            Console.WriteLine("----- Resultado -----");
            Console.WriteLine($"Cantidad de notas: {cantidadNotas}");
            Console.WriteLine($"Suma: {suma}");
            Console.WriteLine($"Promedio: {promedio:F2}"); // 2 decimales
        }
        catch (Exception ex)
        {
            // Catch general por si ocurre algo inesperado
            Console.WriteLine("Ocurrió un error al calcular el promedio: " + ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Presione ENTER para salir...");
        Console.ReadLine();
    }
}

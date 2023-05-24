using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Saludos
    {
        public void saludar()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")
                .CreateLogger();

            try
            {
                string name = "";
                Int16 age = 0;
                bool genderBool = false;
                string gender = "";
                string validateGenderBool = "";

                Log.Information("Se ingresara el nombre");

                do
                {

                    Console.WriteLine("Ingrese su nombre (Maximo 10 caracteres): ");
                    name = Console.ReadLine().Trim().ToLower();

                    if (name.Length > 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--Ingrese maximo 10 caracteres. Vuelve a intentarlo--");
                    }
                    else if (name.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--No ingreso ningun dato. Vuelve a intentarlo--");
                    }
                    else
                    {
                        Log.Information("Se ingreso correctamente el nombre.");
                    }
                } while (name.Length > 10 || name.Length == 0);

                Log.Information("Se ingresara la edad");

                do
                {
                    Console.WriteLine("Ingrese su edad (0 a 99): ");
                    age = Convert.ToInt16(Console.ReadLine().Trim().ToLower());

                    if (age < 0 || age > 99)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--Ingrese una edad en el rango de 0 a 99. " +
                            "Vuelve a intentarlo--");
                    }
                    else
                    {
                        Log.Information("Se ingreso correctamente la edad.");
                    }
                } while (age < 0 || age > 99);

                Log.Information("Se ingresara el género");

                do
                {
                    Console.WriteLine("Ingrese su género (Escribe true si es masculino ó " +
                    "false si es femenino): ");
                    validateGenderBool = Console.ReadLine().Trim().ToLower();

                    if (bool.TryParse(validateGenderBool, out genderBool))
                    {
                        Log.Information("Se ingreso correctamente el género.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("--Ingrese True si es masculino ó False si es femenino. " +
                            "Vuelve a intentarlo--");
                    }

                } while (!bool.TryParse(validateGenderBool, out genderBool));

                gender = (genderBool) ? "masculino" : "femenino";

                Console.WriteLine();
                Console.WriteLine("Hola " + name + ", " + age + " años, " + "género " + gender);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: El formato ingresado no es correcto.");
                Log.Error("Error: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: El dato ingresado es demaciado grande o pequeño.");
                Log.Error("Error: " + ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Error: No hay suficiente memoria disponible para completar la operación.");
                Log.Error("Error: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine("Error: El dato ingresado esta fuera de rango.");
                Log.Error("Error: " + ex.Message);
            }
            catch (IOException ex) {
                Console.WriteLine("Error: En la entrada o salida de datos.");
                Log.Error("Error: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_de_Cramer
{
    //CHOCOBAR MATIAS SEBASTIAN
    //UTN -Tucuman 
    //Tecnicatura Universitaria en Programacion
    //LEGAJO 59234 - DNI: 31040519

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" ==================================================");
            Console.WriteLine(" Calculo de Metodo de CRAMER Matriz 2x2 / 3x3 / 4x4");
            Console.WriteLine(" ==================================================");
            Console.WriteLine();
            int ecu = 0;//numero de ecuaciones
            int inco = 0;//numero de incognitas
            double Det = 0;//Determinante del sistema
            double Dx = 0;//Determinante de X
            double Dy = 0;//Determinante de Y
            double Dz = 0;//Determinante de Z
            double Dw = 0;//Determinante de W
            double suma1 = 0;
            double suma2 = 0;
            double suma3 = 0;
            double suma4 = 0;

            //double[,] AB = new double[3, 4];//Matriz ampliada


            Console.WriteLine();
            Console.Write($" Agregar el numero de ecuaciones = ");
            ecu = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine();
            Console.Write($" Agregar el numero de incognitas = ");
            inco = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            double[] b = new double[inco];//vector de los terminos independientes
            double[,] A = new double[ecu, inco];//Matriz del sistema
            int[,] B = new int[ecu, 1];//Matriz de terminos independientes
            double[,] X = new double[ecu, 1];//Matriz incognita
            double[,] Ax = new double[ecu, inco];//Matriz para calcular DX
            double[,] Ay = new double[ecu, inco];//Matriz para calcular Dy
            double[,] Az = new double[ecu, inco];//Matriz para calcular Dz
            double[,] Aw = new double[ecu, inco];//Matriz para calcular Dw

            if (ecu == inco)//primera condicones para usar el metodo de cramer
            {
                //Realizar el calculo de la determinante del Sistema |A|
                //N° de ecuaciones seran las filas ecu
                //N° de incognitas sera las columnas inco
                for (int f = 0; f < ecu; f++)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Agregar los coeficientes de las variables y el termino independiente de la {f + 1}° ecuacion");
                    Console.WriteLine();

                    for (int c = 0; c < inco; c++)
                    {
                        if ((ecu == inco) || (ecu == inco + 1) || (ecu == inco + 2))
                        {
                            if (c == 0)
                            {
                                Console.Write(" Agregar coeficiente de X = ");
                                A[f, c] = Int32.Parse(Console.ReadLine());
                            }
                            if (c == 1)
                            {
                                Console.Write(" Agregar coeficiente de Y = ");
                                A[f, c] = Int32.Parse(Console.ReadLine());
                            }
                        }

                        if (c < ecu)
                        {

                            if (c == 2)
                            {
                                Console.Write(" Agregar coeficiente de Z = ");
                                A[f, c] = Int32.Parse(Console.ReadLine());
                            }
                        }
                        if (ecu == c + 1)
                        {
                            if (c == 3)
                            {
                                Console.Write(" Agregar coeficiente de w = ");
                                A[f, c] = Int32.Parse(Console.ReadLine());
                            }
                        }


                    }
                    Console.Write(" Agregar termino independiente B = ");
                    b[f] = Int32.Parse(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" Presionar una tecla para continuar ...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" Sistemas de Ecuaciones ");
                Console.WriteLine(" ------------------------");
                Console.WriteLine();
                if (ecu == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("     __");
                    Console.WriteLine("    /");
                    Console.WriteLine($"   |  {A[0, 0]}X + {A[0, 1]}Y = {b[0]}");
                    Console.WriteLine("   |");
                    Console.WriteLine($"  <|                                       ---->  A x X = B");
                    Console.WriteLine("   |");
                    Console.WriteLine($"   |  {A[1, 0]}X + {A[1, 1]}Y = {b[1]}");
                    Console.WriteLine("     __");
                    Console.WriteLine();
                }
                if (ecu == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("     __");
                    Console.WriteLine("    /");
                    Console.WriteLine($"   |  {A[0, 0]}X + {A[0, 1]}Y + {A[0, 2]}Z = {b[0]}");
                    Console.WriteLine("   |");
                    Console.WriteLine($"  <|  {A[1, 0]}X + {A[1, 1]}Y + {A[1, 2]}Z = {b[1]}     ---->  A x X = B");
                    Console.WriteLine("   |");
                    Console.WriteLine($"   |  {A[2, 0]}X + {A[2, 1]}Y + {A[2, 2]}Z = {b[2]}");
                    Console.WriteLine("     __");
                    Console.WriteLine();
                }
                if (ecu == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("      __");
                    Console.WriteLine("     /");
                    Console.WriteLine($"    |  {A[0, 0]}X + {A[0, 1]}Y + {A[0, 2]}Z + {A[0, 3]}W = {b[0]}");
                    Console.WriteLine("    |");
                    Console.WriteLine($"    |  {A[1, 0]}X + {A[1, 1]}Y + {A[1, 2]}Z + {A[1, 3]}W = {b[1]}");
                    Console.WriteLine("   <|                                                                   ---->  A x X = B");
                    Console.WriteLine($"    |  {A[2, 0]}X + {A[2, 1]}Y + {A[2, 2]}Z + {A[2, 3]}W = {b[2]}");
                    Console.WriteLine("    |");
                    Console.WriteLine($"    |  {A[3, 0]}X + {A[3, 1]}Y + {A[3, 2]}Z + {A[3, 3]}W = {b[3]}");
                    Console.WriteLine("      __");
                    Console.WriteLine();
                }
                Console.WriteLine(" . A es la Matriz del sistema ");
                Console.WriteLine(" . X es la Matriz de las incognitas");
                Console.WriteLine(" . B es la Matriz de los terminos independientes");
                Console.WriteLine();
                Console.WriteLine();
                for (int f = 0; f < ecu; f++)
                {
                    Console.WriteLine();
                    if (f == 1)
                    {
                        Console.Write(" A = |");
                    }
                    else
                    {
                        Console.Write("     |");
                    }

                    for (int c = 0; c < inco; c++)
                    {
                        if (f == 1)
                        {
                            Console.Write($" {A[f, c]} ");
                        }
                        else
                        {
                            if (c != 0)
                            {
                                Console.Write($" {A[f, c]} ");
                            }
                            else
                            {
                                Console.Write($" {A[f, c]} ");
                            }
                        }
                    }
                    if (f != 1)
                    {
                        if (f == 0)
                        {
                            Console.WriteLine($" |           | x |         | {b[f]} |");
                        }
                        if (f == 2)
                        {
                            Console.WriteLine($" |           | z |         | {b[f]} |");
                        }
                        if (f == 3)
                        {
                            Console.WriteLine($" |           | w |         | {b[f]} |");
                        }
                    }
                    else
                    {
                        Console.WriteLine($" |  x    X = | y |  =  B = | {b[f]} |");
                    }

                }
                Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine(" Presionar una tecla para continuar ...");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();

                if (ecu == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Calculo de Determinante de la matriz del sistema 2x2");
                    Console.WriteLine();

                    Det = ((A[0, 0] * A[1, 1]) - (A[0, 1] * A[1, 0]));

                    Console.WriteLine();
                    Console.WriteLine($" Determinante del sistema |A| = {Det}");
                    Console.WriteLine();
                }
                if (ecu == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Calculo de la Determinante de la matriz del sistema 3x3 con metodo de Sarrus");
                    Console.WriteLine();

                    Det = ((A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[0, 2] * A[1, 0] * A[2, 1]) - (A[0, 2] * A[1, 1] * A[2, 0] + A[0, 0] * A[1, 2] * A[2, 1] + A[0, 1] * A[1, 0] * A[2, 2]));

                    Console.WriteLine();
                    Console.WriteLine($" Determinante del sistema |A| = {Det}");
                    Console.WriteLine();
                }
                if (ecu == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Calculo de la Determinante de la matriz del sistema 4x4 con combinacion del Metodo de LaPlace + Sarrus");
                    Console.WriteLine();

                    Det = A[0, 3] * (-1) * ((A[1, 0] * A[2, 1] * A[3, 2] + A[1, 1] * A[2, 2] * A[3, 0] + A[1, 2] * A[2, 0] * A[3, 1]) - (A[1, 2] * A[2, 1] * A[3, 0] + A[1, 0] * A[2, 2] * A[3, 1] + A[1, 1] * A[2, 0] * A[3, 2])) + A[1, 3] * (1) * ((A[0, 0] * A[2, 1] * A[3, 2] + A[0, 1] * A[2, 2] * A[3, 0] + A[0, 2] * A[2, 0] * A[3, 1]) - (A[0, 2] * A[2, 1] * A[3, 0] + A[0, 0] * A[2, 2] * A[3, 1] + A[0, 1] * A[2, 0] * A[3, 2])) + A[2, 3] * (-1) * ((A[0, 0] * A[1, 1] * A[3, 2] + A[0, 1] * A[1, 2] * A[3, 0] + A[0, 2] * A[1, 0] * A[3, 1]) - (A[0, 2] * A[1, 1] * A[3, 0] + A[0, 0] * A[1, 2] * A[3, 1] + A[0, 1] * A[1, 0] * A[3, 2])) + A[3, 3] * (1) * ((A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2,0] + A[0, 2] * A[1, 0] * A[2, 1]) - (A[0, 2] * A[1, 1] * A[2, 0] + A[0, 0] * A[1, 2] * A[2, 1] + A[0, 1] * A[1, 0] * A[2, 2]));

                    Console.WriteLine();
                    Console.WriteLine($" Determinante del sistema |A| = {Det}");
                    Console.WriteLine();
                }
                if (Det != 0)//Segunda condicones para usar el metodo de cramer
                {
                    for (int f = 0; f < ecu; f++)
                    {
                        for (int c = 0; c < inco; c++)
                        {

                            if (ecu == 2 && inco == 2)//Calculo de una determiante
                            {
                                if (c == 0)
                                {
                                    Ax[f, c] = b[f];
                                    Ay[f, c] = A[f, c];
                                }


                                if (c == 1)
                                {
                                    Ay[f, c] = b[f];
                                    Ax[f, c] = A[f, c];
                                }
                            }

                            if (ecu == 3 && inco == 3)//Calculo por medio de Sarrus
                            {
                                if (c == 0)
                                {
                                    Ax[f, c] = b[f];
                                    Ay[f, c] = A[f, c];
                                    Az[f, c] = A[f, c];
                                }
                                if (c == 1)
                                {
                                    Ax[f, c] = A[f, c];
                                    Ay[f, c] = b[f];
                                    Az[f, c] = A[f, c];
                                }
                                if (c == 2)
                                {
                                    Ax[f, c] = A[f, c];
                                    Ay[f, c] = A[f, c];
                                    Az[f, c] = b[f];
                                }
                            }
                            if (ecu == 4 && inco == 4)//Calculo por medio de LaPlace y Sarrus
                            {
                                if (c == 0)
                                {
                                    Ax[f, c] = b[f];
                                    Ay[f, c] = A[f, c];
                                    Az[f, c] = A[f, c];
                                    Aw[f, c] = A[f, c];
                                }
                                if (c == 1)
                                {
                                    Ax[f, c] = A[f, c];
                                    Ay[f, c] = b[f];
                                    Az[f, c] = A[f, c];
                                    Aw[f, c] = A[f, c];
                                }
                                if (c == 2)
                                {
                                    Ax[f, c] = A[f, c];
                                    Ay[f, c] = A[f, c];
                                    Az[f, c] = b[f];
                                    Aw[f, c] = A[f, c];
                                }
                                if (c == 3)
                                {
                                    Ax[f, c] = A[f, c];
                                    Ay[f, c] = A[f, c];
                                    Az[f, c] = A[f, c];
                                    Aw[f, c] = b[f];
                                }
                            }

                        }
                    }

                    Console.WriteLine(" Presionar una tecla para continuar ...");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine();

                    if (ecu == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Calculo de las incognitas X e Y");
                        Console.WriteLine();

                        Dx = ((Ax[0, 0] * Ax[1, 1]) - (Ax[0, 1] * Ax[1, 0]));
                        Dy = ((Ay[0, 0] * Ay[1, 1]) - (Ay[0, 1] * Ay[1, 0]));

                        Console.WriteLine();
                        Console.WriteLine($" Determinante del sistema |A| = {Det}");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de X : Dx = ({Ax[0, 0]} * {Ax[1, 1]}) - ({Ax[0, 1]} * {Ax[1, 0]}) = {Dx}");
                        Console.WriteLine();
                        Console.WriteLine($" X = (Dx / |A|) --->  X = ({Dx} / {Det}) = ({Dx / Det})  --->  X = ({Dx / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de Y : Dy = ({Ay[0, 0]} * {Ay[1, 1]}) - ({Ay[0, 1]} * {Ay[1, 0]}) = {Dy}");
                        Console.WriteLine();
                        Console.WriteLine($" Y = (Dy / |A|) --->  Y = ({Dy} / {Det}) = ({Dy / Det})  --->  Y = ({Dy / Det}) ");
                        Console.WriteLine();
                        for (int f = 0; f < ecu; f++)
                        {
                            for (int c = 0; c < 1; c++)
                            {
                                if (f == 0) { X[f, c] = Dx / Det; }
                                if (f == 1) { X[f, c] = Dy / Det; }
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine(" Presionar una tecla para continuar ...");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" Verificacion de Igualdad del sistema ");
                        Console.WriteLine(" =====================================");
                        Console.WriteLine();
                        Console.WriteLine();

                        suma1 = (X[0, 0] * A[0, 0]) + (X[1, 0] * A[0, 1]);
                        if (suma1 == b[0])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[0, 0]} * {X[0, 0]}) + ({A[0, 1]} * {X[1, 0]}) = {b[0]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }

                        suma2 = (X[0, 0] * A[1, 0]) + (X[1, 0] * A[1, 1]);
                        if (suma2 == b[1])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[1, 0]} * {X[0, 0]}) + ({A[1, 1]} * {X[1, 0]}) = {b[1]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }
                        if ((suma1 == b[0]) && (suma2 == b[1]))
                        {
                            Console.WriteLine();
                            Console.WriteLine($"  Solucion del Sistema x = {X[0, 0]},  y = {X[1, 0]} ");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($" No se cumplen las igualdades por lo tanto el Sistemas Incompatible sin solucion ");
                            Console.WriteLine();
                        }
                    }
                    if (ecu == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Calculo de las incognitas X, Y e Z y su Determinantes 3x3 con metodo de Sarrus");
                        Console.WriteLine();

                        Dx = ((Ax[0, 0] * Ax[1, 1] * Ax[2, 2] + Ax[0, 1] * Ax[1, 2] * Ax[2, 0] + Ax[0, 2] * Ax[1, 0] * Ax[2, 1]) - (Ax[0, 2] * Ax[1, 1] * Ax[2, 0] + Ax[0, 0] * Ax[1, 2] * Ax[2, 1] + Ax[0, 1] * Ax[1, 0] * Ax[2, 2]));
                        Dy = ((Ay[0, 0] * Ay[1, 1] * Ay[2, 2] + Ay[0, 1] * Ay[1, 2] * Ay[2, 0] + Ay[0, 2] * Ay[1, 0] * Ay[2, 1]) - (Ay[0, 2] * Ay[1, 1] * Ay[2, 0] + Ay[0, 0] * Ay[1, 2] * Ay[2, 1] + Ay[0, 1] * Ay[1, 0] * Ay[2, 2]));
                        Dz = ((Az[0, 0] * Az[1, 1] * Az[2, 2] + Az[0, 1] * Az[1, 2] * Az[2, 0] + Az[0, 2] * Az[1, 0] * Az[2, 1]) - (Az[0, 2] * Az[1, 1] * Az[2, 0] + Az[0, 0] * Az[1, 2] * Az[2, 1] + Az[0, 1] * Az[1, 0] * Az[2, 2]));

                        Console.WriteLine();
                        Console.WriteLine($" Determinante del sistema |A| = {Det}");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de X : Dx = (({Ax[0, 0]} * {Ax[1, 1]} * {Ax[2, 2]} + {Ax[0, 1]} * {Ax[1, 2]} * {Ax[2, 0]} + {Ax[0, 2]} * {Ax[1, 0]} * {Ax[2, 1]}) - ({Ax[0, 2]} * {Ax[1, 1]} * {Ax[2, 0]} + {Ax[0, 0]} * {Ax[1, 2]} * {Ax[2, 1]} + {Ax[0, 1]} * {Ax[1, 0]} * {Ax[2, 2]})) = {Dx}");
                        Console.WriteLine();
                        Console.WriteLine($" X = (Dx / |A|) --->  X = ({Dx} / {Det}) = ({Dx / Det})  --->  X = ({Dx / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de Y : Dy = (({Ay[0, 0]} * {Ay[1, 1]} * {Ay[2, 2]} + {Ay[0, 1]} * {Ay[1, 2]} * {Ay[2, 0]} + {Ay[0, 2]} * {Ay[1, 0]} * {Ay[2, 1]}) - ({Ay[0, 2]} * {Ay[1, 1]} * {Ay[2, 0]} + {Ay[0, 0]} * {Ay[1, 2]} * {Ay[2, 1]} + {Ay[0, 1]} * {Ay[1, 0]} * {Ay[2, 2]})) = {Dy}");
                        Console.WriteLine();
                        Console.WriteLine($" Y = (Dy / |A|) --->  Y = ({Dy} / {Det}) = ({Dy / Det})  --->  Y = ({Dy / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de Z : Dz = (({Az[0, 0]} * {Az[1, 1]} * {Az[2, 2]} + {Az[0, 1]} * {Az[1, 2]} * {Az[2, 0]} + {Az[0, 2]} * {Az[1, 0]} * {Az[2, 1]}) - ({Az[0, 2]} * {Az[1, 1]} * {Az[2, 0]} + {Az[0, 0]} * {Az[1, 2]} * {Az[2, 1]} + {Az[0, 1]} * {Az[1, 0]} * {Az[2, 2]})) = {Dz}");
                        Console.WriteLine();
                        Console.WriteLine($" Z = (Dz / |A|) --->  Z = ({Dz} / {Det}) = ({Dz / Det})  --->  Z = ({Dz / Det}) ");
                        Console.WriteLine();
                        for (int f = 0; f < ecu; f++)
                        {
                            for (int c = 0; c < 1; c++)
                            {
                                if (f == 0) { X[f, c] = Dx / Det; }
                                if (f == 1) { X[f, c] = Dy / Det; }
                                if (f == 2) { X[f, c] = Dz / Det; }
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine(" Presionar una tecla para continuar ...");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" Verificacion de Igualdad del sistema ");
                        Console.WriteLine(" =====================================");
                        Console.WriteLine();
                        Console.WriteLine();

                        suma1 = (X[0, 0] * A[0, 0]) + (X[1, 0] * A[0, 1]) + (X[2, 0] * A[0, 2]);
                        if (suma1 == b[0])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[0, 0]} * {X[0, 0]}) + ({A[0, 1]} * {X[1, 0]} ) + ({A[0, 2]} * {X[2, 0]}) = {b[0]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }

                        suma2 = (X[0, 0] * A[1, 0]) + (X[1, 0] * A[1, 1]) + (X[2, 0] * A[1, 2]);
                        if (suma2 == b[1])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[1, 0]} * {X[0, 0]}) + ({A[1, 1]} * {X[1, 0]}) + ({A[1, 2]} * {X[2, 0]}) = {b[1]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }

                        suma3 = (X[0, 0] * A[2, 0]) + (X[1, 0] * A[2, 1]) + (X[2, 0] * A[2, 2]);
                        if (suma3 == b[2])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[2, 0]} * {X[0, 0]}) + ({A[2, 1]} * {X[1, 0]}) + ({A[2, 2]} * {X[2, 0]}) = {b[2]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }
                        if ((suma1 == b[0]) && (suma2 == b[1]) && (suma3 == b[2]))
                        {
                            Console.WriteLine();
                            Console.WriteLine($"  Solucion del Sistema x = {X[0, 0]},  y = {X[1, 0]},  z = {X[2, 0]} ");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($" No se cumplen las igualdades por lo tanto el Sistemas Incompatible sin solucion ");
                            Console.WriteLine();
                        }
                    }
                    if (ecu == 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Calculo de las incognitas X, Y, Z, W y sus determinantes 4x4 con combinacion del Metodo de LaPlace + Sarrus");
                        Console.WriteLine();

                        Dx = Ax[0, 3] * (-1) * ((Ax[1, 0] * Ax[2, 1] * Ax[3, 2] + Ax[1, 1] * Ax[2, 2] * Ax[3, 0] + Ax[1, 2] * Ax[2, 0] * Ax[3, 1]) - (Ax[1, 2] * Ax[2, 1] * Ax[3, 0] + Ax[1, 0] * Ax[2, 2] * Ax[3, 1] + Ax[1, 1] * Ax[2, 0] * Ax[3, 2])) + Ax[1, 3] * (1) * ((Ax[0, 0] * Ax[2, 1] * Ax[3, 2] + Ax[0, 1] * Ax[2, 2] * Ax[3, 0] + Ax[0, 2] * Ax[2, 0] * Ax[3, 1]) - (Ax[0, 2] * Ax[2, 1] * Ax[3, 0] + Ax[0, 0] * Ax[2, 2] * Ax[3, 1] + Ax[0, 1] * Ax[2, 0] * Ax[3, 2])) + Ax[2, 3] * (-1) * ((Ax[0, 0] * Ax[1, 1] * Ax[3, 2] + Ax[0, 1] * Ax[1, 2] * Ax[3, 0] + Ax[0, 2] * Ax[1, 0] * Ax[3, 1]) - (Ax[0, 2] * Ax[1, 1] * Ax[3, 0] + Ax[0, 0] * Ax[1, 2] * Ax[3, 1] + Ax[0, 1] * Ax[1, 0] * Ax[3, 2])) + Ax[3, 3] * (1) * ((Ax[0, 0] * Ax[1, 1] * Ax[2, 2] + Ax[0, 1] * Ax[1, 2] * Ax[2, 0] + Ax[0, 2] * Ax[1, 0] * Ax[2, 1]) - (Ax[0, 2] * Ax[1, 1] * Ax[2, 0] + Ax[0, 0] * Ax[1, 2] * Ax[2, 1] + Ax[0, 1] * Ax[1, 0] * Ax[2, 2]));
                        Dy = Ay[0, 3] * (-1) * ((Ay[1, 0] * Ay[2, 1] * Ay[3, 2] + Ay[1, 1] * Ay[2, 2] * Ay[3, 0] + Ay[1, 2] * Ay[2, 0] * Ay[3, 1]) - (Ay[1, 2] * Ay[2, 1] * Ay[3, 0] + Ay[1, 0] * Ay[2, 2] * Ay[3, 1] + Ay[1, 1] * Ay[2, 0] * Ay[3, 2])) + Ay[1, 3] * (1) * ((Ay[0, 0] * Ay[2, 1] * Ay[3, 2] + Ay[0, 1] * Ay[2, 2] * Ay[3, 0] + Ay[0, 2] * Ay[2, 0] * Ay[3, 1]) - (Ay[0, 2] * Ay[2, 1] * Ay[3, 0] + Ay[0, 0] * Ay[2, 2] * Ay[3, 1] + Ay[0, 1] * Ay[2, 0] * Ay[3, 2])) + Ay[2, 3] * (-1) * ((Ay[0, 0] * Ay[1, 1] * Ay[3, 2] + Ay[0, 1] * Ay[1, 2] * Ay[3, 0] + Ay[0, 2] * Ay[1, 0] * Ay[3, 1]) - (Ay[0, 2] * Ay[1, 1] * Ay[3, 0] + Ay[0, 0] * Ay[1, 2] * Ay[3, 1] + Ay[0, 1] * Ay[1, 0] * Ay[3, 2])) + Ay[3, 3] * (1) * ((Ay[0, 0] * Ay[1, 1] * Ay[2, 2] + Ay[0, 1] * Ay[1, 2] * Ay[2, 0] + Ay[0, 2] * Ay[1, 0] * Ay[2, 1]) - (Ay[0, 2] * Ay[1, 1] * Ay[2, 0] + Ay[0, 0] * Ay[1, 2] * Ay[2, 1] + Ay[0, 1] * Ay[1, 0] * Ay[2, 2]));
                        Dz = Az[0, 3] * (-1) * ((Az[1, 0] * Az[2, 1] * Az[3, 2] + Az[1, 1] * Az[2, 2] * Az[3, 0] + Az[1, 2] * Az[2, 0] * Az[3, 1]) - (Az[1, 2] * Az[2, 1] * Az[3, 0] + Az[1, 0] * Az[2, 2] * Az[3, 1] + Az[1, 1] * Az[2, 0] * Az[3, 2])) + Az[1, 3] * (1) * ((Az[0, 0] * Az[2, 1] * Az[3, 2] + Az[0, 1] * Az[2, 2] * Az[3, 0] + Az[0, 2] * Az[2, 0] * Az[3, 1]) - (Az[0, 2] * Az[2, 1] * Az[3, 0] + Az[0, 0] * Az[2, 2] * Az[3, 1] + Az[0, 1] * Az[2, 0] * Az[3, 2])) + Az[2, 3] * (-1) * ((Az[0, 0] * Az[1, 1] * Az[3, 2] + Az[0, 1] * Az[1, 2] * Az[3, 0] + Az[0, 2] * Az[1, 0] * Az[3, 1]) - (Az[0, 2] * Az[1, 1] * Az[3, 0] + Az[0, 0] * Az[1, 2] * Az[3, 1] + Az[0, 1] * Az[1, 0] * Az[3, 2])) + Az[3, 3] * (1) * ((Az[0, 0] * Az[1, 1] * Az[2, 2] + Az[0, 1] * Az[1, 2] * Az[2, 0] + Az[0, 2] * Az[1, 0] * Az[2, 1]) - (Az[0, 2] * Az[1, 1] * Az[2, 0] + Az[0, 0] * Az[1, 2] * Az[2, 1] + Az[0, 1] * Az[1, 0] * Az[2, 2]));
                        Dw = Aw[0, 3] * (-1) * ((Aw[1, 0] * Aw[2, 1] * Aw[3, 2] + Aw[1, 1] * Aw[2, 2] * Aw[3, 0] + Aw[1, 2] * Aw[2, 0] * Aw[3, 1]) - (Aw[1, 2] * Aw[2, 1] * Aw[3, 0] + Aw[1, 0] * Aw[2, 2] * Aw[3, 1] + Aw[1, 1] * Aw[2, 0] * Aw[3, 2])) + Aw[1, 3] * (1) * ((Aw[0, 0] * Aw[2, 1] * Aw[3, 2] + Aw[0, 1] * Aw[2, 2] * Aw[3, 0] + Aw[0, 2] * Aw[2, 0] * Aw[3, 1]) - (Aw[0, 2] * Aw[2, 1] * Aw[3, 0] + Aw[0, 0] * Aw[2, 2] * Aw[3, 1] + Aw[0, 1] * Aw[2, 0] * Aw[3, 2])) + Aw[2, 3] * (-1) * ((Aw[0, 0] * Aw[1, 1] * Aw[3, 2] + Aw[0, 1] * Aw[1, 2] * Aw[3, 0] + Aw[0, 2] * Aw[1, 0] * Aw[3, 1]) - (Aw[0, 2] * Aw[1, 1] * Aw[3, 0] + Aw[0, 0] * Aw[1, 2] * Aw[3, 1] + Aw[0, 1] * Aw[1, 0] * Aw[3, 2])) + Aw[3, 3] * (1) * ((Aw[0, 0] * Aw[1, 1] * Aw[2, 2] + Aw[0, 1] * Aw[1, 2] * Aw[2, 0] + Aw[0, 2] * Aw[1, 0] * Aw[2, 1]) - (Aw[0, 2] * Aw[1, 1] * Aw[2, 0] + Aw[0, 0] * Aw[1, 2] * Aw[2, 1] + Aw[0, 1] * Aw[1, 0] * Aw[2, 2]));

                        Console.WriteLine();
                        Console.WriteLine($" Determinante del sistema |A| = {Det}");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de X : Dx = (({Ax[0, 3]} * (-1) * (({Ax[1, 0]} * {Ax[2, 1]} * {Ax[3, 2]} + {Ax[1, 1]} * {Ax[2, 2]} * {Ax[3, 0]} + {Ax[1, 2]} * {Ax[2, 0]} * {Ax[3, 1]}) - ({Ax[1, 2]} * {Ax[2, 1]} * {Ax[3, 0]} + {Ax[1, 0]} * {Ax[2, 2]} * {Ax[3, 1]} + {Ax[1, 1]} * {Ax[2, 0]} * {Ax[3, 2]})) + {Ax[1, 3]} * (1) * (({Ax[0, 0]} * {Ax[2, 1]} * {Ax[3, 2]} + {Ax[0, 1]} * {Ax[2, 2]} * {Ax[3, 0]} + {Ax[0, 2]} * {Ax[2, 0]} * {Ax[3, 1]}) - ({Ax[0, 2]} * {Ax[2, 1]} * {Ax[3, 0]} + {Ax[0, 0]} * {Ax[2, 2]} * {Ax[3, 1]} + {Ax[0, 1]} * {Ax[2, 0]} * {Ax[3, 2]})) + {Ax[2, 3]} * (-1) * (({Ax[0, 0]} * {Ax[1, 1]} * {Ax[3, 2]} + {Ax[0, 1]} * {Ax[1, 2]} * {Ax[3, 0]} + {Ax[0, 2]} * {Ax[1, 0]} * {Ax[3, 1]}) - ({Ax[0, 2]} * {Ax[1, 1]} * {Ax[3, 0]} + {Ax[0, 0]} * {Ax[1, 2]} * {Ax[3, 1]} + {Ax[0, 1]} * {Ax[1, 0]} * {Ax[3, 2]})) + {Ax[3, 3]} * (1) * (({Ax[0, 0]} * {Ax[1, 1]} * {Ax[2, 2]} + {Ax[0, 1]} * {Ax[1, 2]} * {Ax[2, 0]} + {Ax[0, 2]} * {Ax[1, 0]} * {Ax[2, 1]}) - ({Ax[0, 2]} * {Ax[1, 1]} * {Ax[2, 0]} + {Ax[0, 0]} * {Ax[1, 2]} * {Ax[2, 1]} + {Ax[0, 1]} * {Ax[1, 0]} * {Ax[2, 2]})))) = {Dx}");
                        Console.WriteLine();
                        Console.WriteLine($" X = (Dx / |A|) --->  X = ({Dx} / {Det}) = ({Dx / Det})  --->  X = ({Dx / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de Y : Dy = (({Ay[0, 3]} * (-1) * (({Ay[1, 0]} * {Ay[2, 1]} * {Ay[3, 2]} + {Ay[1, 1]} * {Ay[2, 2]} * {Ay[3, 0]} + {Ay[1, 2]} * {Ay[2, 0]} * {Ay[3, 1]}) - ({Ay[1, 2]} * {Ay[2, 1]} * {Ay[3, 0]} + {Ay[1, 0]} * {Ay[2, 2]} * {Ay[3, 1]} + {Ay[1, 1]} * {Ay[2, 0]} * {Ay[3, 2]})) + {Ay[1, 3]} * (1) * (({Ay[0, 0]} * {Ay[2, 1]} * {Ay[3, 2]} + {Ay[0, 1]} * {Ay[2, 2]} * {Ay[3, 0]} + {Ay[0, 2]} * {Ay[2, 0]} * {Ay[3, 1]}) - ({Ay[0, 2]} * {Ay[2, 1]} * {Ay[3, 0]} + {Ay[0, 0]} * {Ay[2, 2]} * {Ay[3, 1]} + {Ay[0, 1]} * {Ay[2, 0]} * {Ay[3, 2]})) + {Ay[2, 3]} * (-1) * (({Ay[0, 0]} * {Ay[1, 1]} * {Ay[3, 2]} + {Ay[0, 1]} * {Ay[1, 2]}* {Ay[3, 0]} + {Ay[0, 2]} * {Ay[1, 0]} * {Ay[3, 1]}) - ({Ay[0, 2]} * {Ay[1, 1]} * {Ay[3, 0]} + {Ay[0, 0]} * {Ay[1, 2]} * {Ay[3, 1]} + {Ay[0, 1]} * {Ay[1, 0]} * {Ay[3, 2]})) + {Ay[3, 3]} * (1) * (({Ay[0, 0]} * {Ay[1, 1]} * {Ay[2, 2]} + {Ay[0, 1]} * {Ay[1, 2]} * {Ay[2, 0]} + {Ay[0, 2]} * {Ay[1, 0]} * {Ay[2, 1]}) - ({Ay[0, 2]} * {Ay[1, 1]} * {Ay[2, 0]} + {Ay[0, 0]} * {Ay[1, 2]} * {Ay[2, 1]} + {Ay[0, 1]} * {Ay[1, 0]} * {Ay[2, 2]})))) = {Dy}");
                        Console.WriteLine();
                        Console.WriteLine($" Y = (Dy / |A|) --->  Y = ({Dy} / {Det}) = ({Dy / Det})  --->  Y = ({Dy / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de Z : Dz = (({Az[0, 3]} * (-1) * (({Az[1, 0]} * {Az[2, 1]} * {Az[3, 2]} + {Az[1, 1]} * {Az[2, 2]} * {Az[3, 0]} + {Az[1, 2]} * {Az[2, 0]} * {Az[3, 1]}) - ({Az[1, 2]} * {Az[2, 1]} * {Az[3, 0]} + {Az[1, 0]} * {Az[2, 2]} * {Az[3, 1]} + {Az[1, 1]} * {Az[2, 0]} * {Az[3, 2]})) + {Az[1, 3]} * (1) * (({Az[0, 0]} * {Az[2, 1]} * {Az[3, 2]} + {Az[0, 1]} * {Az[2, 2]} * {Az[3, 0]} + {Az[0, 2]} * {Az[2, 0]} * {Az[3, 1]}) - ({Az[0, 2]} * {Az[2, 1]} * {Az[3, 0]} + {Az[0, 0]} * {Az[2, 2]} * {Az[3, 1]} + {Az[0, 1]} * {Az[2, 0]} * {Az[3, 2]})) + {Az[2, 3]} * (-1) * (({Az[0, 0]} * {Az[1, 1]} * {Az[3, 2]} + {Az[0, 1]} * {Az[1, 2]} * {Az[3, 0]} + {Az[0, 2]} * {Az[1, 0]} * {Az[3, 1]}) - ({Az[0, 2]} * {Az[1, 1]} * {Az[3, 0]} + {Az[0, 0]} * {Az[1, 2]} * {Az[3, 1]} + {Az[0, 1]} * {Az[1, 0]} * {Az[3, 2]})) + {Az[3, 3]} * (1) * (({Az[0, 0]} * {Az[1, 1]} * {Az[2, 2]} + {Az[0, 1]} * {Az[1, 2]} * {Az[2, 0]} + {Az[0, 2]} * {Az[1, 0]} * {Az[2, 1]}) - ({Az[0, 2]} * {Az[1, 1]} * {Az[2, 0]} + {Az[0, 0]} * {Az[1, 2]} * {Az[2, 1]} + {Az[0, 1]} * {Az[1, 0]} * {Az[2, 2]})))) = {Dz}");
                        Console.WriteLine();
                        Console.WriteLine($" Z = (Dz / |A|) --->  Z = ({Dz} / {Det}) = ({Dz / Det})  --->  Z = ({Dz / Det}) ");
                        Console.WriteLine();
                        Console.WriteLine($" Determinante de W : Dw = (({Aw[0, 3]} * (-1) * (({Aw[1, 0]} * {Aw[2, 1]} * {Aw[3, 2]} + {Aw[1, 1]} * {Aw[2, 2]} * {Aw[3, 0]} + {Aw[1, 2]} * {Aw[2, 0]} * {Aw[3, 1]}) - ({Aw[1, 2]} * {Aw[2, 1]} * {Aw[3, 0]} + {Aw[1, 0]} * {Aw[2, 2]} * {Aw[3, 1]} + {Aw[1, 1]} * {Aw[2, 0]} * {Aw[3, 2]})) + {Aw[1, 3]} * (1) * (({Aw[0, 0]} * {Aw[2, 1]} * {Aw[3, 2]} + {Aw[0, 1]} * {Aw[2, 2]} * {Aw[3, 0]} + {Aw[0, 2]} * {Aw[2, 0]} * {Aw[3, 1]}) - ({Aw[0, 2]} * {Aw[2, 1]} * {Aw[3, 0]} + {Aw[0, 0]} * {Aw[2, 2]} * {Aw[3, 1]} + {Aw[0, 1]} * {Aw[2, 0]} * {Aw[3, 2]})) + {Aw[2, 3]} * (-1) * (({Aw[0, 0]} * {Aw[1, 1]} * {Aw[3, 2]} + {Aw[0, 1]} * {Aw[1, 2]} * {Aw[3, 0]} + {Aw[0, 2]} * {Aw[1, 0]} * {Aw[3, 1]}) - ({Aw[0, 2]} * {Aw[1, 1]} * {Aw[3, 0]} + {Aw[0, 0]} * {Aw[1, 2]} * {Aw[3, 1]} + {Aw[0, 1]} * {Aw[1, 0]} * {Aw[3, 2]})) + {Aw[3, 3]} * (1) * (({Aw[0, 0]} * {Aw[1, 1]} * {Aw[2, 2]} + {Aw[0, 1]} * {Aw[1, 2]} * {Aw[2, 0]} + {Aw[0, 2]} * {Aw[1, 0]} * {Aw[2, 1]}) - ({Aw[0, 2]} * {Aw[1, 1]} * {Aw[2, 0]} + {Aw[0, 0]} * {Aw[1, 2]} * {Aw[2, 1]} + {Aw[0, 1]} * {Aw[1, 0]} * {Aw[2, 2]})))) = {Dw}");
                        Console.WriteLine();
                        Console.WriteLine($" W = (Dw / |A|) --->  W = ({Dw} / {Det}) = ({Dw / Det})  --->  W = ({Dw / Det}) ");
                        Console.WriteLine();

                        for (int f = 0; f < ecu; f++)
                        {
                            for (int c = 0; c < 1; c++)
                            {
                                if (f == 0) { X[f, c] = Dx / Det; }
                                if (f == 1) { X[f, c] = Dy / Det; }
                                if (f == 2) { X[f, c] = Dz / Det; }
                                if (f == 3) { X[f, c] = Dw / Det; }
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine(" Presionar una tecla para continuar ...");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" Verificacion de Igualdad del sistema ");
                        Console.WriteLine(" =====================================");
                        Console.WriteLine();
                        Console.WriteLine();

                        suma1 = (X[0, 0] * A[0, 0]) + (X[1, 0] * A[0, 1]) + (X[2, 0] * A[0, 2]) + (X[3, 0] * A[0, 3]);
                        if (suma1 == b[0])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[0, 0]} * {X[0, 0]}) + ({A[0, 1]} * {X[1, 0]} ) + ({A[0, 2]} * {X[2, 0]}) + ({A[0, 3]} * {X[3, 0]}) = {b[0]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }

                        suma2 = (X[0, 0] * A[1, 0]) + (X[1, 0] * A[1, 1]) + (X[2, 0] * A[1, 2]) + (X[3, 0] * A[1, 3]);
                        if (suma2 == b[1])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[1, 0]} * {X[0, 0]}) + ({A[1, 1]} * {X[1, 0]}) + ({A[1, 2]} * {X[2, 0]}) + ({A[1, 3]} * {X[3, 0]})= {b[1]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }

                        suma3 = (X[0, 0] * A[2, 0]) + (X[1, 0] * A[2, 1]) + (X[2, 0] * A[2, 2]) + (X[3, 0] * A[2, 3]);
                        if (suma3 == b[2])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[2, 0]} * {X[0, 0]}) + ({A[2, 1]} * {X[1, 0]}) + ({A[2, 2]} * {X[2, 0]}) + ({A[2, 3]} * {X[3, 0]}) = {b[2]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }
                        suma4 = (X[0, 0] * A[3, 0]) + (X[1, 0] * A[3, 1]) + (X[2, 0] * A[3, 2]) + (X[3, 0] * A[3, 3]);
                        if (suma4 == b[3])
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   ({A[3, 0]} * {X[0, 0]}) + ({A[3, 1]} * {X[1, 0]}) + ({A[3, 2]} * {X[2, 0]}) + ({A[3, 3]} * {X[3, 0]}) = {b[3]}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Error - Sistema de ecuaciones no se cumple la igualdad .");
                            Console.WriteLine();
                        }
                        if ((suma1 == b[0]) && (suma2 == b[1]) && (suma3 == b[2]) && (suma4 == b[3]))
                        {
                            Console.WriteLine();
                            Console.WriteLine($"  Solucion del Sistema x = {X[0, 0]},  y = {X[1, 0]},  z = {X[2, 0]} ");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($" No se cumplen las igualdades por lo tanto el Sistemas Incompatible sin solucion ");
                            Console.WriteLine();
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(" El sistema no cumple con las condiciones necesarias para usar Metodo de Cramer");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ===============");
            Console.WriteLine(" Fin del Proceso");
            Console.WriteLine(" ===============");
            Console.ReadKey();
        }
    }
}
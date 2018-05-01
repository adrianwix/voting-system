using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {

            int votoA = 0;
            int votoB = 0;
            int votoNulo = 0;
            int votantes = 0;

            byte[,] apartamentoA = new byte[10, 2] { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 } };
            byte[,] apartamentoB = new byte[10, 2] { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 } };

            ProcesoElectoral(ref votoA, ref votoB, ref votoNulo, ref votantes, ref apartamentoA, ref apartamentoB);
        } //CIERRE DE MAIN

        static void ProcesoElectoral(ref int votoA, ref int votoB, ref int votoNulo, ref int votantes, ref byte[,] apartamentoA, ref byte[,] apartamentoB)
        {
        Comienzo:
            int quedanPersonas;

            bool NoVoto;
            bool genteSinVotar;

            byte piso;
            string apartamento;
            string voto;

            Bienvenida();
            piso = ingresePiso();
            apartamento = ingreseApto();

            Console.WriteLine("Bienvenido {0}{1}", piso, apartamento);

            NoVoto = validarVotante(piso, apartamento, apartamentoA, apartamentoB);

            if (NoVoto)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Por favor ingrese su voto");
                Console.WriteLine("=========================");
                voto = Console.ReadLine();
                Console.WriteLine("=========================");

                switch (voto)
                {
                    case "A":
                    case "a":
                        if (apartamento == "A")
                        {
                            apartamentoA[(piso - 1), 1] = setVoto("A");
                        }
                        else
                        {
                            apartamentoB[(piso - 1), 1] = setVoto("A");
                        }
                        votoA++;
                        votantes++;
                        break;

                    case "B":
                    case "b":
                        if (apartamento == "A")
                        {
                            apartamentoA[(piso - 1), 1] = setVoto("B");
                        }
                        else
                        {
                            apartamentoB[(piso - 1), 1] = setVoto("B");
                        }
                        votoB++;
                        votantes++;
                        break;

                    default:
                        if (apartamento == "A")
                        {
                            apartamentoA[(piso - 1), 1] = setVoto("Nulo");
                        }
                        else
                        {
                            apartamentoB[(piso - 1), 1] = setVoto("Nulo");
                        }
                        votoNulo++;
                        votantes++;
                        break;
                } //FIN DEL SWITCH

            }
            else
            {
                //
                //DESEA CERRAR VOTACION?
                //
            }

            genteSinVotar = genteNoVotar(votantes);
            if (genteSinVotar)
            {
                Console.WriteLine("Si aun quedan personas por votar ingrese 1");
                Console.WriteLine("Si no quedan mas votantes ingrese 2");
                quedanPersonas = Convert.ToInt32(Console.ReadLine());

                if (quedanPersonas == 1)
                {
                    goto Comienzo;
                }
                else if (quedanPersonas == 2)
                {
                    resultadosCNE(votoA, votoB, votoNulo, apartamentoA, apartamentoB);
                }
            }
            else
            {
                resultadosCNE(votoA, votoB, votoNulo, apartamentoA, apartamentoB);
            }

        } //CIERRE DE PROCESO ELECTORAL

        static void Bienvenida()
        {

            Console.WriteLine("==============================================================");
            Console.WriteLine("Bienvenido a las Elecciones para la presidencia del condominio");
            Console.WriteLine("=========================");
            Console.WriteLine("Los Candidatos son: A y B");
            Console.WriteLine("=======================================");
            Console.WriteLine("Las pautas a seguir son las siguientes:");
            Console.WriteLine("==============================================================================");
            Console.WriteLine("1- Debe escoger entre el candidato A o B, de lo contrario el voto sera Anulado");
            Console.WriteLine("2- Debe ingresar un numero de apartamento valido ");
            Console.WriteLine("3- Solo puede votar una vez");
            Console.WriteLine("=========================================");
            Console.WriteLine("Para empezar con la votacion oprima ENTER");
            Console.ReadKey();

        } //Cierre funcion

        static byte setVoto(string voto)
        {
            switch (voto)
            {
                case "A":
                    return 1;
                    break;
                case "B":
                    return 2;
                    break;
                default:
                    return 3;
                    break;
            }
        }
        static string getVoto(byte voto)
        {
            switch (voto)
            {
                case 1:
                    return "A";
                    break;
                case 2:
                    return "B";
                    break;
                default:
                    return "Nulo";
                    break;
            }
        }

        static byte ingresePiso()
        {
            byte piso;
            Console.WriteLine("Ingrese su piso");
            piso = Convert.ToByte(Console.ReadLine());
            piso = Cpiso(piso);
            return piso;
        } // CIERRE DE ingresePiso

        static string ingreseApto()
        {
            string apartamento;
            Console.WriteLine("Ingrese Apartamento");
            apartamento = Console.ReadLine();
            apartamento = Capartamento(apartamento);
            return apartamento;
        } //CIERRE DE ingreseApto()

        static byte Cpiso(byte piso)
        {

            if ((piso >= 1) && (piso <= 10))
            {
                return piso;
            }
            else
            {
                Console.WriteLine("El piso es incorrecto, presione ENTER para intentelo de nuevo");
                Console.ReadKey();
                return ingresePiso();
            }

        } //CIERRE DE Cpiso()

        static string Capartamento(string apartamento)
        {
            if ((apartamento == "A") || (apartamento == "B"))
            {
                return apartamento;
            }
            else if ((apartamento == "a") || (apartamento == "b"))
            {
                apartamento = apartamento.ToUpper();
                return apartamento;
            }
            else
            {
                Console.WriteLine("El apartamento es incorrecto, presione ENTER para intentelo de nuevo");
                Console.ReadKey();
                return ingreseApto();
            }

        } //CIERRE DE Capartamento()

        static bool validarVotante(int piso, string apartamento, byte[,] apartamentoA, byte[,] apartamentoB)
        {
            int i;
            if (apartamento == "A")
            {
                i = piso - 1;
                if (apartamentoA[i, 1] == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Usted ya voto!");
                    return false;
                }
            }
            else
            {
                i = piso - 1;
                if (apartamentoB[i, 1] == 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Usted ya voto!");
                    return false;
                }
            }

        } // CIERRE DE validarVotante()

        static bool genteNoVotar(int votantes)
        {
            if (votantes == 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        } // CIERRE DE genteSinVotar()

        static void resultadosCNE(int votoA, int votoB, int votoNulo, byte[,] apartamentoA, byte[,] apartamentoB)
        {
            float porcentajeTotal;
            float porcentajeA;
            float porcentajeB;
            float porcentajeNulo;
            int votantes;

            Console.WriteLine("================================");
            Console.WriteLine("Resultados del proceso electoral");
            Console.WriteLine("================================");

            if (votoA > votoB)
            {
                Console.WriteLine("El ganador es el candidato A con: {0} votos", votoA);
                Console.WriteLine("====================================================");
            }
            else if (votoB > votoA)
            {
                Console.WriteLine("El ganador es el candidato B con: {0} votos", votoB);
                Console.WriteLine("=====================================================");
            }
            else
            {
                Console.WriteLine("Hay empate entre los dos candidatos");
                Console.WriteLine("===================================");
            }

            votantes = votoA + votoB + votoNulo;
            Console.WriteLine("El total de votantes fue de: {0} votantes", votantes);
            Console.WriteLine("=========================================");

            Console.WriteLine("La cantidad de votos nulos es de: {0} votos", votoNulo);
            Console.WriteLine("===========================================");

            porcentajeTotal = (votantes * 100) / 20;
            porcentajeA = (votoA * 100) / votantes;
            porcentajeB = (votoB * 100) / votantes;
            porcentajeNulo = (votoNulo * 100) / votantes;
            Console.WriteLine("El porcentaje de participacion fue de: {0}%", porcentajeTotal);
            Console.WriteLine("===========================================");
            Console.WriteLine("El {0}% de los votantes voto por A, es decir: {1} votos", porcentajeA, votoA);
            Console.WriteLine("======================================================");
            Console.WriteLine("El {0}% de los votantes voto por B, es decir: {1} votos", porcentajeB, votoB);
            Console.WriteLine("======================================================");
            Console.WriteLine("El {0}% tuvo voto nulo, es decir: {1} votos", porcentajeNulo, votoNulo);
            Console.WriteLine("======================================================");

            int Auditoria = 0;
            Console.WriteLine("Para acceder a las Auditorias ingrese 3");
            Auditoria = Convert.ToInt32(Console.ReadLine());

            if (Auditoria == 3)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Auditoria del proceso Electoral");
                Console.WriteLine("===============================");
                for (int w = 0; w < 10; w++)
                {
                    if (apartamentoA[w, 1] != 0)
                    {
                        Console.WriteLine("El votante del {0}A voto por: {1}", apartamentoA[w, 0], getVoto(apartamentoA[w, 1]));
                    }
                    if (apartamentoB[w, 1] != 0)
                    {
                        Console.WriteLine("El votante del {0}B voto por: {1}", apartamentoB[w, 0], getVoto(apartamentoB[w, 1]));
                    }
                }
                Console.WriteLine("=========================");
                Console.WriteLine("Fin del Proceso Electoral");
                Console.WriteLine("=========================");
            }
            Console.ReadKey();
        }

    }
}

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra2ExamenP1_VisualStudio
{
    internal class Game : MonoBehaviour
    {
        /*
        List<Enemies> enemigos = new List<Enemies>();
        public List<Tower> torresConstruidas = new List<Tower>();
        public static Game Instance => instance;
        private static readonly Game instance = new Game();
        
        void Start()
        {
        }
        void Update()
        {
        
        }
        public void Execute()
        {
            Console.WriteLine("Bienvenido al juego de torres de defensa.");
            AbrirMenu();
            enemigos.Add(new Enemies());
            enemigos.Add(new Enemies());
        }
        void AbrirMenu()
        {
            bool ContinueFlag = true;
            while (ContinueFlag)
            {
                Console.WriteLine("Abriendo menú...");
                Console.WriteLine("Que deseas hacer?");
                Console.WriteLine("1. Abrir Tienda.");
                Console.WriteLine("2. Mostrar Torres ya construidas.");
                Console.WriteLine("3. Destruir Torre.");
                Console.WriteLine("4. Terminar Turno.");
                Console.WriteLine("5. Salir del juego.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        MostrarTiposTorres();
                        break;
                    case 2:
                        MostrarTorresConstruidas();
                        break;
                    case 3:
                        DestruirTorre();
                        break;
                    case 4:
                        TerminarTurno();
                        break;
                    case 5:
                        Application.Quit();
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
        void MostrarTiposTorres()
        {
            bool ContinueFlag = true;
            while (ContinueFlag)
            {
                Console.WriteLine("Abriendo tienda...");
                Console.WriteLine($"Oro disponible: {oro}");
                Console.WriteLine("Que deseas hacer?");
                Console.WriteLine("1. Torre Pequeña.");
                Console.WriteLine("2. Torre Fuerte.");
                Console.WriteLine("3. Cerrar Tienda.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ConstruirTorrePequeña();
                        break;
                    case 2:
                        ConstruirTorreFuerte();
                        break;
                    case 3:
                        Console.WriteLine("Cerrando tienda...");
                        ContinueFlag = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
        void MostrarTorresConstruidas()
        {
            if (torresConstruidas.Count == 0)
            {
                Console.WriteLine("No hay torres construidas.");
            }
            else
            {
                Console.WriteLine("Torres construidas:");
                for (int i = 0; i < torresConstruidas.Count; i++)
                {
                    Console.WriteLine($"Torre {i}: {torresConstruidas[i].Nombre}, Nivel: {torresConstruidas[i].Nivel}, Daño: {torresConstruidas[i].Daño}");
                }
            }
        }
        void ConstruirTorrePequeña()
        {
            if (oro >= 100)
            {
                torresConstruidas.Add(new SmallTower());
                oro -= 100;
                Console.WriteLine($"Oro disponible: {oro}");
            }

        }
        void ConstruirTorreFuerte()
        {
            if (oro >= 200)
            {
                torresConstruidas.Add(new BuffTower());
                oro -= 200;
                Console.WriteLine($"Oro disponible: {oro}");
            }
        }
        void DestruirTorre()
        {
            Console.WriteLine("Que torre deseas destruir?");
            for (int i = 0; i < torresConstruidas.Count; i++)
            {
                Console.WriteLine($"Torre {i}: {torresConstruidas[i].Nombre}, Nivel: {torresConstruidas[i].Nivel}, Daño: {torresConstruidas[i].Daño}");
            }
            int option = int.Parse(Console.ReadLine());
            if (option >= 0 && option < torresConstruidas.Count)
            {
                torresConstruidas.RemoveAt(option);
                Console.WriteLine("Torre destruida.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
        void TerminarTurno()
        {
            Console.WriteLine("Turno de las torres.");
            foreach (Tower torre in torresConstruidas)
            {
                torre.Atacar();
            }
            Console.WriteLine("Turno del enemigo.");
            foreach (Enemies enemigo in enemigos)
            {
                enemigo.Atacar();
            }
            Console.WriteLine("Turno del Jugador.");

        }
        */
    }
}
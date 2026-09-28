using UnityEngine;
using System;
public class Game : MonoBehaviour
{
    int oro = 0;
    List<Tower> torresConstruidas = new List<Tower>();
    public void Execute()
    {
        Console.WriteLine("Bienvenido al juego de torres de defensa.");
        AbrirMenu();
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
        AbrirMenu();
    }
    void MostrarTorresConstruidas()
    {
        /*
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
        */
    }
    void ConstruirTorrePequeña()
    {
        if (oro >= 100)
        {
            //torresConstruidas.Add(new TorrePequeña());
            oro -= 100;
        }

    }
    void ConstruirTorreFuerte()
    {
        if (oro >= 200)
        {
            //torresConstruidas.Add(new TorreFuerte());
            oro -= 200;
        }
    }
    void DestruirTorre()
    {
        /*
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
        */
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Execute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

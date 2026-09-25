
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    private int vidaMaxima;
    private int vidaActual;
    public int VidaMaxima { get; private set; }
    public int VidaActual { get; set; }
    protected int dano;
    public int Dano { get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaMaxima = ObtenerValorFibonacciAleatorio();
        vidaActual = vidaMaxima;
        dano = ObtenerValorFibonacciAleatorio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Entities(int vidaMaxima, int daño)
    {

    }
    public virtual void Atacar()
    {
        // ...
    }
    public virtual int ObtenerDano()
    {
        return dano;
    }

    public virtual void RecibirDano(int dano)
    {
        // ...
    }
    private int ObtenerValorFibonacciAleatorio()
    {
        int numTerminos = 12;
        List<int> fibonacci = GenerarFibonacci(numTerminos);
        int valRandom = Random.Range(2, numTerminos); // Rango entre índice 2 y 11
        return fibonacci[valRandom];
    }
    private List<int> GenerarFibonacci(int n)
    {
        List<int> fibonacci = new List<int>();
        int a = 0;
        int b = 1;
        for (int i = 0; i < n; i++)
        {
            fibonacci.Add(a);
            int temp = a;
            a = b;
            b = temp + b;
        }
        return fibonacci;
    }
}

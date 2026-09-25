using System;
using UnityEngine;

public class Enemies : Entities
{
    private bool estaVivo;
    private bool yaImprimiMuerte;
    private int vecesQueRecibioDano;
    public Enemies(int vidaMaxima, int dano) : base(vidaMaxima, dano)
    {
        this.estaVivo = true;
        this.yaImprimiMuerte = false;
        this.vecesQueRecibioDano = 0;

        Console.WriteLine("Se creo un enemigo con " + vidaMaxima + " de vida y " + dano + " de daño");
    }
    public override void Atacar()
    {
        //jugador.VidaActual = jugador.VidaActual - this.dano;
        //Torre.VidaActual = Torre.VidaActual - this.dano;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Atacar();
        }
    }
    public override void RecibirDano(int cantidad)
    {
        this.vecesQueRecibioDano = this.vecesQueRecibioDano + 1;

        if (cantidad < 0)
        {
            Console.WriteLine("ERROR: no se puede recibir daño negativo");
            return;
        }

        int vidaAntes = this.VidaActual;
        this.VidaActual = this.VidaActual - cantidad;

        Console.WriteLine("El enemigo recibio " + cantidad + " de daño");
        Console.WriteLine("Vida antes: " + vidaAntes);
        Console.WriteLine("Vida ahora: " + this.VidaActual);

        if (this.VidaActual <= 0)
        {
            this.VidaActual = 0;
            this.estaVivo = false;

            if (this.yaImprimiMuerte == false)
            {
                Console.WriteLine("*** El enemigo ha muerto ***");
                this.yaImprimiMuerte = true;
            }
            else
            {
                Console.WriteLine("El enemigo ya estaba muerto, no hace falta pegarle mas");
            }
        }
        else
        {
            Console.WriteLine("Al enemigo le quedan " + this.VidaActual + " puntos de vida");
        }

        Console.WriteLine("----------------------------------------");
    }

    public int GetDano()
    {
        int danoQueVoyARetornar = this.dano;
        return danoQueVoyARetornar;
    }

    public bool EstaVivo()
    {
        if (this.VidaActual > 0)
        {
            return true;
        }
        else if (this.VidaActual == 0)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine("===== ESTADO DEL ENEMIGO =====");
        Console.WriteLine("Vida: " + this.VidaActual);
        Console.WriteLine("Daño: " + this.dano);

        if (this.estaVivo == true)
        {
            Console.WriteLine("Estado: VIVO");
        }
        else
        {
            Console.WriteLine("Estado: MUERTO");
        }

        Console.WriteLine("Veces que recibio daño: " + this.vecesQueRecibioDano);
        Console.WriteLine("=====================================");
    }
}

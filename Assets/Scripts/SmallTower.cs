using UnityEngine;

public class SmallTower : Tower
{
    [SerializeField] private float bonificadorVelocidadAtaque = 0.5f;

    public SmallTower(string nombre, int vida, int dano) : base(nombre, vida, dano)
    {
        this.tiempoEntreAtaques = 0.8f;
    }

    public override void AtacarEnemigoActual()
    {
        if (VidaActual <= 0)
        {
            Debug.Log($"{nombreTorre} está destruida y no puede atacar");
            return;
        }

        if (enemigoObjetivo != null)
        {
            Debug.Log($"{nombreTorre} dispara ráfaga rápida causando {dano} de daño");
            DispararProyectil();
        }
    }

    public override void MejorarTorre()
    {
        base.MejorarTorre();

        tiempoEntreAtaques -= 0.1f;

        if (tiempoEntreAtaques < 0.2f)
        {
            tiempoEntreAtaques = 0.2f;
        }

        Debug.Log($"{nombreTorre} ahora dispara cada {tiempoEntreAtaques} + segundos");
    }
}

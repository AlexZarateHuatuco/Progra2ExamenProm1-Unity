using UnityEngine;

public class BuffTower : Tower
{
    [SerializeField] private int bonificadorDano = 5;

    public BuffTower(string nombre, int vida, int dano) : base(nombre, vida, dano)
    {
        this.tiempoEntreAtaques = 3f;
    }

    public override void AtacarEnemigoActual()
    {
        if (VidaActual <= 0)
        {
            Debug.Log($"{nombreTorre} está destruida y no puede otorgar bonificaciones");
            return;
        }

        if (enemigoObjetivo != null)
        {
            Debug.Log($"{nombreTorre} realiza un ataque pesado causando {dano} de daño");
            DispararProyectil();
        }
    }

    public override void MejorarTorre()
    {
        base.MejorarTorre();

        dano += bonificadorDano;

        Debug.Log($"{nombreTorre} aumentó su poder. Nuevo daño pesado: {dano}");
    }
}

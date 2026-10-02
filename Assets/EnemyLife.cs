using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public float saludMaxima = 10f;
    private float saludActual;

    [Header("Configuración de Daño")]
    public float danoPorBala = 10f;
    public float danoPorTorre = 10f;

    private void Start()
    {
        saludActual = saludMaxima;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            RecibirDano(danoPorBala);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Tower"))
        {
            RecibirDano(danoPorTorre);
        }
    }

    private void RecibirDano(float cantidad)
    {
        saludActual -= cantidad;

        if (saludActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}
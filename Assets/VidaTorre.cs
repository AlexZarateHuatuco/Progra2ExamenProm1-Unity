using UnityEngine;

public class VidaTorre : MonoBehaviour
{
    public int vida= 10;
    public void RecibirDanio(int danio)
    {
        vida -= danio;
        Morir();
    }
    private void Update()
    {
    }
    void Morir()
    {
        if (vida <= 0)
        {
            Debug.Log("La torre ha sido destruida");
            Destroy(gameObject);
        }
    }
}
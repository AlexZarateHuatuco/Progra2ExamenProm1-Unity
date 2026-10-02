using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int danio = 10;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡ALGO TOCÓ AL ENEMIGO!: " + other.gameObject.name);
        if (other.CompareTag("Tower"))
        {
            VidaTorre vida = other.GetComponent<VidaTorre>();
            if (vida != null)
            {
                vida.RecibirDanio(danio);
            }
            Debug.Log("Enemigo explotó al impactar la torre.");
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
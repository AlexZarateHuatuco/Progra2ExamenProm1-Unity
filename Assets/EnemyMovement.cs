using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 3f;
    private Transform torreObjetivo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BuscarTorreMasCercana();
    }

    void FixedUpdate()
    {
        if (torreObjetivo != null)
        {
            Vector3 direccion = (torreObjetivo.position - transform.position).normalized;
            rb.linearVelocity = direccion * velocidad;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            BuscarTorreMasCercana();
        }
    }

    void BuscarTorreMasCercana()
    {
        GameObject[] torres = GameObject.FindGameObjectsWithTag("Tower");
        if (torres.Length == 0)
        {
            return;
        }
        GameObject torreMasCercana = torres[0];
        float distanciaMasCorta = Vector3.Distance(transform.position, torreMasCercana.transform.position);
        for (int i = 1; i < torres.Length; i++)
        {
            float distanciaATorre = Vector3.Distance(transform.position, torres[i].transform.position);
            if (distanciaATorre < distanciaMasCorta)
            {
                distanciaMasCorta = distanciaATorre;
                torreMasCercana = torres[i];
            }
        }
        torreObjetivo = torreMasCercana.transform;
    }
}

using UnityEngine;

public class Tower : Entities
{
    protected string nombreTorre;
    protected int nivel;

    [SerializeField] protected float rangoAtaque = 8f;
    [SerializeField] protected float tiempoEntreAtaques = 1.5f;
    [SerializeField] protected GameObject prefabBala;
    [SerializeField] protected Transform spawnPoint;

    protected float contadorAtaque = 0f;
    protected Transform enemigoObjetivo;

    public Tower(string nombre, int vida, int dano) : base(vida, dano)
    {
        this.nombreTorre = nombre;
        this.nivel = 1;
    }

    protected virtual void Update()
    {
        if (VidaActual <= 0)
        {
            return;
        }

        BuscarEnemigoCercano();

        contadorAtaque += Time.deltaTime;
        if (contadorAtaque >= tiempoEntreAtaques && enemigoObjetivo != null)
        {
            AtacarEnemigoActual();
            contadorAtaque = 0f;
        }
    }

    protected virtual void BuscarEnemigoCercano()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangoAtaque);
        float distanciaMasCercana = Mathf.Infinity;
        Transform objetivoCercano = null;

        foreach (Collider elementoDetectado in colliders)
        {
            Enemies enemigo = elementoDetectado.GetComponent<Enemies>();

            if (enemigo != null && enemigo.EstaVivo())
            {
                float distancia = Vector3.Distance(transform.position, elementoDetectado.transform.position);

                if (distancia < distanciaMasCercana)
                {
                    distanciaMasCercana = distancia;
                    objetivoCercano = elementoDetectado.transform;
                }
            }
        }

        enemigoObjetivo = objetivoCercano;

    }

    //Fibonacci
    public int CalcularFibonacci(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        int a = 0;
        int b = 1;
        int c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }

    public virtual void MejorarTorre()
    {
        int costo = CalcularFibonacci(nivel + 1) * 50;

        Debug.Log($"Mejorando torre: {nombreTorre}");
        Debug.Log($"Nivel actual: {nivel} | Costo: {costo} oro (Escalado Fibonacci Nivel {nivel + 1}");

        nivel++;
        dano += 15;
        VidaActual += 50;

        Debug.Log($"{nombreTorre} subió al Nivel {nivel}!  (Nuevo Daño: {dano}, Nueva Vida: {VidaActual}");
    }

    public virtual void AtacarEnemigoActual()
    {
        if (VidaActual <= 0)
        {
            Debug.Log($"{nombreTorre} está destruida y no puede atacar");
            return;
        }

        if (enemigoObjetivo != null)
        {
            Debug.Log($"{nombreTorre} ataca a un enemigo causando {dano} de daño");
            DispararProyectil();
        }
    }

    protected virtual void DispararProyectil()
    {
        if (prefabBala == null)
        {
            return;
        }

        Vector3 puntoOrigen;

        if(spawnPoint != null)
        {
            puntoOrigen = spawnPoint.position;
        }
        else
        {
            puntoOrigen = transform.position;
        }

        GameObject nuevaBala = Instantiate(prefabBala, puntoOrigen, Quaternion.identity);
    }

    public override void RecibirDano(int cantidad)
    {
        if (cantidad <= 0)
        {
            return;
        }

        VidaActual -= cantidad;

        if (VidaActual <= 0)
        {
            VidaActual = 0;
            Debug.Log($"{nombreTorre} ha sido destruida");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{nombreTorre} recibió {cantidad} de daño. Vida restante: {VidaActual}");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}

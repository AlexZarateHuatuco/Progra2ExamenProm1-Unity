using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panelTorres;

    [Header("Grilla")]
    [SerializeField] private GridManager gridManager;

    [Header("Prefabs")]
    [SerializeField] private GameObject smallTowerPrefab;
    [SerializeField] private GameObject buffTowerPrefab;

    [Header("Guía visual")]
    [SerializeField] private GameObject guiaVisualPrefab;

    private GameObject prefabSeleccionado;
    private GameObject guiaVisual;

    private bool colocandoTorre = false;
    private Vector2Int celdaActual;
    private bool celdaValida = false;

    public void SeleccionarSmallTower()
    {
        prefabSeleccionado = smallTowerPrefab;
        IniciarColocacion();
    }

    public void SeleccionarBuffTower()
    {
        prefabSeleccionado = buffTowerPrefab;
        IniciarColocacion();
    }

    private void IniciarColocacion()
    {
        if (prefabSeleccionado == null)
        {
            Debug.LogWarning("No se ha asignado el prefab de la torre.");
            return;
        }

        colocandoTorre = true;

        panelTorres.SetActive(false);

        CrearGuiaVisual();

        Debug.Log("Modo colocación: " + prefabSeleccionado.name);
    }

    private void Update()
    {
        if (!colocandoTorre)
            return;

        ActualizarGuiaVisual();

        if (Input.GetMouseButtonDown(0))
        {
            IntentarColocarTorre();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CancelarColocacion();
        }
    }

    private void ActualizarGuiaVisual()
    {
        if (guiaVisual == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            guiaVisual.SetActive(false);
            celdaValida = false;
            return;
        }

        Vector2Int celda = gridManager.WorldToCell(hit.point);

        if (!gridManager.IsInside(celda))
        {
            guiaVisual.SetActive(false);
            celdaValida = false;
            return;
        }

        celdaActual = celda;
        celdaValida = true;

        Vector3 posicion = gridManager.CellToWorld(
            celda.x,
            celda.y
        );

        guiaVisual.transform.position = posicion;
        guiaVisual.SetActive(true);
    }

    private void CrearGuiaVisual()
    {
        if (guiaVisualPrefab == null)
        {
            Debug.LogWarning(
                "No se ha asignado el prefab de la guía visual."
            );

            return;
        }

        guiaVisual = Instantiate(
            guiaVisualPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        guiaVisual.SetActive(false);
    }

    private void IntentarColocarTorre()
    {
        if (!celdaValida)
            return;

        Vector3 posicion = gridManager.CellToWorld(
            celdaActual.x,
            celdaActual.y
        );

        GameObject nuevaTorre = Instantiate(
            prefabSeleccionado,
            posicion,
            Quaternion.identity
        );

        Debug.Log(
            "Torre colocada en la celda: " +
            celdaActual.x + ", " + celdaActual.y
        );

        FinalizarColocacion();
    }

    private void CancelarColocacion()
    {
        FinalizarColocacion();

        Debug.Log("Colocación cancelada.");
    }

    private void FinalizarColocacion()
    {
        colocandoTorre = false;
        prefabSeleccionado = null;
        celdaValida = false;

        if (guiaVisual != null)
        {
            Destroy(guiaVisual);
            guiaVisual = null;
        }

        panelTorres.SetActive(true);
    }
}
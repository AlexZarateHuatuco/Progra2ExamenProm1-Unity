using UnityEngine;

public class PanelTorres : MonoBehaviour
{
    public enum TipoTorre
    {
        SmallTower,
        BuffTower
    }

    private TipoTorre torreSeleccionada;

    public void SeleccionarSmallTower()
    {
        torreSeleccionada = TipoTorre.SmallTower;
        Debug.Log("SmallTower seleccionada");
    }

    public void SeleccionarBuffTower()
    {
        torreSeleccionada = TipoTorre.BuffTower;
        Debug.Log("BuffTower seleccionada");
    }

    public TipoTorre ObtenerTorreSeleccionada()
    {
        return torreSeleccionada;
    }
}

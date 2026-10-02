using UnityEngine;

/// <summary>
/// Grilla configurable que se dibuja con Gizmos en la Scene View.
/// Añádelo a un GameObject vacío y ajusta los valores en el Inspector.
/// </summary>
public class GridManager : MonoBehaviour
{
    public enum GridPlane { XZ, XY }

    [Min(1)] public int columns = 10;
    [Min(1)] public int rows = 10;
    [Min(0.01f)] public float cellSize = 1f;

    public GridPlane plane = GridPlane.XZ;

    public Color lineColor = new Color(1f, 1f, 1f, 0.6f);
    public bool showCellCenters = false;
    public Color centerColor = Color.green;
    [Range(0.01f, 0.5f)] public float centerRadius = 0.08f;
    public bool onlyWhenSelected = false;

    private void OnDrawGizmos()
    {
        if (!onlyWhenSelected) DrawGrid();
    }

    private void OnDrawGizmosSelected()
    {
        if (onlyWhenSelected) DrawGrid();
    }

    private void DrawGrid()
    {
        Gizmos.color = lineColor;

        for (int x = 0; x <= columns; x++)
        {
            Vector3 start = GetCornerWorldPosition(x, 0);
            Vector3 end = GetCornerWorldPosition(x, rows);
            Gizmos.DrawLine(start, end);
        }

        for (int y = 0; y <= rows; y++)
        {
            Vector3 start = GetCornerWorldPosition(0, y);
            Vector3 end = GetCornerWorldPosition(columns, y);
            Gizmos.DrawLine(start, end);
        }

        if (showCellCenters)
        {
            Gizmos.color = centerColor;
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Gizmos.DrawSphere(CellToWorld(x, y), centerRadius * cellSize);
                }
            }
        }
    }

    private Vector3 GetCornerWorldPosition(int x, int y)
    {
        Vector3 local = plane == GridPlane.XZ
            ? new Vector3(x * cellSize, 0f, y * cellSize)
            : new Vector3(x * cellSize, y * cellSize, 0f);

        return transform.TransformPoint(local);
    }

    public Vector3 CellToWorld(int x, int y)
    {
        float cx = (x + 0.5f) * cellSize;
        float cy = (y + 0.5f) * cellSize;

        Vector3 local = plane == GridPlane.XZ
            ? new Vector3(cx, 0f, cy)
            : new Vector3(cx, cy, 0f);

        return transform.TransformPoint(local);
    }

    public Vector2Int WorldToCell(Vector3 worldPos)
    {
        Vector3 local = transform.InverseTransformPoint(worldPos);

        int x = Mathf.FloorToInt(local.x / cellSize);
        int y = Mathf.FloorToInt((plane == GridPlane.XZ ? local.z : local.y) / cellSize);

        return new Vector2Int(x, y);
    }

    public bool IsInside(Vector2Int cell)
    {
        return cell.x >= 0 && cell.x < columns && cell.y >= 0 && cell.y < rows;
    }
}
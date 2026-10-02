using TMPro;
using UnityEngine;
public class ActualizarTextoOro : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI TextoOro;
    void Update()
    {
        UpdateOro();
    }
    void UpdateOro()
    {
        TextoOro.text = "Oro: " + score.ToString();
    }
}
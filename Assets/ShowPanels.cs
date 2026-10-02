using UnityEngine;
public class ShowPanels : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelCanvasGroup;
    public void ShowPanel()
    {
        panelCanvasGroup.alpha = 1f;
        panelCanvasGroup.blocksRaycasts = true;
        panelCanvasGroup.interactable = true;
    }
    public void HidePanel()
    {
        panelCanvasGroup.alpha = 0f;
        panelCanvasGroup.blocksRaycasts = false;
        panelCanvasGroup.interactable = false;
    }
}
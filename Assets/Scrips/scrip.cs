using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private Canvas uiCanvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            uiCanvas.enabled = !uiCanvas.enabled;
        }
    }
}
//using UnityEngine;

//public class ToggleUI : MonoBehaviour
//{
//   [SerializeField] private Canvas uiCanvas;
//
//   void Update()
//    {
//        if (Input.GetMouseButtonDown(1))
//        {
//            uiCanvas.enabled = !uiCanvas.enabled;
//        }
//    }
//}
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
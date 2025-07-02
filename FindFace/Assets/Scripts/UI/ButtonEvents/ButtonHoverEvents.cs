using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ButtonHoverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("마우스 벗어남");
    }
}
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ButtonHoverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Assets/Animation/Ui/Button/Button.controller
    public Animator anim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f);
        anim.SetBool("wave", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
        anim.SetBool("wave", false);
    }
}
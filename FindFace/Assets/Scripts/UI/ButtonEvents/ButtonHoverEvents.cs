using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ButtonHoverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Assets/Animation/Ui/Button/Button.controller
    public Animator anim;

    [Header("버튼 애니메이션")]
    public bool isWave;
    public bool isZoominOut;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f);
        if(isWave)
            anim.SetBool("wave", true);

        if (isZoominOut)
            anim.SetBool("zoominout", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);

        if(isWave)
            anim.SetBool("wave", false);
        if (isZoominOut)
            anim.SetBool("zoominout", false);
    }
}
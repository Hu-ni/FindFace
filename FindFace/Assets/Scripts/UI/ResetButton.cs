using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private GameObject WarningPanel;
    public void OnButtonPressedHardReset()
    {
        WarningPanel.SetActive(true);
    }
    public void OnButtonPressedResetCancel()
    {
        WarningPanel.SetActive(false);
    }
    
}

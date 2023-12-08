using UnityEngine;
using UnityEngine.UI;

public class TipSwitcher : MonoBehaviour
{
    public GameObject tip1; 
    public GameObject tip2; 
    public Button nextButton;

    void Start()
    {
        tip1.SetActive(true);
        tip2.SetActive(false);

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(SwitchTips);
        }
        else
        {
            Debug.LogError("Button is not assigned!");
        }
    }

    void SwitchTips()
    {
        tip1.SetActive(!tip1.activeSelf);
        tip2.SetActive(!tip2.activeSelf);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Button targetButton;
    public string targetSceneName;

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Target Button not assigned!");
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button startButton;
    public Button clearButton;
    public GameObject robot;
    public InputField inputField;
    private Vector3 startPosition;

    private Color targetColor = new Color(40f / 255f, 89f / 255f, 2f / 255f);

    private void Start()
    {
        startPosition = robot.transform.position;
        clearButton.onClick.AddListener(ClearRobot);
        Debug.Log("отчищено");
    }


    private void ClearRobot()
    {
        robot.transform.position = startPosition;
        startButton.interactable = true;
        inputField.textComponent.color = targetColor;
    }
}
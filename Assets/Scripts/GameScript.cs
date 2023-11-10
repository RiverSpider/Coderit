using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    public InputField inputField;
    public Button startButton;
    public GameObject robot;

    private void Start()
    {
        startButton.onClick.AddListener(StartExecution);
    }

    private void StartExecution()
    {
        startButton.interactable = false;
        StartCoroutine(ProcessInput());
    }

    private System.Collections.IEnumerator ProcessInput()
    {
        string[] lines = inputField.text.Split('\n');

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();

            switch (trimmedLine.Split("(")[0])
            {
                case "робот.идти.вверх":
                    for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                    {
                        robot.transform.position += Vector3.up * 200f;
                        yield return new WaitForSeconds(1f);
                    }
                    Debug.Log("вверх");
                    break;
                case "робот.идти.вправо":
                    for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                    {
                        robot.transform.position += Vector3.right * 265f;
                        yield return new WaitForSeconds(1f);
                    }
                    Debug.Log("вправо");
                    break;
                case "робот.идти.вниз":
                    for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                    {
                        robot.transform.position += Vector3.down * 200f;
                        yield return new WaitForSeconds(1f);
                    }
                    Debug.Log("вниз");
                    break;
                case "робот.идти.влево":
                    for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                    {
                        robot.transform.position += Vector3.left * 265f;
                        yield return new WaitForSeconds(1f);
                    }
                    Debug.Log("влево");
                    break;
                default:
                    Debug.Log("сломаться");
                    inputField.textComponent.color = Color.red;
                    yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
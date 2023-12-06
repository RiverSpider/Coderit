using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class RobotController : MonoBehaviour
    {
        public InputField inputField;
        public Button startButton;
        public GameObject robot;
        public GameObject box; // ссылка на объект коробки

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
                            PushBox(Vector3.up * 200f, robot.transform.position);
                            robot.transform.position += Vector3.up * 200f;
                            yield return new WaitForSeconds(1f);
                        }
                        Debug.Log("вверх");
                        break;
                    case "робот.идти.вправо":
                        for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                        {
                            PushBox(Vector3.right * 265f, robot.transform.position);
                            robot.transform.position += Vector3.right * 265f;
                            yield return new WaitForSeconds(1f);
                        }
                        Debug.Log("вправо");
                        break;
                    case "робот.идти.вниз":
                        for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                        {
                            PushBox(Vector3.down * 200f, robot.transform.position);
                            robot.transform.position += Vector3.down * 200f;
                            yield return new WaitForSeconds(1f);
                        }
                        Debug.Log("вниз");
                        break;
                    case "робот.идти.влево":
                        for (int i = 0; i < Convert.ToInt32(trimmedLine.Split("(")[1].Split(")")[0]); i++)
                        {
                            PushBox(Vector3.left * 265f, robot.transform.position);
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


        public void PushBox(Vector3 direction, Vector3 rob)
        {
            // Проверка на наличие коробки перед персонажем
            Vector3 checkPosition = rob + direction; // проверяем клетку перед персонажем
            Collider2D obj = Physics2D.OverlapBox(checkPosition, new Vector3(0.8f, 0.8f), 0); // предполагается, что размер коробки - (1, 1)

            if (obj != null && obj.gameObject.CompareTag("Box"))
            {
                Vector3 targetPosition = checkPosition * 2 + direction * 2; // клетка, куда нужно переместить коробку
                Collider2D blockingObject = Physics2D.OverlapBox(targetPosition, new Vector3(0.8f, 0.8f), 0); // предполагается, что размер коробки - (1, 1)

                if (blockingObject == null) // проверяем, нет ли других объектов на целевой клетке
                {
                    box.transform.position += direction;
                }
            }
        }
    }
}
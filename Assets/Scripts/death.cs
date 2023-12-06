using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class Spike : MonoBehaviour
{
    public Text textObject;
    public RobotController otherScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("lox");
        textObject.rectTransform.position = new Vector3(1400, 477, -1);
        OnCollisionEnter();
    }

    private void OnCollisionEnter()
    {
        otherScript.enabled = false;
    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class CollisionHandler : MonoBehaviour
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
        Debug.Log("победа");
        OnCollisionEnter();
        textObject.rectTransform.position = new Vector3(1400, 477, -1);
    }
    
    private void OnCollisionEnter()
    {      
        otherScript.enabled = false;
    }
    
}
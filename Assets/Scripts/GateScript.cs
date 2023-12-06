using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Game;
public class GateScript : MonoBehaviour
{
    public RobotController otherScript;
    public GameObject Gate;
    public Text textObject;
    private bool isGateOpen = false;
    public Sprite GateOpen;
    public Sprite GateClosed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        if(isGateOpen == false){
            spriteRenderer.sprite = GateClosed; 
        }
        else{
            spriteRenderer.sprite = GateOpen; 
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && isGateOpen==false)
        {
            GameOver();
        }
        if(collider.CompareTag("Player") && isGateOpen==true)
        {
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        }
    }
    private void GameOver()
    {
        Debug.Log("lox");
        textObject.rectTransform.position = new Vector3(1400, 477, -1);
        OnCollisionEnter();
    }

    public void OpenGate()
    {
        isGateOpen = true;
    }
    public void CloseGate()
    {
        isGateOpen = false;
    }
        private void OnCollisionEnter()
    {
        otherScript.enabled = false;
    }
}

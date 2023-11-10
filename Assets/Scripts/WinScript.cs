using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject textObject; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("победа");
            textObject.transform.position = Vector3.zero;

            textObject.GetComponent<TextMesh>().color = Color.red;

            textObject.transform.SetAsLastSibling();
        }
    }
}
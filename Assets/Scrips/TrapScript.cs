using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public LayerMask playerLayer;
    public PlayerMovement playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(3)){ // use tags instead?
            playerScript.Die();
        }
    }
}

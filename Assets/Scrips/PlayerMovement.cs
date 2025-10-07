using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0); 

        if (Input.GetKeyDown("space"))
        {
            transform.GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Impulse);
        }

    }
}

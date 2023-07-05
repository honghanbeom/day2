using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bulletrigidbody = default;
    // Start is called before the first frame update
    void Start()
    {
        bulletrigidbody = GetComponent<Rigidbody>();
        bulletrigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControler playerController 
                = other.GetComponent<PlayerControler>();

            if (playerController != null)
            {
                playerController.Die();    
            }
        }
    }


}

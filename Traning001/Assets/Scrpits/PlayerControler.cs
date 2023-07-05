using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRigid = default;
    public float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput* speed;
        float zSpeed = zInput* speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;
    }

    public void Die()   
    {
        gameObject.SetActive(false);
        
        GameManger gameManger = FindObjectOfType<GameManger>();
        gameManger.EndGame();
    }
}

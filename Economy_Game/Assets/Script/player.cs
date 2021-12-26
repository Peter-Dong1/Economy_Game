using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0F;

    [SerializeField] private float horizontal = 0.0F;

    [SerializeField] private float vertical = 0.0F;

    [SerializeField] private float limiter = 0.71F;

    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            vertical = moveSpeed;
        } else if(Input.GetKey(KeyCode.S)) {
            vertical = -moveSpeed;
        } else {
            vertical = 0;
        }

        if (Input.GetKey(KeyCode.A)) {
            horizontal = -moveSpeed;
        } else if(Input.GetKey(KeyCode.D)) {
            horizontal = moveSpeed;
        } else {
            horizontal = 0;
        }

        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Press Primary Button.");
            
        }
        
    }

    private void FixedUpdate() {
        if(horizontal != 0 && vertical != 0) {
            horizontal *= limiter;
            vertical *= limiter;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical);
    }
}


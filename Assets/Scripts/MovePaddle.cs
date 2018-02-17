using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float speed = 30;

    private void FixedUpdate()
    {
        float press = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, press) * speed;
    }

    void Start() { }
    void Update() { }
}

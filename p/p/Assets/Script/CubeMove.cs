using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private float speed = 2;

    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        if (transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }
}

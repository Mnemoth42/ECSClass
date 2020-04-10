using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.1f);
        if (transform.position.z > 50)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -50);
        }
    }
}

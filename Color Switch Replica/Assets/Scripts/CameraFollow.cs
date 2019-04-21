using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y > transform.position.y)
        {
            // Following our player on Y axis
            transform.position = new Vector3(transform.position.x, Player.position.y, transform.position.z);
        }
    }
}

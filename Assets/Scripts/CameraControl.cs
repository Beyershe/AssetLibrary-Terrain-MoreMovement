using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {

    }

    void MoveBehindPlayer()
    {
        //Vector3 newPosition = player.transform.position;
        //newPosition.y = transform.position.y;
        //newPosition.z -= 10;
        //transform.position = newPosition;
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveBehindPlayer();
    }
}

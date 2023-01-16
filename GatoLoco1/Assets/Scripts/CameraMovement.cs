using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   public GameObject Cat;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Cat.transform.position.x;
        transform.position = position;
    }
}

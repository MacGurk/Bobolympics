using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    void LateUpdate()
    {
        if (Player != null)
        {
            transform.position = Player.position + offset;
        }
    }
}

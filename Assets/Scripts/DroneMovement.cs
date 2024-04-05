using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float droneXPosition;
    [SerializeField] private float droneYPosition;

    private void UpdatePosition()
    {
        transform.position = new Vector3(player.gameObject.transform.position.x + droneXPosition, player.gameObject.transform.position.y + droneYPosition, 0);
    }

    private void Update()
    {
        UpdatePosition();
    }
}

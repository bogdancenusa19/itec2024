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
        // add an delay to the drone movement
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + droneXPosition, player.transform.position.y + droneYPosition), 7 * Time.deltaTime);
        
    }

    private void Update()
    {
        UpdatePosition();
    }
}

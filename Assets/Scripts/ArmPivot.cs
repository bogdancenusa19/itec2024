using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPivot : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    [SerializeField] private GameObject arms;
  
    private void FixedUpdate()
    {
        if (player.tag == "Player")
        {
            RotatePlayerArms();
        }
        else if (player.tag == "Enemy")
        {
            RotateEnemyArms();
        }
    }
    
    private void RotatePlayerArms()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        Vector3 difference = Camera.main.ScreenToWorldPoint(mousePoint) - arms.transform.position;
        difference *= Mathf.Sign(player.transform.localScale.x);


        Debug.Log("Mouse Pos: " + Camera.main.ScreenToWorldPoint(Input.mousePosition) + " - " + "Arms Pos: " + arms.transform.position);
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
    
    private void RotateEnemyArms()
    {
        Vector2 direction = player.transform.position - enemy.transform.position;
        bool isFacingLeft = enemy.transform.localScale.x < player.transform.localScale.x;
        if (!isFacingLeft)
        {
            direction = new Vector2(-direction.x, -direction.y);
        }
        direction.Normalize();
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        
    }
}
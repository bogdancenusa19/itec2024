using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPivot : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject arms;
  
    private void FixedUpdate()
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
}
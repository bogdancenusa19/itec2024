using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HystoryLevelController : MonoBehaviour
{
    public GameObject background;
    public Color newBackgroundColor;

    public GameObject[] platforms;
    public Color newPlatformColor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            background.GetComponent<SpriteRenderer>().color = newBackgroundColor;

            foreach(GameObject platform in platforms)
            {
                platform.GetComponent<SpriteRenderer>().color = newPlatformColor;
            }
        }
    }
}

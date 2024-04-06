using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

}

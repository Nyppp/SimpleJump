using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseFood>() != null && this.transform.childCount == 0)
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (this.transform.parent != null)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<Rigidbody>().useGravity = false;

            this.transform.position = this.transform.parent.gameObject.transform.position;
        }

        else
        {
            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

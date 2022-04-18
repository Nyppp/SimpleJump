using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //음식이 굴러들어오거나 던져졌을 때, 박스와 부딪히면 음식이 박스로 올라감
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseFood>() != null && this.transform.childCount == 0 )
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }
}

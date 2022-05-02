using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScroll : MonoBehaviour
{
    // Start is called before the first frame update

    public float ScrollSpeed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float OffsetY = Time.time * ScrollSpeed * -1;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, OffsetY);
    }
}

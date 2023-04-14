using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Canvas>().worldCamera = Blocks.instance.camera_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

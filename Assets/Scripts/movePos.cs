using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePos : MonoBehaviour
{

    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parent.transform.position;
    }
}

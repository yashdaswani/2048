using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public GameObject effects1;


    public void effectmethod()
    {
        GameObject ob = Instantiate(effects1);
        Destroy(ob, 2f);
    }

}

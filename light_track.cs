using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_track : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v1= target.transform.position;
        //v1.y=7.7f;
        this.transform.position=v1;
    }
}

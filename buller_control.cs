using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buller_control : MonoBehaviour
{
    Rigidbody rig;

    public GameObject particle;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mutant:Hips")
        {
            Instantiate(particle, this.transform.position, this.transform.rotation);
            game_over.x2+=1;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(this.transform.right * 10000);
        game_over.x1+=1;
        GameObject.Destroy(this.gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

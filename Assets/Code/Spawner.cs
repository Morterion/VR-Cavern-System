using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Rigidbody Spawnable;
    private Transform loc;
    private Rigidbody newest;
    public float range = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }

    private void Start(){
        loc = this.transform.transform;
        newest = Instantiate(Spawnable, loc.position, loc.rotation) as Rigidbody;
        newest.transform.SetParent(this.gameObject.transform);
    }

    private void Update()
    {
        float dist = (newest.position - loc.position).sqrMagnitude;
        if(dist > range)
        {
            // We should also play sound
            newest = Instantiate(Spawnable, loc.position, loc.rotation) as Rigidbody;
            newest.transform.SetParent(this.gameObject.transform);
        }
    }
}

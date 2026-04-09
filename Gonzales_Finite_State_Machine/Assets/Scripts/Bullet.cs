using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject owner;
    public GameObject explosion;
	
	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == owner) return;

        GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);

        Health health = col.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage();
        }

        Destroy(e, 1.5f);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () 
	{
        Collider myCol = GetComponent<Collider>();
        Collider ownerCol = owner.GetComponent<Collider>();

        if (myCol != null && ownerCol != null)
        {
            Physics.IgnoreCollision(myCol, ownerCol);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

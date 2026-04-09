using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

 	public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public GameObject bullet;
    public GameObject turrent;

    void Update() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFiring();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopFiring();
        }
	}

    void Fire()
    {
        GameObject b = Instantiate(bullet, turrent.transform.position, turrent.transform.rotation);
        b.GetComponent<Bullet>().owner = gameObject;
        b.GetComponent<Rigidbody>().AddForce(turrent.transform.forward * 700);
    }
    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
}

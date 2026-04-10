using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    public GameObject bullet;
    public GameObject turrent;
    public Health health;
    public GameObject GetPlayer()
    {
        return player;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        health = this.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            anim.SetFloat("dist", Vector3.Distance(transform.position, player.transform.position));
            anim.SetInteger("HP", health.hp);

            var direction = player.transform.position - health.hpSlider.transform.position;
            health.hpSlider.transform.rotation = Quaternion.Slerp(health.hpSlider.transform.rotation, Quaternion.LookRotation(direction), 1.0f * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("dist", 50);
        }
        
    }
    void Fire()
    {
        GameObject b = Instantiate(bullet, turrent.transform.position, turrent.transform.rotation);
        //b.GetComponent<Bullet>().owner = gameObject;
        b.GetComponent<Rigidbody>().AddForce(turrent.transform.forward * 500);
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

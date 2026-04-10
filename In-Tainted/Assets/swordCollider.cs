using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCollider : MonoBehaviour
{
    public PlayerController ai;
    // Start is called before the first frame update
    private void Start()
    {
        ai.weaponCol.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(1);

        }

    }
}

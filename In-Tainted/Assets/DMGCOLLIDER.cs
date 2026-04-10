using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGCOLLIDER : MonoBehaviour
{
    public AIControl ai;
    // Start is called before the first frame update
    private void Start()
    {
        ai.atkCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ai.player.GetComponent<Health>().TakeDamage(1);

        }

    }
}

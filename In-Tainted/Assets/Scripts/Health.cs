using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 5;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHp;
            hpSlider.value = hp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hpSlider != null)
        { 
        hpSlider.value = hp;
        }
    }
    public void Heal()
    {
        hp = maxHp;
    }
}

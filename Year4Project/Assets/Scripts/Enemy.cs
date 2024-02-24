using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WeaponZone")
        {
            WeaponController.enemyEntered = true;
            if (PlayerController.hitBeat == true)
            {
                WeaponController.durability--;
                Debug.Log(WeaponController.durability);
                if (WeaponController.durability <= 0)
                {
                    WeaponController.currentWeapon = "Null";
                }
                WeaponController.enemyEntered = false;
                Destroy(this.gameObject);
            }
        }
    }
}

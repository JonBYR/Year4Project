using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameManager man;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnBeat()
    {
        Debug.Log("Enemy beat");
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
            //InvokeRepeating("CheckCollision", 1f, 1f);
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "WeaponZone")
        {
            Debug.Log("Enemy exit");
            WeaponController.enemyEntered = false;
            CancelInvoke("CheckCollision");
        }
    }
    */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "WeaponZone")
        {
            WeaponController.enemyEntered = true;
            if (PlayerController.hitBeat == true && WeaponController.enemyEntered == true)
            {
                Debug.Log("This is called");
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
    
    void CheckCollision()
    {
        if (PlayerController.hitBeat == true && WeaponController.enemyEntered == true)
        {
            Debug.Log("This is called");
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

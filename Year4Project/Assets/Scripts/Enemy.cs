using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Enemy : MonoBehaviour
{
    private GameManager game;
    public Vector2 attackSize;
    public Transform enemyTransform;
    public LayerMask playerMask;
    private MissedBeat mBeat;
    public bool canMove;
    public float rawDist;
    public ParticleSystem enemyParticles;
    // Start is called before the first frame update
    
    /*
    // Update is called once per frame
    void Update()
    {
        Collider2D playerToAttack = Physics2D.OverlapBox(enemyTransform.localPosition, attackSize, 0f, playerMask);
        if ((playerToAttack != null) && canMove)
        {
            PlayerHealth.TakeDamage();
            StartCoroutine(mBeat.Shake(.15f, .4f));
            canMove = false;
            Invoke("MoveAgain", 3);
        }
    }
    */
    /*
    void MoveAgain()
    {
        canMove = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(enemyTransform.localPosition, attackSize);
    }
    */
    /*
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
    */
    public void OnDestroy()
    {
        Instantiate(enemyParticles, transform.position, transform.rotation);
    }
}

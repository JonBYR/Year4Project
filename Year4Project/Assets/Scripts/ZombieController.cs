using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private GameManager man;
    private PlayerController player;
    private GameObject p;
    private Rigidbody2D playerRb;
    public LayerMask walls;
    private int beatCounter;
    public int beatThreshold;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player");
        //man = GameObject.Find("GameManager").GetComponent<GameManager>();
        man = GameManager.Instance; //gets the singleton
        man.RegisterEnemy(GetInstanceID()); //gets the unique identifier for enemy
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(man.onBeat == true && man.returnEnemyMove(GetInstanceID())) //enemy assumes perfect movement
        {
            man.setEnemyMove(GetInstanceID());
            float horizontalDistance = p.transform.position.x - transform.position.x;
            float verticalDistance = p.transform.position.y - transform.position.y;
            Vector3 moveDirection = Vector3.zero;
            beatCounter++;
            float positiveHorizontal = horizontalDistance;
            float positiveVertical = verticalDistance;
            positiveHorizontal = Mathf.Abs(positiveHorizontal);
            positiveVertical = Mathf.Abs(positiveVertical);
            if(beatCounter >= beatThreshold)
            {
                if (positiveHorizontal < 1f && positiveVertical < 1f)
                {
                    moveDirection = new Vector3(0, -0.1f, 0);
                }
                else if ((positiveHorizontal < positiveVertical || positiveVertical < 1f) && positiveHorizontal >= 1f) //if there is a negligable distance the AI should move vertically
                {
                    if(horizontalDistance < 0)
                    {
                        moveDirection = new Vector3(-0.1f, 0, 0);
                    }
                    else
                    {
                        moveDirection = new Vector3(0.1f, 0, 0);
                    }
                }
                else if ((positiveHorizontal > positiveVertical || positiveHorizontal < 1f) && positiveVertical >= 1f)
                {
                    if(verticalDistance < 0)
                    {
                        moveDirection = new Vector3(0, -0.1f, 0);
                    }
                    else
                    {
                        moveDirection = new Vector3(0, 0.1f, 0);
                    }
                }
                if (!Physics2D.OverlapCircle(transform.position += moveDirection, 0.2f, walls)) transform.position += moveDirection; 
                beatCounter = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WeaponZone")
        {
            WeaponController.enemyEntered = true;
            if(PlayerController.hitBeat == true)
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

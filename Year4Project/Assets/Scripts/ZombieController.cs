using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private GameManager man;
    private PlayerController player;
    private GameObject p;
    public LayerMask walls;
    private int beatCounter;
    public int beatThreshold;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player");
        man = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(man.onBeat == true) //enemy assumes perfect movement
        {
            float horizontalDistance = p.transform.position.x - transform.position.x;
            float verticalDistance = p.transform.position.y - transform.position.y;
            Vector3 moveDirection = Vector3.zero;
            beatCounter++;
            if(beatCounter >= beatThreshold)
            {
                if (Mathf.Abs(horizontalDistance) < 1f && Mathf.Abs(verticalDistance) < 1f)
                {
                    moveDirection = new Vector3(0, -0.1f, 0);
                }
                else if (Mathf.Abs(horizontalDistance) < Mathf.Abs(verticalDistance) || Mathf.Abs(verticalDistance) < 1f)
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
                else if (Mathf.Abs(horizontalDistance) > Mathf.Abs(verticalDistance) || Mathf.Abs(horizontalDistance) < 1f)
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
}

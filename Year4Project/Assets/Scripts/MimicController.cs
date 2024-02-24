using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicController : Enemy
{
    private GameManager man;
    private PlayerController player;
    public LayerMask walls;
    public float mimicDist = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        man = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.moving == true)
        {
            if (player.horizontal)
            {
                if (!Physics2D.OverlapCircle(transform.position += new Vector3(-player.direction * mimicDist, 0, 0), 0.2f, walls)) transform.position += new Vector3(-player.direction * mimicDist, 0, 0);
            }
            else if (!player.horizontal)
            {
                if (!Physics2D.OverlapCircle(transform.position += new Vector3(0, -player.direction * mimicDist, 0), 0.2f, walls)) transform.position += new Vector3(0f, -player.direction * mimicDist, 0f);
            }
        }
    }
}

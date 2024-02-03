using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkeletonController : MonoBehaviour
{
    private GameManager man;
    public LayerMask walls;
    private int beatCounter;
    public int beatThreshold;
    // Start is called before the first frame update
    void Start()
    {
        man = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(man.onBeat == true)
        {
            Vector3 moveDirecion = Vector3.zero;
            beatCounter++;
            if(beatCounter > beatThreshold)
            {
                int randomDirection = (int)Random.Range(0, 3);
                if (randomDirection == 0)
                {
                    moveDirecion = new Vector3(0.1f, 0, 0);
                }
                else if(randomDirection == 1)
                {
                    moveDirecion = new Vector3(0, 0.1f, 0);
                }
                else if(randomDirection == 2)
                {
                    moveDirecion = new Vector3(-0.1f, 0, 0);
                }
                else if(randomDirection == 3)
                {
                    moveDirecion = new Vector3(0, -0.1f, 0);
                }
                if (!Physics2D.OverlapCircle(transform.position += moveDirecion, 0.2f, walls)) transform.position += moveDirecion;
                beatCounter = 0;
            }
        }
    }
}

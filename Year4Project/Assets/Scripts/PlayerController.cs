using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public GameManager man;
    public TextMeshProUGUI scoreText;
    public float speed = 5f;
    public float rawDist = 0.1f;
    int score = 0;
    public LayerMask walls;
    public bool horizontal;
    public bool moving;
    public float direction; //these three variables are required for the mimic movement
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        horizontal = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (man.onBeat == true) //code for movement taken from this tutorial: https://www.youtube.com/watch?v=mbzXIOKZurA
            {
                moving = true;
                if (Input.GetAxisRaw("Horizontal") == 1f || Input.GetAxisRaw("Horizontal") == -1f)
                {
                    direction = Input.GetAxisRaw("Horizontal");
                    horizontal = true;
                    if (!Physics2D.OverlapCircle(transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * rawDist, 0, 0), 0.2f, walls)) transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * rawDist, 0, 0); //moves position of player to be one tile left or right of player
                    //this code will check to make sure that if, when moving, the player hits a collider, the player no longer moves
                }
                else if (Input.GetAxisRaw("Vertical") == 1f || Input.GetAxisRaw("Vertical") == -1f)
                {
                    direction = Input.GetAxisRaw("Vertical");
                    horizontal = false;
                    if (!Physics2D.OverlapCircle(transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * rawDist, 0), 0.2f, walls)) transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * rawDist, 0f);
                }
                Debug.Log("BPM matched!"); //singleton used to access global information. If the user is pressing within beat, user can move
                score++;
                scoreText.text = "Score: " + score;
                //moving = false;
            }
            else
            {
                moving = false;
                Debug.Log("BPM failed!");
            }
        }
        if (man.onBeat == false) moving = false;
    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (man.onBeat == true) //code for movement taken from this tutorial: https://www.youtube.com/watch?v=mbzXIOKZurA
            {
                if (Input.GetAxisRaw("Horizontal") == 1f || Input.GetAxisRaw("Horizontal") == -1f)
                {
                    if (!Physics2D.OverlapCircle(transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * rawDist, 0, 0), 0.2f, walls)) transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * rawDist, 0, 0); //moves position of player to be one tile left or right of player
                    //this code will check to make sure that if, when moving, the player hits a collider, the player no longer moves
                }
                else if (Input.GetAxisRaw("Vertical") == 1f || Input.GetAxisRaw("Vertical") == -1f)
                {
                    if (!Physics2D.OverlapCircle(transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * rawDist, 0), 0.2f, walls)) transform.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * rawDist, 0f);
                }  
                Debug.Log("BPM matched!"); //singleton used to access global information. If the user is pressing within beat, user can move
                score++;
                scoreText.text = "Score: " + score;
            }
            else Debug.Log("BPM failed!");
        }
    }
}

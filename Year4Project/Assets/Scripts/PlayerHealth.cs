using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    static int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void TakeDamage()
    {
        health--;
        Debug.Log(health);
        if (health <= 0 )
        {
            Debug.Log("Game Over");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    [SerializeField]
    static int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Current Health: " + health;
    }
    public static void TakeDamage()
    {
        health--;
        Debug.Log(health);
        if (health <= 0 )
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public static void setHealth(int h)
    {
        health = h;
    }
}

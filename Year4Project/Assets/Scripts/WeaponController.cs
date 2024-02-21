using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public static int durability = 10;
    public static bool enemyEntered = false;
    public static string currentWeapon = "Baton";
    public GameObject player;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.offset = new Vector2(1, 0); //sets the collider for the weapon to be one square to the right
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon == "Null")
        {
            ChangeOffset(0, 0);
            ChangeSize(0, 0);
        }
        if(enemyEntered)
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (!enemyEntered)
        {
            playerRb.constraints = RigidbodyConstraints2D.None;
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public void ChangeOffset(float x, float y)
    {
        boxCollider.offset = new Vector2(x, y);
    }
    public void ChangeSize(float x, float y)
    {
        boxCollider.size = new Vector2(x, y);
    }
}

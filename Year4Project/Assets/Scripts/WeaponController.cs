using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public static int durability = 10;
    public bool enemyEntered = false;
    public static string currentWeapon = "Knife";
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.offset = new Vector2(1, 0); //sets the collider for the weapon to be one square to the right
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon == "Null")
        {
            ChangeOffset(0, 0);
            ChangeSize(0, 0);
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

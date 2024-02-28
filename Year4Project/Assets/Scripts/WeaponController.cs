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
    private Vector2 colliderSize = Vector2.zero;
    public LayerMask enemyLayer;
    public Transform offsetPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //boxCollider = this.GetComponent<BoxCollider2D>();
        //boxCollider.offset = new Vector2(1, 0); //sets the collider for the weapon to be one square to the right
        //offsetPoint.localPosition = new Vector2(1, 0);
        colliderSize = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D enemiesToAttack = Physics2D.OverlapBox(offsetPoint.localPosition, colliderSize, 0f, enemyLayer);
        if (currentWeapon == "Null")
        {
            ChangeOffset(0, 0);
            ChangeSize(0, 0);
        }
        if(PlayerController.hitBeat == true)
        {
            if (enemiesToAttack != null)
            {
                enemyEntered = true;
                if (PlayerController.moving == true) return;
                else { Destroy(enemiesToAttack.gameObject); durability--; EnemySpawner.enemiesSpawned--; }
            }
            else enemyEntered = false;
        }
    }
    public void ChangeOffset(float x, float y)
    {
        offsetPoint.localPosition = (Vector2)player.transform.position + new Vector2(x, y);
    }
    public void ChangeSize(float x, float y)
    {
        //boxCollider.size = new Vector2(x, y);
        colliderSize = new Vector2(x, y);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(offsetPoint.localPosition, colliderSize);
    }
}

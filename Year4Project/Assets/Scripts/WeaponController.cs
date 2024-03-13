using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public static int durability = 5;
    public static bool enemyEntered = false;
    public static string currentWeapon = "Baton";
    [SerializeField] private Vector2 colliderSize = Vector2.zero;
    public LayerMask enemyLayer;
    public Transform offsetPoint;
    public GameObject player;
    public SpriteRenderer arrow;
    private bool renderArrow = false;
    Quaternion arrowRotation;
    // Start is called before the first frame update
    void Start()
    {
        //boxCollider = this.GetComponent<BoxCollider2D>();
        //boxCollider.offset = new Vector2(1, 0); //sets the collider for the weapon to be one square to the right
        //offsetPoint.localPosition = new Vector2(1, 0);
        colliderSize = new Vector2(1.5f, 1.5f);
        arrow.enabled = false;
        StartCoroutine(ArrowShowcase());
        arrowRotation = Quaternion.Euler(0, 0, 90);
        arrow.transform.rotation = arrowRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D enemiesToAttack = Physics2D.OverlapBox(offsetPoint.localPosition, colliderSize, 0f, enemyLayer);
        if(PlayerController.hitBeat == true)
        {
            Debug.Log("Collider Size: " + currentWeapon + " " + colliderSize);
            if (enemiesToAttack != null)
            {
                enemyEntered = true;
                if (PlayerController.moving == true) return;
                else { 
                    durability--;
                    Debug.Log("Durability: " + durability);
                    if (durability <= 0) currentWeapon = "Null";
                    EnemySpawner.enemiesSpawned--;
                    Destroy(enemiesToAttack.gameObject); 
                }
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
        Debug.Log("Collider Size: " + currentWeapon + " " + colliderSize);
    }
    public void ChangeRotation(Quaternion r)
    {
        arrowRotation = r;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(offsetPoint.localPosition, colliderSize);
    }
    void RenderArrow()
    {
        renderArrow = !renderArrow;
    }
    IEnumerator ArrowShowcase()
    {
        while(true)
        {
            if (currentWeapon == "Null") arrow.enabled = false;
            else
            {
                arrow.transform.position = offsetPoint.localPosition;
                arrow.transform.rotation = arrowRotation;
                arrow.enabled = true;
                Debug.Log("Calling Coroutine");
                RenderArrow();
            }
            yield return new WaitForSeconds(1.0f); //this gets called to wait a second before derending the arrow
            arrow.enabled = false;
            yield return new WaitUntil(() => PlayerController.hitBeat == true); //waits until the player hits a beat before re rendering the arrow
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private ZombieController zombieController;
    private MimicController mimicController;
    private MageController mageController;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "TriggerZone") return;
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerHealth.TakeDamage();
            if (collision.gameObject.name.Contains("Mage"))
            {
                mageController = collision.gameObject.GetComponent<MageController>();
                mageController.enabled = false;
            }
            else if(collision.gameObject.name.Contains("Zombie"))
            {
                zombieController = collision.gameObject.GetComponent<ZombieController>();
                zombieController.enabled = false;
            }
            else if(collision.gameObject.name.Contains("Mimic"))
            {
                mimicController = collision.gameObject.GetComponent<MimicController>();
                mimicController.enabled = false;
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.tag == "TriggerZone") return;
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.name.Contains("Mage"))
            {
                Invoke("StartMage", 3f);
            }
            else if (collision.gameObject.name.Contains("Zombie"))
            {
                Invoke("StartZombie", 3f);
            }
            else if (collision.gameObject.name.Contains("Mimic"))
            {
                Invoke("StartMimic", 3f);
            }
        }
    }
    void StartMage()
    {
        mageController.enabled = true;
    }
    void StartZombie()
    {
        zombieController.enabled = true;
    }
    void StartMimic()
    {
        mimicController.enabled = true;
    }
}

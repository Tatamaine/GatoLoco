using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepino : MonoBehaviour
{  
    public HealthBar healthBar;
     public int maxHealth = 100;
     public int currentHealth;

    private Rigidbody2D Rigidbody2D;
    

     void TakeDamage(int damage)
     {
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);

     }



     
      

      private void OnTriggerEnter2D(Collider2D collision)
      {

        if (collision.tag == "Pepino")
        {
             Destroy(collision.gameObject);
              GetComponent <SpriteRenderer>(). color = Color.red;
              TakeDamage(50);
        }
        
      }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
     public int maxHealth = 100;
     public int currentHealth;
     public HealthBar healthBar;
     public GameManagerScript gameManager;
     
     public float Speed;
     public float JumpForce;

     private bool Grounded;

     private bool Cocacolaespuma;
     private bool MonsterPower;

     private Rigidbody2D Rigidbody2D;
     private float Horizontal;
     private Animator Animator;
     private bool isDead;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 5.1f, Color.red);
       
       //If player is dead
       if(currentHealth <= 0 && !isDead)
       {

         isDead = true;
         gameManager.gameOver();
         Debug.Log("E");
         gameObject.SetActive(false);

       }


        Animator.SetBool("Running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 1.5f))
        {
            Grounded = true;
        }
          else Grounded = false;

          if (Input.GetKeyDown(KeyCode.Space) && Cocacolaespuma)
          {
            Speed = 10;
          }
        
          if (Input.GetKeyUp(KeyCode.Space))
          {
              Speed = 6;
          }
            

          if (Horizontal < 0.0f) transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
          else if (Horizontal > 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

           Horizontal = Input.GetAxisRaw("Horizontal");


           if (Input.GetKeyDown(KeyCode.W) && Grounded)
           {
              Jump();
           }

           if (Input.GetKeyDown(KeyCode.Space)&& MonsterPower)
           {

              Speed = 12;

           }

           if (Input.GetKeyUp(KeyCode.Space)&& MonsterPower)
           {

            Speed = 6;

           }


           

    }

    void TakeDamage(int damage){
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }

    

    

private void Jump()
{
     Rigidbody2D.AddForce(Vector2.up * JumpForce);
}
    
private void FixedUpdate()
{
Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
}

private void OnTriggerEnter2D(Collider2D collision) 
{

 if (collision.tag == "Powerup")
 {
    Destroy(collision.gameObject);
    GetComponent <SpriteRenderer>(). color = Color.yellow;
    Cocacolaespuma = true;

    StartCoroutine(ResetPower());


 }
   
   if (collision.tag == "MonsterPowerUp")
   {

     Destroy(collision.gameObject);
     GetComponent <SpriteRenderer>(). color = Color.green;
     MonsterPower = true;

     StartCoroutine(ResetMonster());


   }

   if (collision.tag == "Pepino")
   {
     TakeDamage(50);
     Destroy(collision.gameObject);
   }

   if (collision.tag == "miki")
   {
     TakeDamage(-50);
     Destroy(collision.gameObject);
   }

}

private IEnumerator ResetPower()
{
  yield return new WaitForSeconds(5);
  Cocacolaespuma = false;
  GetComponent <SpriteRenderer>(). color = Color.white;
  Speed = 6;


}

private IEnumerator ResetMonster()
{

   yield return new WaitForSeconds(10);
   MonsterPower = false;
   GetComponent <SpriteRenderer>(). color = Color.white;
   Speed = 6;

}





}

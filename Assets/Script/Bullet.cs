using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] AudioClip MonsterDmg;
    Rigidbody2D myRigidBody;
    PlayerMovement player;
    float xSpeed;
    float direction;
   
    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        direction = player.transform.localScale.x;

    }
       
    
    void Update()
    {
        myRigidBody.transform.localScale=new Vector2 (direction,1f);
        myRigidBody.velocity=new Vector2 (xSpeed,0f);

    }

      void OnTriggerEnter2D(Collider2D other) 
      {
        if(other.tag =="Enemy")
        {
             AudioSource.PlayClipAtPoint(MonsterDmg, Camera.main.transform.position);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
      }

     void OnCollisionEnter2D(Collision2D other) 
     {
        Destroy(gameObject);
     }
}

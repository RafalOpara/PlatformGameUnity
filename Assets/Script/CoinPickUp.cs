using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour

{
    [SerializeField] AudioClip AudioCoin;
    [SerializeField] int pointsForCoinPickup=10;
     [SerializeField] float volume = 0.1f;


    bool wasCollected = false;

     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag== "Player" && !wasCollected)
        {
            wasCollected=true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(AudioCoin, Camera.main.transform.position,volume);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}

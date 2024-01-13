using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    //public AudioClip killSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //AudioManager.instance.PlayClipAt(killSound, transform.position);
            Destroy(objectToDestroy);
            PlayerMovement.instance.rb.AddForce(new Vector2(0f, 400));
        }
    }
}

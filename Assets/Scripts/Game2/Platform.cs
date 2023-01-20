using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump;

    [SerializeField] private GameObject sound;

    public void OnCollisionEnter2D(Collision2D collision)           
    {
        if (collision.relativeVelocity.y < 0)                       
        {
            Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;
            Instantiate(sound, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
    public void OnCollisionExit2D(Collision2D collision)            
    {
        if (collision.collider.name == "DeadZone")                  
        {
            float RandX = Random.Range(-1.7f, 1.7f);
            float RandY = transform.position.y + Random.Range(20f, 22f);

            transform.position = new Vector3(RandX, RandY, 0);      
        }
    }

    
}

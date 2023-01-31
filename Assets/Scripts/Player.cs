using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;

    // Awake is called when the script instance is being loaded.
    void Awake() { 
        
    }
    
    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            Vector2 _velocity = Vector2.up * velocity;
            rigidbody.velocity = _velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        string collidedWithName = collision.collider.name;
        string collidedOtherName = collision.otherCollider.name;
        if (collision.gameObject.CompareTag("Obstacle")) {
            print($"Collision {collidedWithName}, {collidedOtherName}");
            this.PlayersDeath();
        }
        //if so player death
    }

    void PlayersDeath() {
        print($"Player died due collision.");
        //turn off collision
        //hide player
        //reset position
        //wait for GameManager to restart the game
    }

}

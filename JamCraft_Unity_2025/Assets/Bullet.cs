using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float randomness;
    Vector2 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        //target = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position) + Random.insideUnitCircle * randomness);
        rb.linearVelocity = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized*speed;
        //transform.position =  Vector2.MoveTowards(transform.position, ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)*100) + Random.insideUnitCircle * randomness), speed);
        transform.Rotate(0, 0, Mathf.Atan2(rb.linearVelocity.normalized.y, rb.linearVelocity.normalized.x) * 180 / Mathf.PI - 90);
    }


    // This method is called when the bullet collides with another object
    private void OnCollisionEnter2D(Collision2D collision) {
        // Check if the object we collided with has the "Meteor" tag
        if (collision.gameObject.CompareTag("Meteor")) {
            // Find the Meteor script on the collided object
            Meteor meteorScript = collision.gameObject.GetComponent<Meteor>();

            // If the Meteor script is found, call its Explode function
            if (meteorScript != null) {
                meteorScript.Explode();
            }

            // Optionally, destroy the bullet after collision
            Destroy(gameObject);
        }
    }





}

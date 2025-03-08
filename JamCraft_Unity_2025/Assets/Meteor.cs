using UnityEngine;

public class Meteor : MonoBehaviour, IDestructable {
    public float speed;
    public Vector2 move_dir;

    public GameObject meteor_explosion;
    public GameObject dustParticle;

    private Collider2D c2d;

    public float hp = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        c2d = GetComponent<Collider2D>(); // Cache the collider
        GetComponent<Rigidbody2D>().linearVelocity = move_dir * speed;  // Corrected typo: 'linearVelocity' to 'velocity'
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-45f, 45f);

        transform.Rotate(0, 0, Random.Range(0, 360));
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update() {
        // Check if the spacebar is pressed and if the mouse is hovering over the object
        if (Input.GetKeyDown(KeyCode.Space) && IsMouseOverObject()) {
            //Die();
        }
    }

    // Function to check if the mouse is over the object
    bool IsMouseOverObject() {
        // Convert mouse position to world space and check if it's over the collider
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return c2d.OverlapPoint(mousePosition);
    }

    public void Damage (float damage, Transform bullet) {
        hp -= damage;
        if (hp <= 0) Die();
        else Destroy(Instantiate(dustParticle, bullet.position, bullet.rotation),2);
    }

    // Explode function
    public void Die() {
        GameObject g = Instantiate(meteor_explosion, transform.position, Quaternion.identity, transform);
        print(g);
        c2d.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().linearDamping = 1;
        GetComponent<Rigidbody2D>().angularVelocity *= 0;

        Destroy(gameObject,3);
    }
}


public interface IDestructable {

    void Damage(float damage, Transform bullet);
    void Die();
}
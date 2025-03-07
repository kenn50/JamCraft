using UnityEngine;

public class Meteor : MonoBehaviour {
    public float speed;
    public Vector2 move_dir;

    public GameObject meteor_explosion;

    private Collider2D c2d;

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
            Explode();
        }
    }

    // Function to check if the mouse is over the object
    bool IsMouseOverObject() {
        // Convert mouse position to world space and check if it's over the collider
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return c2d.OverlapPoint(mousePosition);
    }

    // Explode function
    public void Explode() {
        Instantiate(meteor_explosion, transform.position, Quaternion.identity, transform);
        c2d.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().linearDamping = 1;
        GetComponent<Rigidbody2D>().angularVelocity *= 0;

        Destroy(gameObject,3);
    }
}

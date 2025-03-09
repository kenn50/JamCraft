using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public Vector2 move_dir;
    public float speed;

    public float min_deg = 0, max_deg = 0;
    public bool random_start_rotation = false;

    float spawn_time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn_time = Time.time;
        GetComponent<Rigidbody2D>().linearVelocity = move_dir * speed; 
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(min_deg, max_deg);

        if (random_start_rotation) transform.Rotate(0, 0, Random.Range(0, 360));
        

    }

    private void Update() {
        
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (Time.time - spawn_time > 5) {
            if (viewportPosition.x < -0.5 || viewportPosition.x > 1 + 0.5 ||
            viewportPosition.y < -3 || viewportPosition.y > 1 + 3) {
                Destroy(gameObject);
            }
        }
    }

}

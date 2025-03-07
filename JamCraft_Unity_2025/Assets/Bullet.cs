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
        rb = GetComponent<Rigidbody2D>();
        //target = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position) + Random.insideUnitCircle * randomness);
        rb.linearVelocity = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized*speed;
        //transform.position =  Vector2.MoveTowards(transform.position, ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)*100) + Random.insideUnitCircle * randomness), speed);
        transform.Rotate(0, 0, Mathf.Atan2(rb.linearVelocity.normalized.y, rb.linearVelocity.normalized.x) * 180 / Mathf.PI - 90);
    }

}

using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    private void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<IDestructable>().Damage(1,transform);
        Destroy(gameObject);
    }
}

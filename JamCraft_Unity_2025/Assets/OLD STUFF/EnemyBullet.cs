using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public AudioSource audiosource;

    private void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        audiosource.pitch = Random.Range(0.5f, 0.6f);
        audiosource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<IDestructable>().Damage(1,transform);
        Destroy(gameObject);
    }
}

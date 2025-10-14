using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IDestructable
{
    public float cooldown;
    float charge_timer = 0;
    public float speed;
    Transform target;
    Vector2 aim_position;

    int hp = 3;

    public GameObject explosion;

    bool dead = false;

    Rigidbody2D rb;

    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb=GetComponent<Rigidbody2D>();

        if ((target.position - transform.position).magnitude < 4) transform.position*=-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        charge_timer -= Time.deltaTime;

        if (charge_timer > 0.2f)
        {
            aim_position = target.position;
            transform.rotation = Quaternion.Euler(0,0, Vector2.SignedAngle(Vector2.left, (target.position - transform.position)));

        }
        else if (charge_timer < 0f) {
            rb.linearVelocity = (target.position - transform.position).normalized * speed;
            charge_timer = cooldown;
        }
    }

    public void Damage(float damage, Transform bullet)
    {
        hp--;
        sr.color = new Color(1, 1, (float)hp/3f);
        if (hp <= 0) Die();
    }
    // Explode function
    public void Die()
    {
        dead = true;
        GameObject g = Instantiate(explosion, transform.position, Quaternion.identity, transform);
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        GetComponent<SpriteRenderer>().enabled = false;
        
        GetComponent<Rigidbody2D>().linearDamping = 2;
        GetComponent<Rigidbody2D>().angularVelocity *= 0;


        Destroy(gameObject, 3);
    }

}

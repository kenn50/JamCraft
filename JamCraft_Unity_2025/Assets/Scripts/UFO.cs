using UnityEngine;

public class UFO : MonoBehaviour, IDestructable {

    public GameObject ufo_explosion;

    public void Damage(float damage, Transform bullet) {
        Die();
    }

    // Explode function
    public void Die() {
        GameObject g = Instantiate(ufo_explosion, transform.position, Quaternion.identity, transform);
        foreach (Collider2D c in GetComponents<Collider2D>()){
            c.enabled = false;
        }
        GetComponent<SpriteRenderer>().enabled = false;
        EnemyShoot es = GetComponent<EnemyShoot>();
        if (es != null) es.enabled = false;
        GetComponent<Rigidbody2D>().linearDamping = 2;
        GetComponent<Rigidbody2D>().angularVelocity *= 0;


        Destroy(gameObject, 3);
    }
}

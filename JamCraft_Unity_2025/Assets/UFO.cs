using UnityEngine;

public class UFO : MonoBehaviour, IDestructable {
    public void Damage(float damage, Transform bullet) {
        Die();
    }

    public void Die() {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}

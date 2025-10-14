using UnityEngine;

public class UFO : MonoBehaviour, IDestructable {

    public GameObject ufo_explosion;
    GameObject player;


    public Transform dir_pointer;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        Vector2 dir = (transform.position + Random.insideUnitSphere).normalized;
        if (player != null) dir = (player.transform.position - transform.position).normalized;
        dir_pointer.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI);


    }

    public void Damage(float damage, Transform bullet)
    {
        Die();
    }
    // Explode function
    public void Die() {
        dir_pointer.gameObject.SetActive(false);
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

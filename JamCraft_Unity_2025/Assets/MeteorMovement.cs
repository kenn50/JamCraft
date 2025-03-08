using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public Vector2 move_dir;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = move_dir * speed; 
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-45f, 45f);

        transform.Rotate(0, 0, Random.Range(0, 360));
        Destroy(gameObject, 20);

    }

}

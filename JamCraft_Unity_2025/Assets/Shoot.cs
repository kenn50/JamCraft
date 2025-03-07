using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float spread;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D bulRB = bul.GetComponent<Rigidbody2D>();
            //bulRB.linearVelocity = ((Vector2)((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized + Random.insideUnitCircle * spread) * bulletSpeed;

            //bul.GetComponent<Transform>().Rotate(0, 0, Mathf.Atan2(bulRB.linearVelocity.normalized.y, bulRB.linearVelocity.normalized.x) * 180 / Mathf.PI-90);
        }
    }
}

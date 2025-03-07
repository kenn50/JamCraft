using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 dir;
    public float speed;
    public float acc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            dir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized;            
        }
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir*speed, acc * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        
    }
    /*
    private void OnTriggerEnter(Collider2D collision)
    {
        Transform col = collision.transform;

        print(collision.gameObject.tag);

        if (collision.gameObject.tag == "HorizontalWall") {
            if (Mathf.Sign(transform.position.y)==Mathf.Sign(rb.linearVelocityY))
            {
                rb.linearVelocityY *= -1;
                if (Mathf.Sign(transform.position.y) == Mathf.Sign(dir.y)) dir = new Vector2(dir.x, -dir.y);
            }
        }
        if (collision.gameObject.tag=="VerticalWall")
        {
            print(Mathf.Sign(transform.position.x));
            print(Mathf.Sign(rb.linearVelocityX));
            if (Mathf.Sign(transform.position.x) == Mathf.Sign(rb.linearVelocityX))
            {
                print("hallo");
                rb.linearVelocityX *= -1;
                if (Mathf.Sign(transform.position.x) == Mathf.Sign(dir.x)) dir = new Vector2(-dir.x, dir.y);
            }
        }

    }*/
}

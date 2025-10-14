using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 dir = Vector2.zero;
    public Transform dir_pointer;
    public float speed;
    public float acc;


    public bool control_moving = false;
    float clickTime = 0;
    float releaseTime = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float s = speed;
        float should_move = 1f;
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            clickTime = Time.time;
            dir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized;            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            releaseTime = Time.time;

            if (control_moving)
            {

                control_moving = false;
            }

            
        }

        dir_pointer.eulerAngles = new Vector3(0,0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI);
        




        if (releaseTime < clickTime && Time.time - clickTime > 0)
        {
            if (!control_moving)
            {
                control_moving = true;
            }
            var new_dir = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
            if(new_dir.magnitude > 0.5f)
            {
                dir = new_dir.normalized;
            }
            else
            {
                should_move = 0f;
            }


             s *= 1f;

        }





        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir*s*should_move, acc * Time.deltaTime);


        
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

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


    float nunu_multiplier = 1;


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

            control_moving = false;

        }

        dir_pointer.eulerAngles = new Vector3(0,0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI);





        if (releaseTime < clickTime && Time.time - clickTime > 0)
        {
            control_moving = true;

            nunu_multiplier = Mathf.Max(nunu_multiplier + Time.deltaTime * 0.3f, 1.2f);

            var from_player_to_mouse = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
            if (from_player_to_mouse.magnitude > 0.5f)
            {
                dir = dir + from_player_to_mouse.normalized * Time.deltaTime * 3 * nunu_multiplier;
                dir /= Mathf.Max(dir.magnitude, 1);
            }
            else
            {
                should_move = 0f;
            }
        }
        else
        {
            nunu_multiplier = Mathf.Min(nunu_multiplier - Time.deltaTime * 0.2f, 1f);
        }





         rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir*s*should_move*nunu_multiplier, acc * Time.deltaTime);


        
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

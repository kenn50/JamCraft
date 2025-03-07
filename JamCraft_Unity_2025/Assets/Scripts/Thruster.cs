using UnityEngine;

public class Thruster : MonoBehaviour
{

    public bool go;
    Rigidbody2D rb;
    public float power;
    public KeyCode key;

    public ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particles.Play(); particles.enableEmission = false;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(key)) {
            rb.AddForceAtPosition(transform.TransformDirection(new Vector2(0, power)), transform.position);

            //particles.Play();
        }
        //else particles.Stop();
    }
    private void Update() {
        if(Input.GetKeyDown(key)) particles.enableEmission=true;
        if (Input.GetKeyUp(key)) particles.enableEmission=false;

    }
}

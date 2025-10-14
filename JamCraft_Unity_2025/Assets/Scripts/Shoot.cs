using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float spread;

    public string state = "normal";


    public float end_power_time;

    public AudioSource audiosource;
    

    FireAnim fire_anim;



    private void Start() {
        
        fire_anim = GetComponent<FireAnim>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<Move>().control_moving) return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire_anim.trigger_fire_anim();

            if (state == "triple") TripleShot();
            else NormalShoot();
        }



    }



    void NormalShoot() {
        
        audiosource.pitch = Random.Range(0.9f, 1.1f);
        audiosource.Play();
        Fire(((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized);
        
    }
    void TripleShot () {
        
        audiosource.pitch = Random.Range(0.9f, 1.1f);
        audiosource.Play();
        Fire(((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized);
        Fire(Quaternion.Euler(0,0,-30) * ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized);
        Fire(Quaternion.Euler(0, 0, 30) * ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized);
        
    }

    

    void Fire (Vector2 dir) {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);

        bul.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI - 90);
        
    }


 }

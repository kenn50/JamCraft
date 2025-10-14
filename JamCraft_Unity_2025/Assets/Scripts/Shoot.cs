using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float spread;

    string state = "normal";

    public Sprite normalSprite, graySprite;
    SpriteRenderer sr;

    public float end_power_time;

    public AudioSource audiosource;
    public AudioSource audiosourcePowerUp;

    FireAnim fire_anim;



    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        fire_anim = GetComponent<FireAnim>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "triple") CrazyColors();


        if (GetComponent<Move>().control_moving) return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire_anim.trigger_fire_anim();

            if (state == "triple") TripleShot();
            else NormalShoot();
        }



        if (Time.time > end_power_time) {
            SetState("normal");
        }
    }

    public void SetState(string mode) {
        state = mode;
        if (state == "normal") {
            sr.sprite = normalSprite;
            sr.color = Color.white;
        }
        else if (state == "triple") {
            sr.sprite = graySprite;
            audiosourcePowerUp.Play();
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

    void CrazyColors() {
        sr.color = Color.HSVToRGB((Time.time / 2) % 1, 1, 1);
    }

    void Fire (Vector2 dir) {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);

        bul.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI - 90);
        
    }


 }

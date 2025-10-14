using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class Player : MonoBehaviour, IDestructable
{

    public GameObject explosion;
    public Text scoreText;

    public Sprite normalSprite, graySprite;
    SpriteRenderer sr;

    public AudioSource audiosourcePowerUp;





    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    private void OnCollisionEnter2D(Collision2D collision) {

        string tag  = collision.gameObject.tag;

        switch (tag) {
            case "Meteor":
                Die();
                break;
            case "Power":
                Power powerScript = collision.gameObject.GetComponent<Power>();
                var power = powerScript.power;

                switch (power)
                {
                    case "triple":

                        sr.sprite = graySprite;
                        audiosourcePowerUp.Play();
                        Shoot shootScript = GetComponent<Shoot>();

                        shootScript.state = power;
                        StartCoroutine(CrazyColors(powerScript.duration));

                        RunAfterDelay(powerScript.duration, () => {
                            shootScript.state = "normal";
                            ResetSprite();
                        });

                        break;
                    case "speed_up":
                        var move_script = GetComponent<Move>();
                        sr.sprite = graySprite;
                        sr.color = Color.cyan;

                        var s = move_script.speed;
                        move_script.speed*= powerScript.strength;
                        RunAfterDelay(powerScript.duration, () => {
                            move_script.speed = s;
                            ResetSprite();
                        });

                        break;
                }
                Destroy(collision.gameObject);

                break;

            

        }
    }






    void ResetSprite()
    {
        sr.sprite = normalSprite;
        sr.color = Color.white;
    }

    public void Damage(float damage, Transform t) {
        Die();
    }

    public void Die() {
        GM.singleton.ActivateDeathScreen();
        Instantiate(explosion, transform.position, Quaternion.identity);
        scoreText.enabled = false;
        Destroy(gameObject);

    }


    void RunAfterDelay(float delay, Action action)
    {
        StartCoroutine(RunAfterDelayCoroutine(delay, action));
    }

    IEnumerator RunAfterDelayCoroutine(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    IEnumerator CrazyColors(float duration)
    {
        float t = 0;
        while (t < duration)
        {
            sr.color = Color.HSVToRGB((Time.time / 2) % 1, 1, 1);
            t += Time.deltaTime;
            yield return null;
        }

        
    }




}

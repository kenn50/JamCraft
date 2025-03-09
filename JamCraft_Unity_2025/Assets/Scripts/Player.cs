using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour, IDestructable
{

    public GameObject explosion;
    public Text scoreText;


    private void OnCollisionEnter2D(Collision2D collision) {

        string tag  = collision.gameObject.tag;



        


        switch (tag) {
            case "Meteor":
                Die();
                break;
            case "Power":
                Shoot shootScript = GetComponent<Shoot>();
                Power powerScript = collision.gameObject.GetComponent<Power>();
                shootScript.SetState(powerScript.power);
                shootScript.end_power_time = Time.time + powerScript.duration;

                Destroy(collision.gameObject);

                break;
            

        }
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




}

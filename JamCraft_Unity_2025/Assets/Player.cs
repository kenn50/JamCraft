using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDestructable
{

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
        SceneManager.LoadScene(0);

    }




}

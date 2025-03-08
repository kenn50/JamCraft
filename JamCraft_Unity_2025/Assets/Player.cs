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
            

        }
    }

    public void Damage(float damage, Transform t) {
        Die();
    }

    public void Die() {
        SceneManager.LoadScene(0);

    }




}

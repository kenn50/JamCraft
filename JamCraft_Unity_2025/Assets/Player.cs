using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) {

        string tag  = collision.gameObject.tag;

        


        switch (tag) {
            case "Meteor":
                Die();
                break;
            

        }
    }


    public void Die() {
        Destroy(gameObject);

    }




}

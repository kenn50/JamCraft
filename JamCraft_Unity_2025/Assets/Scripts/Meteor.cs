using UnityEngine;
using System.Collections.Generic;

public class Meteor : MonoBehaviour, IDestructable {
    public float speed;
    public Vector2 move_dir;

    public GameObject meteor_explosion;
    public GameObject dustParticle;

    public List<Sprite> meteor_sprites;
    int current = 0;

    private Collider2D c2d;

    public float hp = 1;

    public AudioSource audioBoom;
    public AudioSource audioHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        current = 0;
        GetComponent<SpriteRenderer>().sprite = meteor_sprites[current];
        c2d = GetComponent<Collider2D>(); // Cache the collider

    }



    public void Damage (float damage, Transform bullet) {
        hp -= damage;
        current += 1;
        GetComponent<SpriteRenderer>().sprite = meteor_sprites[Mathf.Clamp(current, 0, meteor_sprites.Count - 1)];

        if (hp <= 0) Die();
        else {
            Destroy(Instantiate(dustParticle, bullet.position, bullet.rotation), 2);
            audioHit.pitch = Random.Range(1.2f, 1.3f);
            audioHit.Play();
        }
        
    }

    // Explode function
    public void Die() {
        GameObject g = Instantiate(meteor_explosion, transform.position, Quaternion.identity, transform);
        g.transform.localScale *= Mathf.Sqrt(transform.localScale.x);
        c2d.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().linearDamping = 2;
        GetComponent<Rigidbody2D>().angularVelocity *= 0;

        
        audioBoom.pitch = Random.Range(1f, 1.1f) - transform.localScale.x * 0.1f;
        audioBoom.Play();

        Destroy(gameObject,3);
    }

   
}





public interface IDestructable {

    void Damage(float damage, Transform bullet);
    void Die();
}
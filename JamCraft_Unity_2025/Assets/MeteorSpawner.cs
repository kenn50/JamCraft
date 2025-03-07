using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;

    public Transform ll, ur;

    float lastTime;

    public float interval_min, interval_max;

    public float min_distance_to_player;

    float interval;


    private void Start() {
        interval = Random.Range(interval_min, interval_max);
        lastTime = Time.time;
    }
    public void Update() {
        if (Time.time - lastTime > interval) {
            interval = Random.Range(interval_min, interval_max);
            lastTime = Time.time;
            SpawnMeteor(0);

        }
         

    }

    void SpawnMeteor(int depth) {
        float x_range = ur.position.x - ll.position.x;
        float y_range = ur.position.y - ll.position.y;

        Vector2 spawn_pos = Vector2.zero;
        Vector2 target_pos = Vector2.zero;
        
        if (Random.Range(0f, 1f) > 0.5f) {
            spawn_pos += Vector2.right * (ll.position.x + Random.Range(0f, x_range));
            target_pos += Vector2.right * (ll.position.x + Random.Range(0f, x_range));
            if (Random.Range(0f, 1f) > 0.5f) {
                //Down
                spawn_pos += Vector2.up * ll.position.y;
                target_pos += Vector2.up * ur.position.y;


            }
            else {
                //Up
                spawn_pos += Vector2.up * ur.position.y;
                target_pos += Vector2.up * ll.position.y;

            }
        }
        else {
            spawn_pos += Vector2.up * (ll.position.y + Random.Range(0, y_range));
            target_pos += Vector2.up * (ll.position.y + Random.Range(0, y_range));
            if (Random.Range(0f, 1f) > 0.5f) {
                //Left
                spawn_pos += Vector2.right * ll.position.x;
                target_pos += Vector2.right * ur.position.x;


            }
            else {
                //Right

                spawn_pos += Vector2.right * ur.position.x;
                target_pos += Vector2.right * ll.position.x;


            }

        }

        float distance_to_player = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, spawn_pos);

        if (distance_to_player < min_distance_to_player) {
            if(depth < 10) SpawnMeteor(depth + 1);
        }
        else {
            GameObject g = Instantiate(meteor, spawn_pos, Quaternion.identity);
            g.GetComponent<Meteor>().move_dir = (target_pos - spawn_pos).normalized;
        }

        
        



    }
}

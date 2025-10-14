using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;

    public Transform ll, ur;

    float lastTime;



    Vector2 interval = new Vector2(1000,1000);

    public Vector2 Interval {
        get { return interval; }
        set {
            interval = value;
            current_interval = Random.Range(interval.x, interval.y);

        }
    }

    public float min_distance_to_player;

    float current_interval;


    private void Start() {
        current_interval = Random.Range(interval.x, interval.y);
        lastTime = Time.time;
    }
    public void Update() {
        if (Time.time - lastTime > current_interval) {
            current_interval = Random.Range(interval.x, interval.y);
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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance_to_player = 1000;
        if (player != null)
            distance_to_player = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, spawn_pos);

        if (distance_to_player < min_distance_to_player) {
            if(depth < 10) SpawnMeteor(depth + 1);
        }
        else {
            GameObject g = Instantiate(meteor, spawn_pos, Quaternion.identity);
            if(g.GetComponent<MeteorMovement>() != null)
            {
                g.GetComponent<MeteorMovement>().move_dir = (target_pos - spawn_pos).normalized;
            }
        }

        
        



    }
}

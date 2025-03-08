using UnityEngine;

public class GM : MonoBehaviour
{
    public ProgressBar time_bar;

    

    public int player_kills = 0;

    public float seconds_to_next_round = 20f;



    private void Start() {
        time_bar.on_full += () => { print("Full"); };
    }

    public void Update() {
        time_bar.percent_filled += Time.deltaTime/seconds_to_next_round;
        
    }
}

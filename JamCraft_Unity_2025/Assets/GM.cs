using UnityEngine;

public class GM : MonoBehaviour
{
    public ProgressBar time_bar;

    public int player_kills = 0;


    private void Start() {
        time_bar.on_full += () => { print("Full"); };
    }

    public void Update() {
        time_bar.percent_filled += Time.deltaTime*0.05f;
        
    }
}

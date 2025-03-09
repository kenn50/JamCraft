using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour
{
    public Text death_screen_score;
    public Text death_screen_high_score;

    public static GM singleton;

    public GameObject death_screen;
    public ProgressBar time_bar;
    int current_wave  = -1;

    public Text wave_text;

    public MeteorSpawner meteor_spawner, big_meteor_spawner, ufo_spawner, power_spawner;

    bool started = false;
    public ScoreScript scoreScript;
    
    [System.Serializable]
    public class Wave {
        public Vector2 meteor_spawner_interval;
        public Vector2 big_meteor_spawner_interval;
        public Vector2 ufo_spawner_interval;
        public Vector2 power_spawner_interval;
    }

    public List<Wave> waves;

    public Wave hardest;
    


    public float seconds_to_next_round = 20f;



    private void Start() {
        if (singleton == null) {
            singleton = this;
        }
        else {
            Debug.LogWarning("Multiple GMS");
            Destroy(gameObject);

        }
        //BeginGame();
    }
    public void BeginGame() {
        NextWave();
        time_bar.on_full += () => {
            NextWave();
        };
        started = true;
        scoreScript.enabled = true;
    }

    public void ActivateDeathScreen() {
        death_screen.SetActive(true);
        death_screen_score.text = "Score: " + scoreScript.score.ToString();
        scoreScript.UpdateHighscore();
        death_screen_high_score.text = "Highscore: " + ScoreScript.highScore.ToString();


    }

    void NextWave() {
        current_wave++;
        wave_text.text = (current_wave + 1).ToString();
        int c = waves.Count;

        if (current_wave < c) {
            meteor_spawner.Interval = waves[current_wave].meteor_spawner_interval;
            big_meteor_spawner.Interval = waves[current_wave].big_meteor_spawner_interval;
            ufo_spawner.Interval = waves[current_wave].ufo_spawner_interval;
            power_spawner.Interval = waves[current_wave].power_spawner_interval;
        }
        else {
            Vector2 m = meteor_spawner.Interval;
            m *= 0.9f;
            m.x = Mathf.Max(m.x, hardest.meteor_spawner_interval.x);
            m.y = Mathf.Max(m.y, hardest.meteor_spawner_interval.y);
            meteor_spawner.Interval = m;

            m = big_meteor_spawner.Interval;
            m *= 0.9f;
            m.x = Mathf.Max(m.x, hardest.big_meteor_spawner_interval.x);
            m.y = Mathf.Max(m.y, hardest.big_meteor_spawner_interval.y);
            big_meteor_spawner.Interval = m;


            m = ufo_spawner.Interval;
            m *= 0.9f;
            m.x = Mathf.Max(m.x, hardest.ufo_spawner_interval.x);
            m.y = Mathf.Max(m.y, hardest.ufo_spawner_interval.y);
            ufo_spawner.Interval = m;


        }
    }

    public void Update() {
        if (started) time_bar.percent_filled += Time.deltaTime/seconds_to_next_round;

        
    }
}

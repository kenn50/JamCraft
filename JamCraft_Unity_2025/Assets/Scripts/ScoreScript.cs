using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text text;
    float time = 0;
    public int score = 0;


    

    public static int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        score = ((int)Mathf.Floor(time));
        text.text = score.ToString();
    }


    public void UpdateHighscore() {
        if (score > highScore) highScore = score;
    }
}

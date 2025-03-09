using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyPress : MonoBehaviour
{
    float time;
    private void Start() {
        time = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && Time.time > time + 0.4f) SceneManager.LoadScene(0); 
    }
}

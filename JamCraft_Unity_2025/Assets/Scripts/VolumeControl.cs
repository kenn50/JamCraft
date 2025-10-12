using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public Text vt;

    public float vol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mathf.Clamp(AudioListener.volume, 0f, 1f);
        AudioListener.volume = vol;
    }

    void Update()
    {
        vt.text = "Volume: " + Mathf.Round(AudioListener.volume*100f) + "% \n(O/P) - Control";
        if (Input.GetKeyDown(KeyCode.O))
        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.03f, 0f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume += 0.03f, 0f, 1f);
        }

    }



}

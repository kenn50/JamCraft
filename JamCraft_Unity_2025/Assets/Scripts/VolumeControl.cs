using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    [Range(0,1)]
    public float vol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioListener.volume = vol;
    }



}

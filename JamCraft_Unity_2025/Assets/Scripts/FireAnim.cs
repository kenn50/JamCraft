using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class FireAnim : MonoBehaviour
{

    public float mult = 0.93f;
    public float t = 0.2f;
    public int frames_small = 6;
    public int frames_large = 6;
    Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    public void trigger_fire_anim()
    {
        StopAllCoroutines();
        StartCoroutine(fire_anim());
    }

    IEnumerator fire_anim()
    {
        
        transform.localScale = startScale;
        for (int i = 0; i < frames_small; i++)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScale * mult, t);
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < frames_large; i++)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, t);
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}

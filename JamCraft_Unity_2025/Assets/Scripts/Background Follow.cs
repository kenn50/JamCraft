using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(Mathf.Floor(target.position.x * 0.02f)*50, Mathf.Floor(target.position.y * 0.02f)*50);
    }
}

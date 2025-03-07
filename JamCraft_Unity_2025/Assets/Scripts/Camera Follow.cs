using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;


    // Update is called once per frame
    void Update()
    {

        Vector2 pos = new Vector2(0,0);
        int n = 0;
        foreach (Transform child in target) {
            n++;
            pos += (Vector2)child.position;
        }
        transform.position = (Vector3)pos/n + new Vector3(0,0,-10);
    }
}

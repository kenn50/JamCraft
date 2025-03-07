using UnityEngine;

public class DragController : MonoBehaviour {

    public Rigidbody2D rb;

    public float maxRotSpeed;
    public float lightDrag;
    public float heavyDrag;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        SetAngularDampening();
    }

    void SetAngularDampening () {

        int rotDir = ((Input.GetKey(KeyCode.A)) ? 1 : 0) - ((Input.GetKey(KeyCode.D)) ? 1 : 0);

        rb.angularDamping = heavyDrag;
        if (Mathf.Abs(rb.angularVelocity) > maxRotSpeed) return;
        if (!(rb.angularVelocity > 0 && rotDir > 0) && !(rb.angularVelocity < 0 && rotDir < 0)) return;

        rb.angularDamping = lightDrag;
    }
}


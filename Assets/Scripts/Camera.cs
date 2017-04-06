using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject player;

    Vector2 mouseLook;
    Vector2 smooth;
    public float sensitivity = 5f;
    public float smoothing = 2f;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        Vector2 mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouse = Vector2.Scale(mouse, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mouse.x, 1 / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouse.y, 1 / smoothing);
        mouseLook += smooth;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}

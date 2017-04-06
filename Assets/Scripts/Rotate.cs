using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField] float rotationSpeed = 100.0f;

	void Update ()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}

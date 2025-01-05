using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float speed = 5f; // Speed of the wall movement

    private void Update()
    {
        // Move the wall forward
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}


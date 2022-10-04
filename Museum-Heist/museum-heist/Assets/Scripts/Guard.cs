using UnityEngine;

public class Guard : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, -1.0f * Time.fixedDeltaTime * 20.0f);
    }
}

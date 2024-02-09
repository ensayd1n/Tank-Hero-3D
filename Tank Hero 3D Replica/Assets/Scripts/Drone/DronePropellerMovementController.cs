using UnityEngine;

public class DronePropellerMovementController : MonoBehaviour
{
    [Header("Input Values")] 
    public float RotationSpeed;

    private void FixedUpdate()
    {
        Rotation();
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed);
    }
}

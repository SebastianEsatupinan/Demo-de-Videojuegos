using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseX = 1, MouseY = 2, MouseXandY = 3 }
    public RotationAxes axes = RotationAxes.MouseX;

    public float sensitivityX = 6f;
    public float sensitivityY = 15f;

    public float minimumX = -360f;
    public float maximumX = 360f;

    public float minimumY = -60f;
    public float maximumY = 60f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, minimumY, maximumY);

            rotationY += Input.GetAxis("Mouse X") * sensitivityX;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}

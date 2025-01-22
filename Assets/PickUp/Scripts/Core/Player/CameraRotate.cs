using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _sensitivity; 
    [SerializeField] private float _maxYAngle;
    private float _mouseX;
    private float _mouseY;
    private float _rotationX;

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * _mouseX * _sensitivity);

        _rotationX -= _mouseY * _sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}
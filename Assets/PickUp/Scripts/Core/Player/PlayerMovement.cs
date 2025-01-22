using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _moveDirection;
    private float _horizontal;
    private float _vertical;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _moveDirection = _vertical * transform.forward + _horizontal * transform.right;
        _moveDirection.y -= 9.81f * Time.deltaTime;

        _characterController.Move(_moveDirection * _speed * Time.deltaTime);
    }
}

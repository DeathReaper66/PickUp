using UnityEngine;
using Zenject;
[RequireComponent(typeof(Rigidbody))]

public class Item : MonoBehaviour, IItem
{
    [Inject] private PickUp _pickUp;

    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePosition();
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickUp>() == _pickUp)
        {
            _pickUp.AddItem(this);
            OnPickUpEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PickUp>() == _pickUp)
        {
            _pickUp.RemoveItem(this);
            OnPickUpExit();
        }
    }

    public void OnPickUpEnter()
    {
        Debug.Log("Item enter");
    }

    public void OnPickUpExit()
    {
        Debug.Log("Item exit");
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _numberOfItemsToStart;
    [SerializeField] private List<Item> _items;

    [SerializeField] private GameObject _endScreen;

    public void AddItem(Item item)
    {
        _items.Add(item);
        if (_items.Count == _numberOfItemsToStart)
            _endScreen.SetActive(true);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
}

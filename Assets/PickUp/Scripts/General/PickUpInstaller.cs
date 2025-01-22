using UnityEngine;
using Zenject;

public class PickUpInstaller : MonoInstaller
{
    [SerializeField] private PickUp _pickUp;

    public override void InstallBindings()
    {
        var pickUpInstance = Container.InstantiatePrefabForComponent<PickUp>(_pickUp);

        Container.Bind<PickUp>().FromInstance(_pickUp).AsSingle();
    }
}
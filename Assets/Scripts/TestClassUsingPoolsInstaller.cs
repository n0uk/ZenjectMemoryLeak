using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TestClassUsingPoolsInstaller", menuName = "Installers/TestClassUsingPoolsInstaller")]
public class TestClassUsingPoolsInstaller : ScriptableObjectInstaller<TestClassUsingPoolsInstaller>
{
    public bool InstallWithWhenInjectedInto = true;

    public override void InstallBindings()
    {
        var binding = Container.BindMemoryPool<SpriteRenderer, MonoMemoryPool<SpriteRenderer>>();

        if (InstallWithWhenInjectedInto)
        {
            binding.WhenInjectedInto<TestClassUsingPools>();
        }

        Container.Bind<TestClassUsingPools>().AsSingle().NonLazy();
    }
}
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SceneControllerInstaller", menuName = "Installers/SceneControllerInstaller")]
public class SceneControllerInstaller : ScriptableObjectInstaller<SceneControllerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<SceneController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneController : MonoBehaviour
{
    private ZenjectSceneLoader _sceneLoader;

    [Inject]
    public void Construct(ZenjectSceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        for (var i = 0; i < 10; i++)
        {
            yield return _sceneLoader.LoadSceneAsync(1, LoadSceneMode.Single);
            yield return _sceneLoader.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        yield return new WaitForSeconds(0.1f);
        GC.Collect();
        yield return new WaitForSeconds(0.1f);
        Debug.Log("There should be zero instances.");
    }
}

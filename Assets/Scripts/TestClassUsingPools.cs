using System;
using UnityEngine;
using Zenject;

public class TestClassUsingPools
{
    public static int InstanceCount = 0;
    public TestClassUsingPools([InjectOptional]MonoMemoryPool<SpriteRenderer> sampleMemoryPool)
    {
        InstanceCount++;
        LogCurrentInstanceCount();
    }

    ~TestClassUsingPools()
    {
        InstanceCount--;
        LogCurrentInstanceCount();
    }

    private void LogCurrentInstanceCount()
    {
        Debug.Log($"Instance count: {InstanceCount}");
    }
}
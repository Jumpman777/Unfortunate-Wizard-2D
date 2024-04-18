using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Summon Objects Data", menuName = "Scriptable Object/Summon Objects Data")]
public class SummonObjectsDataSO : ScriptableObject
{
    [SerializeField] private List<SummonObjectData> summonObjectDataList = new();

    private void SetIds()
    {
        for (int i = 0; i < summonObjectDataList.Count; i++)
        {
            summonObjectDataList[i].id = i;
        }
    }

    public void Initialize()
    {
        SetIds();
    }
    
    public SummonObjectData GetSummonObjectData(int id)
    {
        return summonObjectDataList[id];
    }
    
    public int GetSummonObjectDataCount()
    {
        return summonObjectDataList.Count;
    }
    
    public int GetRandomId()
    {
        return UnityEngine.Random.Range(0, summonObjectDataList.Count);
    }
    
    public int GetSummonObjectDataId(SummonObjectNames name)
    {
        int id = Array.Find(summonObjectDataList.ToArray(), x => x.name == name).id;
        if (id == -1)
        {
            throw new ArgumentException("Invalid summon object name: " + name);
        }
        return id;
    }
}

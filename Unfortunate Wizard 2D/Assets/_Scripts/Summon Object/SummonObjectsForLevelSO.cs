using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Level_ Summon Objects", menuName = "Scriptable Object/Level Summon Objects")]
public class SummonObjectsForLevelSO : ScriptableObject
{
    [SerializeField] private SummonObjectsDataSO summonObjectData;
    [SerializeField] private List<SummonObjectNames> summonObjectNames = new();
    
    public int GetRandomSummonObject()
    {
        // get random summon object name from the list
        int index = Random.Range(0, summonObjectNames.Count);
        SummonObjectNames name = summonObjectNames[index];
        return summonObjectData.GetSummonObjectDataId(name);
    }
    
    
}
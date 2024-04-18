using UnityEngine;

public static class SummonObjectDataManager
{
    public static SummonObjectsDataSO SummonObjectsData { get; private set; }
    public static SummonObjectsForLevelSO CurrentLevelSummonObjects { get; private set; }

    // Caller has to execute before other scripts that need the data
    public static void LoadDataForCurrentLevel(int level)
    {
        SummonObjectsData = Resources.Load<SummonObjectsDataSO>("Summon Objects Data");
        SummonObjectsData.Initialize();
        
        var currentLevelPath = $"Level {level} Summon Objects";
        CurrentLevelSummonObjects = Resources.Load<SummonObjectsForLevelSO>(currentLevelPath);
    }
    
}

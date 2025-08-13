using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Level1, Level2, Level3 }
    private PlantState plantState;
    public int plantIndex;

    private DateTime startTime, growthTime, harvestTime;

    public bool isHarvest = false;

    private void Awake()
    {
        startTime = DateTime.Now;
        growthTime = startTime.AddSeconds(2);
        harvestTime = startTime.AddSeconds(4);
    }

    IEnumerator Start()
    {
        SetState(PlantState.Level1, true);

        while (plantState != PlantState.Level3)
        {
            if (DateTime.Now >= harvestTime)
            {
                SetState(PlantState.Level3);
                isHarvest = true;
            }
            else if (DateTime.Now >= growthTime)
            {
                SetState(PlantState.Level2);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void SetState(PlantState newState, bool isInit = false)
    {
        if (plantState == newState && isInit == false) return;

        plantState = newState;
        
        for (int i=0; i<3; i++)
            transform.GetChild(i).gameObject.SetActive(false);
        
        transform.GetChild((int)plantState).gameObject.SetActive(true);
    }
    
    
}

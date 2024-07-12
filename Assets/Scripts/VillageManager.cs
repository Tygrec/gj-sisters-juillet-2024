using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private VillageData _data;

    public VillageManager CreateManagerFromData(VillageData data, Vector3 position) {
        VillageManager manager = Instantiate(Resources.Load<VillageManager>("Prefabs/Village"));
        manager._data = data;
        manager.transform.position = position;

        return manager;
    }

    private void OnMouseDown() {
        
    }
}

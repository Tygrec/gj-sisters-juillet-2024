using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private VillageData _data;

    private void Awake() {
        if (_data == null)
            _data = new VillageData();
    }

    public int GetFA() {
        return _data.FA;
    }

    public static VillageManager CreateManagerFromData(VillageData data, Vector3 position) {
        VillageManager manager = Instantiate(Resources.Load<VillageManager>("Prefabs/Village"));
        manager._data = data;
        manager.transform.position = position;

        return manager;
    }

    private void OnMouseDown() {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersButtons : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;


    private void OnMouseDown()
    {

        var buttons = FindObjectsOfType<DefendersButtons>();
        foreach (DefendersButtons b in buttons)
        {
            b.GetComponent<SpriteRenderer>().color = new Color32(33, 33, 33, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedSpawnder(defenderPrefab);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendersButtons : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;


    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogError(name + "Has not cost text!");
            return;
        }

        int cost = defenderPrefab.StarCost;
        if (PlayerSettings.GetDifficulty() == 0)
        {
            cost /= 2;
        }
        else if (PlayerSettings.GetDifficulty() == 2)
        {
            cost *= 2;
        }
        

        costText.text = cost.ToString();

    }


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

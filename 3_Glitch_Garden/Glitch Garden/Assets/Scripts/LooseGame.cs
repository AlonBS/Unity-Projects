using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseGame : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //otherCollider.gameObject.GetComponent<>
        FindObjectOfType<Lives>().TakeLives(1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseGame : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<Lives>().TakeLives(1);
        Destroy(otherCollider.gameObject);
    }

}

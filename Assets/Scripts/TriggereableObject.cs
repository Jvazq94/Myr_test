using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggereableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float sizeUpgrade;
    public float speedUpgrade;
    public float jumpUpgrade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.gameObject.GetComponent<Player>().UpgradeStats(speedUpgrade, jumpUpgrade, sizeUpgrade);

        Destroy(this.gameObject);
        
           
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwarfFloatingPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().text = "+ $" + 1 * Game.playerData.miner;//_GM.miner;
        Destroy(gameObject, 1f);
        //transform.localPosition += new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(0, 0.01f, 0);
    }
}

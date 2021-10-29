using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.TextRenderingModule;

public class FloatingPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().text = "+ $" + Game.playerData.power;//_GM.power;
        Destroy(gameObject, 1f);
        //transform.localPosition += new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(0, 0.01f, 0);
    }
}

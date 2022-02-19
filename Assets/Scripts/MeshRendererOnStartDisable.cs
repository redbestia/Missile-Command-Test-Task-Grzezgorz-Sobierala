using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererOnStartDisable : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}

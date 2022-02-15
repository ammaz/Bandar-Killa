using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSelectionScript : MonoBehaviour
{
    public Material green;
    public void EnableSelection()
    {
        //this.gameObject.SetActive(true);
        this.GetComponent<MeshRenderer>().material = green;
    }
}

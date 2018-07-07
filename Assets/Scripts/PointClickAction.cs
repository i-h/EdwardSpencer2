using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClickAction : MonoBehaviour {
    public virtual void OnClicked(RaycastHit hitInfo)
    {
        Debug.LogWarning("No action for " + name + "!");
    }
}

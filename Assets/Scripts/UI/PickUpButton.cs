using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PickUpButton : MonoBehaviour {
    public Button Btn;
    private void Awake()
    {
        Btn = GetComponent<Button>();
    }
}

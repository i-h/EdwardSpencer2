using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour {
    Button _btnComponent;

    private void Awake()
    {
        _btnComponent = GetComponent<Button>();
        _btnComponent.onClick.AddListener(CloseWindow);
    }

    public void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    public List<TagAction> ActionsForTags = new List<TagAction>();

	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}
    private void CheckInput()
    {
        bool mouseDown = Input.GetMouseButtonDown(0);
        if (Input.GetMouseButton(0))
        {
            
            Ray mouseWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;
            if (Physics.Raycast(mouseWorld, out mouseHit))
            {
                foreach(TagAction a in ActionsForTags)
                {
                    if (a.Tag == mouseHit.collider.tag && (!a.OnMouseDown || mouseDown))                    
                        a.Action.OnClicked(mouseHit);
                    
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerData.Instance.ShowInventory();
        }
    }

    [System.Serializable]
    public struct TagAction
    {
        public string Tag;
        public PointClickAction Action;
        public bool OnMouseDown;
    }
}

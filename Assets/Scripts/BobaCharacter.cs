using UnityEngine;
using System.Collections;

public class BobaCharacter : MonoBehaviour {

    public int BobaType;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // turn on or off selected animation
    public void SetSelected(bool selected)
    {
        animator.SetBool("selected", selected);
    }

    // turn on or off highlight animation
    public void SetHighlight(bool highlight)
    {
        animator.SetBool("highlight", highlight);
    }

    // highlighted or not?
    public bool HighlightOrNah()
    {
        return animator.GetBool("highlight");
    }

    public bool Check(BobaCharacter bobachar)
    {
        if (!HighlightOrNah() && BobaType == bobachar.BobaType)
        {
            Vector3 distance = transform.position - bobachar.transform.position;
            if (distance.sqrMagnitude < (1.5f * 1.5f))
            {
                return true;
            }
        }
        return false;
    }
}

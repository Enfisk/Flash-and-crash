using UnityEngine;
using System.Collections;

public class ActivationArea : MonoBehaviour {
    public BaseActivatee activatee;
    public float waitTime = 2.0f;
    public Animator anim;
    public Transform readyText;
    public Sprite[] sprites;

    private float timeWaited = 0.0f;
    private bool activated = false;
    private SpriteRenderer readyTextRenderer;
    //private Animator readyTextAnimator;

    void Start()
    {
        if (!readyText)
        {
            foreach (Transform child in transform)
            {
                if (child.name.Contains("ReadyText"))
                {
                    readyText = child;
                    break;
                }
            }
        }

        readyTextRenderer = (SpriteRenderer)readyText.GetComponent(typeof(SpriteRenderer));
        //readyTextAnimator = (Animator)readyText.GetComponent(typeof(Animator));
    }
    
    void OnTriggerStay()
    {
        timeWaited += Time.deltaTime;

        if (timeWaited >= waitTime && !activated)
        {
            anim.SetBool("Activated", true);
            activatee.Activate();
            activated = true;
            readyTextRenderer.sprite = sprites[1];
            //readyText.position += new Vector3(0, 2, 0);
            //readyTextAnimator.SetTrigger("Triggered");
        }
    }

    void OnTriggerExit()
    {
        if (activated)
        {
            activatee.Deactivate();
            //readyText.position -= new Vector3(0, 2, 0);
        }
        anim.SetBool("Activated", false);
        timeWaited = 0.0f;
        activated = false;
        readyTextRenderer.sprite = sprites[0];
        //readyTextAnimator.SetBool("Triggered", false);
    }
}

//Hacked together, but meh.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishTextManager : MonoBehaviour
{
    public float movementSpeed = 20.0f;
    public float scaleTime = 1.0f;
    public Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);

    private Dictionary<string, GameObject> children;
    private bool movedText;

    void Start()
    {
        children = new Dictionary<string, GameObject>();

        foreach (Transform child in transform)
        {
            children.Add(child.name, child.gameObject);
        }
    }

    void Update()
    {
        if (Globals.gameFinished && !movedText)
        {
            StartCoroutine(MoveText(name.Contains(Globals.gameWinner) ? children["Win Text"] : children["Lose Text"]));
            movedText = true;
        }
    }

    private IEnumerator MoveText(GameObject p_text)
    {
        float originalTime = scaleTime;
        float currentTime = scaleTime;

        while (p_text.transform.position != children["Point 1"].transform.position)
        {
            p_text.transform.position = Vector3.MoveTowards(p_text.transform.position, children["Point 1"].transform.position, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.5f);

        while (p_text.transform.position != children["Point 2"].transform.position)
        {
            currentTime -= Time.deltaTime;
            p_text.transform.localScale = Vector3.MoveTowards(p_text.transform.localScale, targetScale, currentTime / originalTime);            //This doesn't really behave like I want it to. Fix later?
            p_text.transform.position = Vector3.MoveTowards(p_text.transform.position, children["Point 2"].transform.position, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

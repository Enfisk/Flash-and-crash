using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishTextManager : MonoBehaviour
{
    public float movementSpeed = 20.0f;

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

    private IEnumerator MoveText(GameObject p_text)     //Hacked together, but meh.
    {
        while (p_text.transform.position != children["Point 1"].transform.position)
        {
            p_text.transform.position = Vector3.MoveTowards(p_text.transform.position, children["Point 1"].transform.position, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.5f);

        while (p_text.transform.position != children["Point 2"].transform.position)
        {
            p_text.transform.position = Vector3.MoveTowards(p_text.transform.position, children["Point 2"].transform.position, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

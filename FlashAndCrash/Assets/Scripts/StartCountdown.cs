using UnityEngine;
using System.Collections;

public class StartCountdown : MonoBehaviour {
    public Sprite[] sprites;
    public Light[] lights;
    public SpriteRenderer spriteRenderer;

    private CompletionTimer timer;

	// Use this for initialization
	void Start () {
        timer = (CompletionTimer)GetComponent(typeof(CompletionTimer));
        StartCoroutine(StartTimer());
	}

    public IEnumerator StartTimer()
    {
        for (int i = 0; i < 4; ++i)
        {
            spriteRenderer.sprite = sprites[i];
            lights[i].intensity = 8f;

            if (timer && i == 3)
            {
                timer.Activate();
            }

            yield return new WaitForSeconds(1);
        }

        spriteRenderer.sprite = null;
    }
}

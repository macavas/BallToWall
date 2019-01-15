using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public static BackgroundManager instance;

    Renderer mSpriteRenderer;
    public Color[] colors;
    // Use this for initialization
    void Start () {
		if(instance == null)
        {
            instance = this;
        }

        mSpriteRenderer = GetComponent<Renderer>();
	}
	
    public void changeRandomColor()
    {
        int col = Random.Range(0, colors.Length);
        mSpriteRenderer.material.color = Color.Lerp(Color.white, colors[col], 2000);
    }
}

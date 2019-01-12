using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager instance;

    public GameObject wallHitAnimation;
    public GameObject deadEffectAnimation;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
	}
	
    public void CreateHitWallAnimation(Vector2 hitPoint)
    {
        GameObject effect= Instantiate(wallHitAnimation, hitPoint, Quaternion.identity);

        Destroy(effect, 0.5f);
    }

    public void CreateDeadAnimation(Vector2 hitPoint)
    {
        GameObject effect = Instantiate(deadEffectAnimation, hitPoint, Quaternion.identity);

        Destroy(effect, .5f);
    }

}

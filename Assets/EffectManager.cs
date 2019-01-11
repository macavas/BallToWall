using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager instance;

    public GameObject wallHitAnimation;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
	}
	
    public void CreateHitWallAnimation(Vector2 hitPoint)
    {
        GameObject effect= Instantiate(wallHitAnimation, hitPoint, Quaternion.identity);

        Destroy(effect, 0.23f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager instance;

    public GameObject wallHitAnimation;
    public GameObject deadEffectAnimation;
    public CameraShake cameraShake;

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
        StartCoroutine(CreateDeadAnimationEnumerator(hitPoint));
    }

    IEnumerator CreateDeadAnimationEnumerator(Vector2 hitPoint)
    {
        GameObject effect = Instantiate(deadEffectAnimation, hitPoint, Quaternion.identity);
        Time.timeScale = .1f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        Destroy(effect, .5f);
    }

    public void CameraShakeAnimation()
    {
        StartCoroutine(cameraShake.Shake(0.5f, 0.2f));
    }

}

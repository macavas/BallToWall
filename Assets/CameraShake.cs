﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0;

        while(elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }



}

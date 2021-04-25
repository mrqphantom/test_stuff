﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{   
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orginalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-0.2f, 0.2f) * magnitude;
            float y = Random.Range(-0.2f, 0.2f) * magnitude;
            elapsed += Time.deltaTime;
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            yield return null;
        }
        transform.localPosition = orginalPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Animation")]
    public bool repeatable;
    public float speed = 2f;
    public float duration = 0.5f;
    public Vector3 offset;

    // Animation
    IEnumerator Start()
    {
        while (repeatable)
        {
            yield return RepeatLerp(transform.position, transform.position + offset, duration);
            yield return RepeatLerp(transform.position, transform.position - offset, duration);
        }
    }
    //Animation
    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1 / time) * speed;
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}

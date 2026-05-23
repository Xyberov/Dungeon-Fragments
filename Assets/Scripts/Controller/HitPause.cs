using System.Collections;
using UnityEngine;

public class HitPause : MonoBehaviour
{
    public void Pause(float duration)
    {
        StartCoroutine(DoPause(duration));
    }

    private IEnumerator DoPause(float duration)
    {
        var animator = GetComponent<Animator>();
        animator.speed = 0f;
        yield return new WaitForSecondsRealtime(duration);
        animator.speed = 1f;
    }
}
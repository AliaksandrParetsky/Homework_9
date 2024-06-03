using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform finishPos;

    [SerializeField] float time;

    private float currentTime;

    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        var normilezedTime = currentTime / time;
        transform.position = Vector2.Lerp(startPos.position, finishPos.position, Mathf.PingPong(normilezedTime, 1.0f));
    }
}

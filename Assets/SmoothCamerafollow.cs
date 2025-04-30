using System;
using UnityEngine;

public class SmoothCamerafollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private string playerTag = "Player"; // Tag your player prefab with "Player"
    [SerializeField] private float smoothTime = 0.3f;

    private Transform target;
    private Vector3 _currentVelocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);
            if (player != null)
            {
                target = player.transform;
                _offset = transform.position - target.position;
            }
            else
            {
                return; // Skip update if player not found yet
            }
        }

        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}


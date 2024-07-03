using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace GenshinImpactMovementSystem
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] [Range(0f, 10f)] private float defaultDistance = 6f;
        [SerializeField] [Range(0f, 10f)] private float minmumDistance = 1f;
        [SerializeField] [Range(0f, 10f)] private float maxmumDistance = 6f;

        [SerializeField][Range(0f, 10f)] private float smoothing = 4f;
        [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 1f;

        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider inputProvider;
        private float currentTargerDistance; 

        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            inputProvider = GetComponent<CinemachineInputProvider>();

            currentTargerDistance = defaultDistance;
        }

        private void Update()
        {
            Zoom();
        }

        private void Zoom()
        {
            float zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;

            currentTargerDistance = Mathf.Clamp(currentTargerDistance + zoomValue, minmumDistance, maxmumDistance);

            float currentDistance = framingTransposer.m_CameraDistance;

            if (currentDistance == currentTargerDistance)
            {
                return;
            }

            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargerDistance, smoothing * Time.deltaTime);

            framingTransposer.m_CameraDistance = lerpedZoomValue;
        }
    }
}

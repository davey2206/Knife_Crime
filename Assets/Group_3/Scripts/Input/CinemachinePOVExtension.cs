using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float clampAngle = 85f;
    [SerializeField] PlayerSettings settings;
    private Vector3 startingRotation;
    private Vector2 dir;

    protected override void OnEnable()
    {
        inputReader.mouseEvent += Move;
        base.OnEnable();
    }
    private void OnDisable()
    {
        inputReader.mouseEvent -= Move;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!vcam.Follow) return;
        if (stage != CinemachineCore.Stage.Aim) return;
        if (startingRotation == null) startingRotation = transform.localEulerAngles;

        startingRotation.x += dir.x * settings.HorizontalSensitivity * Time.deltaTime;
        startingRotation.y += dir.y * settings.VerticalSensitivity * Time.deltaTime;
        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
        state.RawOrientation = Quaternion.Euler(GetInversionValue(), startingRotation.x, 0f);
    }

    private float GetInversionValue()
    {
        return settings.InvertY ? startingRotation.y : -startingRotation.y;
    }

    private void Move(Vector2 dir)
    {
        this.dir = dir;
    }
}

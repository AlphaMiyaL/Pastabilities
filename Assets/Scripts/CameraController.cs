using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public static CameraController instance;

    public Room currRoom;
    public float movSpdwhenRoomChange;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        UpdatePosition();
    }

    private void UpdatePosition() {
        //If room isn't set, don't do anything
        if (currRoom == null) {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * movSpdwhenRoomChange);
    }

    private Vector3 GetCameraTargetPosition() {
        if (currRoom == null) {
            return Vector3.zero;
        }

        Vector3 targetPos = currRoom.GetRoomCenter();
        targetPos.z = transform.position.z;

        return targetPos;
    }

    public bool IsSwitchingScene() {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}

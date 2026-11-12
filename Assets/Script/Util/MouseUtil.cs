using UnityEngine;


public static class MouseUtil {
    private static Camera camera = Camera.main;

    public static Vector3 GetMousePositionInWorldSpace(float zValue = 0f) {

        Plane dragPlane = new(camera.transform.forward, new Vector3(0,0,zValue));
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(dragPlane.Raycast(ray, out float distance)) {
            return camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        }
       return Vector3.zero;
    }
}
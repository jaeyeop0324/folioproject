using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    public BoxCollider2D bound;

    private Vector3 minbound;
    private Vector3 maxbound;

    private float halfWidth;
    private float halfHeight;

    private Camera theCamera;

    private void Start()
    {
        theCamera = GetComponent<Camera>();
        minbound = bound.bounds.min;
        maxbound = bound.bounds.max;

        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;  //반넓이 

    }
    private void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minbound.x + halfWidth, maxbound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minbound.y + halfHeight, maxbound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }

    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : EventTrigger
{
    private float mouseStartPosX;
    private float mousePosX;
    private float swipeMovement;
    private float totalSwipeMovement;
    private bool dragging;

    public void Update() {
        if (dragging) {
            mousePosX = Input.mousePosition.x;
            swipeMovement = (mouseStartPosX - mousePosX) * -1;
            transform.position += new Vector3(swipeMovement, 0, 0);
            totalSwipeMovement += (mouseStartPosX - mousePosX)*-1;
            mouseStartPosX = Input.mousePosition.x;
        }

        // smooth post-drag
        // if (!dragging && swipeMovement > 0) Mathf.Round(swipeMovement--);
        // if (!dragging && swipeMovement < 0) Mathf.Round(swipeMovement++);
    }

    public override void OnPointerDown(PointerEventData eventData) {
        resetTotalSwipeMovement();
        mouseStartPosX = Input.mousePosition.x;
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        swipeMovement = 0;
        dragging = false;
    }

    public bool getDragging() => dragging;
    public float getSwipeMovement() => Mathf.Round(swipeMovement);
    public float getTotalSwipeMovement() => Mathf.Round(totalSwipeMovement);
    public void resetTotalSwipeMovement() => totalSwipeMovement = 0;
}

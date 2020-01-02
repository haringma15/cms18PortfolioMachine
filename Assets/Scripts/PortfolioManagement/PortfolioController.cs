using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;
    public float defaultProjectDistance = 1420;
    public float movementSpeed = 20;
    public SwipeController swipeController;
    public float swipeLimit = 200;

    private Object[] res;
    private List<Object> portfolios = new List<Object>();
    private List<Object> projects = new List<Object>();
    private GameObject portfolio;
    private bool hasPortfolio = false;
    private bool movementAllowed = true;
    private float movement;
    private int activeProjectIndex = 0;
    private int projectCount;

    void Start() {
        res = Resources.LoadAll("");
        foreach (Object r in res) if (!r.name.Contains("CollabHistory")) portfolios.Add(r);
    }

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !hasPortfolio) {
            foreach (Object p in portfolios) if (p.name.Contains(PlayerPrefs.GetString("region"))) portfolio = (GameObject) p;
            foreach (Transform t in portfolio.GetComponentsInChildren<Transform>()) if (t.gameObject.tag == "project") projects.Add(t.gameObject);
            projectCount = projects.Count;
            Instantiate(portfolio, project.transform);
            hasPortfolio = true;
        }
        if (hasPortfolio) {
            if (movementAllowed) {
                // swipe
                project.transform.localPosition += new Vector3(swipeController.getSwipeMovement(), 0, 0);

                // swipe to next
                if (!swipeController.getDragging() && swipeController.getTotalSwipeMovement() < -swipeLimit) {
                    movementAllowed = false;
                    movement += swipeController.getTotalSwipeMovement();
                    increaseActiveProjectIndex();
                }

                // swipe to previous
                if (!swipeController.getDragging() && swipeController.getTotalSwipeMovement() > swipeLimit) {
                    movementAllowed = false;
                    movement += swipeController.getTotalSwipeMovement();
                    decreaseActiveProjectIndex();
                }

                // reset position
                if (!swipeController.getDragging() && swipeController.getTotalSwipeMovement() != 0 && swipeController.getTotalSwipeMovement() > -swipeLimit && swipeController.getTotalSwipeMovement() < swipeLimit) {
                    movementAllowed = false;
                    movement += swipeController.getTotalSwipeMovement();
                }
            }
            if (movement > 0) {
                // far scroll to next
                if (movement >= defaultProjectDistance/movementSpeed) {
                    project.transform.localPosition -= new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
                    movement -= defaultProjectDistance/movementSpeed;
                }

                // final, near scroll to next
                if (movement < defaultProjectDistance/movementSpeed && movement != 0) {
                    project.transform.localPosition -= new Vector3(movement, 0, 0);
                    movement = 0;
                    swipeController.resetTotalSwipeMovement();
                }
            }
            if (movement < 0) {
                // far scroll to previous
                if (movement <= (defaultProjectDistance/movementSpeed)*-1) {
                    project.transform.localPosition += new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
                    movement += defaultProjectDistance/movementSpeed;
                }

                // final, near scroll to previous
                if (movement > (defaultProjectDistance/movementSpeed)*-1 && movement != 0) {
                    project.transform.localPosition += new Vector3(-movement, 0, 0);
                    movement = 0;
                    swipeController.resetTotalSwipeMovement();
                }
            }
            if (!movementAllowed && movement == 0) {
                float rest = project.transform.localPosition.x % defaultProjectDistance;
                if (rest == 0) movementAllowed = true;
                else {
                    float shouldPosX = activeProjectIndex * defaultProjectDistance * -1;
                    float isPosX = project.transform.localPosition.x;
                    project.transform.localPosition += new Vector3(shouldPosX - isPosX, 0, 0);
                }
            }
        }
    }

    public void closeProject() {
        project.transform.localPosition = Vector3.zero;
        swipeController.gameObject.transform.position = Vector3.zero;
        activeProjectIndex = 0;
        hasPortfolio = false;
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetInt("destroyProject", 1);
        PlayerPrefs.SetInt("zoomOut", 1);
    } 

    public void increaseActiveProjectIndex() {
        if (activeProjectIndex < projectCount - 1) {
            activeProjectIndex++;
            movement += defaultProjectDistance;
        }
    }

    public void decreaseActiveProjectIndex() {
        if (activeProjectIndex > 0) {
            activeProjectIndex--;
            movement -= defaultProjectDistance;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;
    public GameObject projectInteractives;
    public float defaultProjectDistance = 1420;
    public float movementSpeed = 20;
    public SwipeController swipeController;
    public float swipeLimit = 200;
    public TabletController tabletController;

    private List<GameObject> portfolios = new List<GameObject>();
    private List<GameObject> portfolioInteractives = new List<GameObject>();
    private List<GameObject> projects = new List<GameObject>();
    private GameObject portfolio;
    private GameObject portfolioElements;
    private bool hasPortfolio = false;
    private bool movementAllowed = true;
    private float movement;
    private int activeProjectIndex = 0;
    private int projectCount;

    void Start() {
        foreach (Transform t in project.GetComponentsInChildren<Transform>()) if (t.gameObject.tag == "portfolio") portfolios.Add(t.gameObject);
        foreach (Transform t in projectInteractives.GetComponentsInChildren<Transform>()) if (t.gameObject.tag == "portfolio") portfolioInteractives.Add(t.gameObject);
        foreach (GameObject p in portfolios) p.SetActive(false);
        foreach (GameObject p in portfolioInteractives) p.SetActive(false);
    }

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !hasPortfolio) {
            foreach (GameObject p in portfolios) if (p.name.Contains(PlayerPrefs.GetString("region"))) portfolio = p;
            foreach (GameObject pi in portfolioInteractives) if (pi.name.Contains(PlayerPrefs.GetString("region"))) portfolioElements = pi;
            foreach (Transform t in portfolio.GetComponentsInChildren<Transform>()) if (t.gameObject.tag == "project") projects.Add(t.gameObject);
            projectCount = projects.Count;
            portfolio.SetActive(true);
            portfolioElements.SetActive(true);
            hasPortfolio = true;
        }
        if (hasPortfolio) {
            if (movementAllowed) {
                // swipe
                project.transform.localPosition += new Vector3(swipeController.getSwipeMovement(), 0, 0);
                projectInteractives.transform.localPosition += new Vector3(swipeController.getSwipeMovement(), 0, 0);

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
                    projectInteractives.transform.localPosition -= new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
                    movement -= defaultProjectDistance/movementSpeed;
                }

                // final, near scroll to next
                if (movement < defaultProjectDistance/movementSpeed && movement != 0) {
                    project.transform.localPosition -= new Vector3(movement, 0, 0);
                    projectInteractives.transform.localPosition -= new Vector3(movement, 0, 0);
                    movement = 0;
                    swipeController.resetTotalSwipeMovement();
                }
            }
            if (movement < 0) {
                // far scroll to previous
                if (movement <= (defaultProjectDistance/movementSpeed)*-1) {
                    project.transform.localPosition += new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
                    projectInteractives.transform.localPosition += new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
                    movement += defaultProjectDistance/movementSpeed;
                }

                // final, near scroll to previous
                if (movement > (defaultProjectDistance/movementSpeed)*-1 && movement != 0) {
                    project.transform.localPosition += new Vector3(-movement, 0, 0);
                    projectInteractives.transform.localPosition += new Vector3(-movement, 0, 0);
                    movement = 0;
                    swipeController.resetTotalSwipeMovement();
                }
            }
            if (!movementAllowed && movement == 0) {
                float rest = project.transform.localPosition.x % defaultProjectDistance;
                if (rest == 0) movementAllowed = true;
                else {
                    float shouldXPos = activeProjectIndex * defaultProjectDistance * -1;
                    float isXPos = project.transform.localPosition.x;
                    float isXPosPI = projectInteractives.transform.localPosition.x;
                    project.transform.localPosition += new Vector3(shouldXPos - isXPos, 0, 0);
                    projectInteractives.transform.localPosition += new Vector3(shouldXPos - isXPosPI, 0, 0);
                }
            }
        }
    }

    public void closeProject() {
        projects.Clear();
        project.transform.localPosition = Vector3.zero;
        projectInteractives.transform.localPosition = Vector3.zero;
        swipeController.gameObject.transform.localPosition = Vector3.zero;
        activeProjectIndex = 0;
        portfolio.SetActive(false);
        portfolioElements.SetActive(false);
        hasPortfolio = false;
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetInt("zoomOut", 1);
        tabletController.disableAll();
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

    public string getIndex() {
        if (projectCount == 1) return "minmax";
        else if (activeProjectIndex == 0) return "min";
        else if (activeProjectIndex == projectCount-1) return "max";
        else return activeProjectIndex.ToString();
    }
}
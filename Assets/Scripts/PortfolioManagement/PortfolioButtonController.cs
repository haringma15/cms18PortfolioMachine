using UnityEngine;

public class PortfolioButtonController : MonoBehaviour
{
    public GameObject minButton;
    public GameObject maxButton;
    public PortfolioController portfolioController;

    void Update() {
        if (minButton.activeInHierarchy && portfolioController.getIndex().Contains("min")) minButton.SetActive(false);
        else if (!minButton.activeInHierarchy && !portfolioController.getIndex().Contains("min")) minButton.SetActive(true);

        if (maxButton.activeInHierarchy && portfolioController.getIndex().Contains("max")) maxButton.SetActive(false);
        else if (!maxButton.activeInHierarchy && !portfolioController.getIndex().Contains("max")) maxButton.SetActive(true);
    }
}

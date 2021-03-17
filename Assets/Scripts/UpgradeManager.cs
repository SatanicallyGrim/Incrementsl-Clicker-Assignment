using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    #region Variables
    public ScoreManager scoreManager;
    public Upgrade[] upgrades;
    public GameObject buttonPrefab;
    public Transform panelParent;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons();
    }
    void SpawnButtons()
    {
        // Loop over all Upgrades defined
        //Gets all upgrades in the array
        for (int i = 0; i < upgrades.Length; i++)
        {
            //instantiates the button prefab
            GameObject instance = Instantiate(buttonPrefab, panelParent);
            UpgradeButton button = instance.GetComponent<UpgradeButton>();
            Upgrade currentUpgrade = upgrades[i];
            button.SetAction(OnUpgradeClicked);
            button.SetUpgrade(currentUpgrade);
            // Subscribe the Button to ScoreManager's score changed event
            scoreManager.scoreChanged += button.OnScoreChanged;
        }
    }
    public void OnUpgradeClicked(Upgrade upgrade, UpgradeButton button)
    {
        // if statement to purchase upgrade 
        if (scoreManager.Score >= upgrade.purchaseCost)
        {
            //Applies the button stats
            scoreManager.PerSecond += upgrade.perSecondIncrease;
            scoreManager.Score -= upgrade.purchaseCost;
            //increases the purchase cost by doubling the value
            button.purchaseCostText.text = $"PurchaseCost: {upgrade.purchaseCost *= 2}";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}

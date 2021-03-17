using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    #region Variables
    public Text perSecondText;
    public Text purchaseCostText;
    public Text unlockCostText;

    private UpgradeEvent action;
    private Upgrade upgrade;
    private Button button;
    #endregion
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetAction(UpgradeEvent action)
    {
        this.action = action;
    }
    public void SetUpgrade(Upgrade upgrade)
    {

        this.upgrade = upgrade;
        //writes to the persecond text whilist also getting the current stat for the amount of persecond it will increase
        perSecondText.text = $"PerSecond: {upgrade.perSecondIncrease}";
        //writes the cost to the Text UI Element as well as adding the cost that is regried to purchase the upgrade
        purchaseCostText.text = $"PurchaseCost: {upgrade.purchaseCost}";
        //Writes the upgrade cost cost to the text UI Element as well as the upgrade cost for it to be interactable
        unlockCostText.text = $"UnlockCost: {upgrade.unlockCost}";               
    }
    public void OnScoreChanged(int currentScore)
    {
        //if our current score is less the required unlock cost
        if (currentScore < upgrade.unlockCost)
        {
            //disable interactivity with the button
            button.interactable = false;
        }
        else
        {
            //otherwise if it is greater then the unlock cost re-enaable its interactivity 
            button.interactable = true;
        }
    }

    
    public void Upgrade()
    {
        action.Invoke(upgrade, this);
    }
}

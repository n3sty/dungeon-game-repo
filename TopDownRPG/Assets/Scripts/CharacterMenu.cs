using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, moneyText, upgradeCostText, xpText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            // If we went too far
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnSelectionChange();
        }
        else
        {
            currentCharacterSelection++;

            // If we went too far
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }

            OnSelectionChange();
        }

    }
    public void OnSelectionChange()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    // Weapon upgrade
    public void OnUpgradeClick()
    {
        //
    }

    // Character information
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED YET";

        // Meta
        hitpointText.text = GameManager.instance.player.hitPoint.ToString();
        moneyText.text = "$" + GameManager.instance.money.ToString();
        levelText.text = "NOT IMPLEMENTED YET";

        // Xp bar
        xpText.text = "NOT IMPLEMENTED YET";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }
}

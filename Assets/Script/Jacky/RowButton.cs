using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowButton : MonoBehaviour
{
    public Button[] buttonsInSameRow;
    private Button currentButton;

    private void Start()
    {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Unselect buttons in the same row
        foreach (Button button in buttonsInSameRow)
        {
            if (button != currentButton)
            {
                button.interactable = true;
            }
        }

        // Select the clicked button
        currentButton.interactable = false;

    }
}
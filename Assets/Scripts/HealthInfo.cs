using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthInfo : MonoBehaviour
{
    public GameObject healthInfoPanel;
    public TextMeshProUGUI muscleText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI enduranceText;
    private PlayerController playerController;

    private int muscle = 15;
    private int weight = 60;
    private int endurance = 15;

    private bool isPanelVisible = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthInfoPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleHealthInfoPanel();
        }
    }

    void ToggleHealthInfoPanel()
    {
        isPanelVisible = !isPanelVisible;
        healthInfoPanel.SetActive(isPanelVisible);

        if (isPanelVisible)
        {
            UpdateHealthInfo();
            playerController.LockControls();
        }
        else
        {
            playerController.UnlockControls();
        }
    }

    void UpdateHealthInfo()
    {
        muscleText.text = $"Μύης: {muscle} ({GetMuscleCondition(muscle)})";
        weightText.text = $"Βάρος: {weight} ({GetWeightCondition(weight)})";
        enduranceText.text = $"Εντοχή: {endurance} ({GetEnduranceCondition(endurance)})";
    }

    string GetMuscleCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Καθόλου";
        else if (value > 25 && value <= 50) return "Λίγοι";
        else if (value > 50 && value <= 75) return "Πολύ";
        else return "Εξερετικοί";
    }

    string GetWeightCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Λεπτός";
        else if (value > 25 && value <= 50) return "Κανονικό";
        else if (value > 50 && value <= 75) return "Υπερβαρός";
        else return "Παχύσαρκος";
    }

    string GetEnduranceCondition(int value)
    {
        if (value >= 0 && value <= 25) return "Πολύ Χαμηλή";
        else if (value > 25 && value <= 50) return "Χαμηλή";
        else if (value > 50 && value <= 75) return "Υψηλή";
        else return "Άριστη";
    }

    public void Change()
    {
        muscle += 5;
        weight -= 5;
        endurance += 5;
        UpdateHealthInfo();
    }
}

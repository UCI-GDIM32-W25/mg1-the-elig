using UnityEngine;
using TMPro;

public class PlantCountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _plantedText;
    [SerializeField] private TMP_Text _remainingText;

    public void UpdateSeeds (int seedsPlanted, int seedsRemaining)
    {
        _plantedText.text = seedsPlanted.ToString();
        _remainingText.text = seedsRemaining.ToString();
    }
}
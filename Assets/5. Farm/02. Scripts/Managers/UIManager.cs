using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject fieldUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject inventoryUI;

    [SerializeField] private GameObject seedUI;
    
    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButtons;

    private void Awake()
    {
        seedButton.onClick.AddListener(OnSeedButton);
        harvestButton.onClick.AddListener(OnHarvestButton);

        for (int i = 0; i < plantButtons.Length; i++)
        {
            int j = i; // Closer 이슈
            plantButtons[i].onClick.AddListener(() => Farm.GameManager.Instance.field.SetPlant(j));
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void OnSeedButton()
    {
        Farm.GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
        seedUI.SetActive(true);
    }

    void OnHarvestButton()
    {
        Farm.GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
        seedUI.SetActive(false);
    }

    public void ActivateFieldUI(bool isActive)
    {
        fieldUI.SetActive(isActive);
    }
}

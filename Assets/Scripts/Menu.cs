using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button _disableMenu;
    [SerializeField]
    private Button _exet;

    void Start()
    {
        _disableMenu.onClick.AddListener(DisableMenu);
        _exet.onClick.AddListener(Exet);
    }

    private void DisableMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void Exet() => 
        Application.Quit();
}
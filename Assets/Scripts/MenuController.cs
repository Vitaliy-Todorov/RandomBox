using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameMenu;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if (_gameMenu.activeSelf)
            {
                Time.timeScale = 1;
                _gameMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                _gameMenu.SetActive(true);
            }
    }
}
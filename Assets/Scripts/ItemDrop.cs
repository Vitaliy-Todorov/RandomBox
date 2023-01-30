using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private KeyCode _buttonForUse;
    
    [SerializeField] 
    private float _startingChanceOfSuccess = 0.1f;
    [SerializeField] 
    private int _maximumSuccessInRow = 5;
    [SerializeField] 
    private int _maximumUnsuccessInRow = 10;
    [SerializeField] 
    private GameObject _successText;
    [SerializeField] 
    private GameObject _unsuccessText;
    [SerializeField] 
    private float _speedText = 2;
    [SerializeField] 
    private float _timeDisableText = 1;

    private int _successInRow;
    private int _unsuccessInRow;
    private IEnumerator _disableTextCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonForUse))
        {
            float chanceOfSuccess = _startingChanceOfSuccess 
                                    // Увеличиваем шанс успеха до 1 при серии неудач
                                    + (1 - _startingChanceOfSuccess) * _unsuccessInRow / _maximumUnsuccessInRow
                                    // Уменьшаем шанс успеха до 0 при серии упехов
                                    - _startingChanceOfSuccess * _successInRow / _maximumSuccessInRow;
            float randomNumber = Random.Range (0.0f, 1.0f);
            
            Debug.Log($"ChanceOfSuccess = {chanceOfSuccess}");
            if (randomNumber < chanceOfSuccess)
            {
                CreateText(_successText);

                Debug.Log("Successful");
                _successInRow++;
                _unsuccessInRow = 0;
            }
            else
            {
                CreateText(_unsuccessText);

                Debug.Log("Unsuccessful");
                _unsuccessInRow++;
                _successInRow = 0;
            }
        }
    }

    private void CreateText(GameObject textPrefab)
    {
        GameObject text = Instantiate(textPrefab, textPrefab.transform.parent);
        text.AddComponent<DisableText>()
            .Construct(_speedText, _timeDisableText);
        text.SetActive(true);
    }
}
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Список всех кубов на сцене
    public List<GameObject> cubes = new();

    // Индекс выигрышного куба
    private int winCubeIndex;

    // Текстовый объект для отображения "YOU WIN"
    public GameObject winText;

    void Start()
    {
        if (winText != null)
            winText.SetActive(false);

        // Генерация случайного индекса выигрышного куба
        if (cubes.Count > 0)
            winCubeIndex = Random.Range(0, cubes.Count);
    }

    // Метод для обработки нажатия кнопки
    public void OnButtonPressed(int index)
    {
        // Включение гравитации для всех кубов, кроме выйгрышного
        for (int i = 0; i < cubes.Count; i++)
        {
            Rigidbody rb = cubes[i].GetComponent<Rigidbody>();
            if (i != winCubeIndex)
                rb.useGravity = true;
        }

        // Проверка, угадал ли пользователь
        winText.SetActive(true);
        if (index == winCubeIndex)
        {
            winText.GetComponent<TMP_Text>().text = "You Win";
        }
        else
        {
            winText.GetComponent<TMP_Text>().text = "You Lose";
        }
    }

    // Методы для каждой кнопки
    public void OnButton1Pressed()
    {
        OnButtonPressed(0);
    }

    public void OnButton2Pressed()
    {
        OnButtonPressed(1);
    }

    public void OnButton3Pressed()
    {
        OnButtonPressed(2);
    }
}
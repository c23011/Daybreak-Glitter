using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    Button StartButton;
    public Button OptionButton;
    ColorBlock ButtonColor;
    Color color = Color.white;

    bool ButtonSW;
    bool TimeSW;

    void Update()
    {
        if (ButtonSW == true)
        {
            if (color.a >= 1.0f)
            {
                TimeSW = true;
            }

            if (color.a <= 0.5f)
            {
                TimeSW = false;
            }

            if (TimeSW == true)
            {
                color.a -= Time.deltaTime * 10;
                ButtonColor.disabledColor = color;
                StartButton.colors = ButtonColor;
            }

            if (TimeSW == false)
            {
                color.a += Time.deltaTime * 10;
                ButtonColor.disabledColor = color;
                StartButton.colors = ButtonColor;
            }

            Debug.Log(ButtonColor.disabledColor);
        }
    }
    public void OnButtonDown()
    {
        StartButton = this.gameObject.GetComponent<Button>();
        ButtonColor = StartButton.colors;
        ButtonSW = true;
        StartButton.interactable = false;
        OptionButton.interactable = false;

        Invoke("SceneChange", 3.0f);
    }

    void SceneChange()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}

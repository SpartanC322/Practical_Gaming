using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelectUI : MonoBehaviour
{
    public CanvasGroup selectClassUI;
    public Button normalClassBtn;
    public Button rangeClassBtn;
    public Button heavyClassbtn;

    Game_Manager myGameManager;

    // Start is called before the first frame update
    void Start()
    {
        selectClassUI.alpha = 0f;

        myGameManager = FindObjectOfType<Game_Manager>();

        normalClassBtn.onClick.AddListener(normalBtnClicked);
        rangeClassBtn.onClick.AddListener(rangeBtnClicked);
        heavyClassbtn.onClick.AddListener(heavyBtnClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showUI()
    {
        selectClassUI.alpha = 1f;
    }

    public void hideUI()
    {
        selectClassUI.alpha = 0f;
    }

    public void normalBtnClicked()
    {
        myGameManager.choseNormalClass();

        hideUI();
    }

    public void rangeBtnClicked()
    {
        myGameManager.choseRangeClass();

        hideUI();
    }

    public void heavyBtnClicked()
    {
        myGameManager.choseHeavyClass();

        hideUI();
    }
}

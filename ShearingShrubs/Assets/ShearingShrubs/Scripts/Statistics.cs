using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void UpdateNumBushes();

public class Statistics : MonoBehaviour
{
    [SerializeField] private Chainsaw chainsaw;
    [SerializeField] private Text numberofbushes_UI;

    private Animator numberofbushes_anim;
    private int numberofbushes = 28;

    void Start()
    {
        chainsaw.Updatenumberofbushes += UpdateNumberofBushesLeft;
        numberofbushes_anim = numberofbushes_UI.GetComponent<Animator>();
    }

    private void UpdateNumberofBushesLeft()
    {
        numberofbushes--;
        numberofbushes_UI.text = numberofbushes.ToString() + "/28";
        numberofbushes_anim.Play("UpdateNumber_anim", -1, 0);
        if (numberofbushes == 0)
        {
            EndGame.Instance.ShowEndGameScreen();
        }
    }
}

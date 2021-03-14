using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField]
    private int initialBalance = 100;

    [SerializeField]
    private int currentBalance;

    [SerializeField]
    private TextMeshProUGUI goldText;

    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    }

    public void Deposit(int rewardPoints)
    {
        currentBalance += Mathf.Abs(rewardPoints);
        UpdateGold();
    }

    public void Withdraw(int stolenPoints)
    {
        currentBalance -= Mathf.Abs(stolenPoints);
        UpdateGold();
        if (currentBalance < 0)
        {
            ReloadLevel();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBalance = initialBalance;
        UpdateGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReloadLevel()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex);
    }

    void UpdateGold()
    {
        goldText.text = "Gold : " + currentBalance;
    }

}

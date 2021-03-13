using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField]
    private int initialBalance = 100;

    [SerializeField]
    private int currentBalance;

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
    }

    public void Withdraw(int stolenPoints)
    {
        currentBalance -= Mathf.Abs(stolenPoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBalance = initialBalance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

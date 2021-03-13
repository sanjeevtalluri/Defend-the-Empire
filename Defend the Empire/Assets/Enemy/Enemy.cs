using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int rewardPoints = 25;
    [SerializeField]
    private int penaltyPoints = 10;

    private Bank bank;

    public void RewardGold()
    {
        bank.Deposit(rewardPoints);
    }

    public void StealGold()
    {
        bank.Withdraw(penaltyPoints);
    }
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

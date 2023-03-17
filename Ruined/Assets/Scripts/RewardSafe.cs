using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSafe : MonoBehaviour
{
    public GameObject RewardsWindow;
    // Start is called before the first frame update
    public void OnButtonRewardCard()
    {
        RewardsWindow.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

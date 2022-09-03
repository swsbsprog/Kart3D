using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    private void Awake() => instance = this;

    public Text countText;
    public int remainTime = 3;
    public bool isGameStart = false;
    public KartMover kartMover;
    IEnumerator Start()
    {
        kartMover.enabled = false;
        var wait = new WaitForSeconds(1);
        
        while(remainTime > 0)
        {
            countText.text = remainTime.ToString();
            remainTime--;
            yield return wait;
        }
        countText.text = "Start!";
        isGameStart = true;

        yield return wait;
        countText.gameObject.SetActive(false);

        kartMover.OnStart();
    }
}

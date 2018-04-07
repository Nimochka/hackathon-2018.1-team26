using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PickController : MonoBehaviour
{
    public SelectPlayer BossSelect;
    public SelectPlayer TankSelect;
    public SelectPlayer HunterSelect;
    public SelectPlayer SupportSelect;

    public Text CountdownLabel;

    private bool countdown;
    private float timer;


    void Start()
    {
        SocketController.OnGetPick += GetPick;
        SocketController.OnGameStarted += BeginCountdown;
        SocketController.RequestGetPick();
    }


    private void BeginCountdown()
    {
        countdown = true;
        timer = 3;
        CountdownLabel.gameObject.SetActive(true);
    }


    void Update()
    {
        if (countdown)
        {
            timer -= Time.deltaTime;
            CountdownLabel.text = string.Format("{0:#}", timer);
            if (timer <= 0)
                SceneManager.LoadScene("OnlineTest");
        }
    }


    private void GetPick(Pick pick)
    {
        SocketController.CurrentPick = pick;
        BossSelect.SetSelected(pick.Boss);
        TankSelect.SetSelected(pick.Tank);
        HunterSelect.SetSelected(pick.Hunter);
        SupportSelect.SetSelected(pick.Support);
    }

}

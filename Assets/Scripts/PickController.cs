using UI;
using UnityEngine;


public class PickController : MonoBehaviour
{
    public SelectPlayer BossSelect;
    public SelectPlayer TankSelect;
    public SelectPlayer HunterSelect;
    public SelectPlayer SupportSelect;


    void Start()
    {
        SocketController.OnGetPick += GetPick;
        SocketController.RequestGetPick();
    }


    private void GetPick(Pick pick)
    {
        BossSelect.SetSelected(pick.Boss != "");
        TankSelect.SetSelected(pick.Tank != "");
        HunterSelect.SetSelected(pick.Hunter != "");
        SupportSelect.SetSelected(pick.Support != "");
    }

}

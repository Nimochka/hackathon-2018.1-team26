using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ConnectButton : MonoBehaviour
    {
        public InputField NetAddressField;

        private bool loadNextScene;


        void Start()
        {
            SocketController.OnPlayerConnectSuccess += () =>
            {
                loadNextScene = true;
            };
            SocketController.OnPlayerConnectFail += SocketController.Close;
        }


        void Update()
        {
            if (loadNextScene)
                SceneManager.LoadScene("GameLobby");
        }


        public void ConnectToServer()
        {
            SocketController.Connect(NetAddressField.text);
        }
    }
}
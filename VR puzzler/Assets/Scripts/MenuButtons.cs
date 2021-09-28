using UnityEngine;
using System.Collections;
using Valve.VR;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class MenuButtons : MonoBehaviour
    {
        public void LoadLevels(Hand hand)
        {
            SceneManager.LoadScene(1);
        }
    }
}

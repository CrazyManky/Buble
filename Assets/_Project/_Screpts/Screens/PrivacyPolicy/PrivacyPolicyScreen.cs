using Project.Screpts.Screens;
using UnityEngine;

namespace _Project._Screpts.Screens.PrivacyPolicy
{
    public class PrivacyPolicyScreen : BaseScreen
    {
        public void AcceptPolicy()
        {
            AudioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}
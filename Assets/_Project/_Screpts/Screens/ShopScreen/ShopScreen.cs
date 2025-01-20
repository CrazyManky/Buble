namespace Project.Screpts.Screens.ShopScreen
{
    public class ShopScreen : BaseScreen
    {
        public void CloseScreen()
        {
            AudioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}
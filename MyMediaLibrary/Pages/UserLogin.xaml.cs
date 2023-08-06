namespace MyMediaLibrary.Pages;

public partial class UserLogin : ContentPage
{
	public UserLogin()
	{
		InitializeComponent();
	}

    private async void OnHomePage(System.Object sender, System.EventArgs e)
    {
	
        string userName = NameEntry.Text;

        if (userName != null)
        {
            HomePage homePage = new HomePage(userName);

            await Navigation.PushAsync(homePage);

        }
        



    }

}

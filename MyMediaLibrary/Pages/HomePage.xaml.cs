namespace MyMediaLibrary.Pages;

public partial class HomePage : ContentPage
{
	//establishing data
	MediaLibrary _mediaLibrary;


	//onproperty change
	public MediaLibrary MediaLibrary
	{
		get { return _mediaLibrary; }
		set
		{
			if (_mediaLibrary == value) { return; }
			_mediaLibrary = value;
			OnPropertyChanged();
		}
	}


    string _name;

    public HomePage(string userName)
    {
        InitializeComponent();
        _name = userName;

        UserLabel.Text = $"Welcome! {_name}";

    }

}
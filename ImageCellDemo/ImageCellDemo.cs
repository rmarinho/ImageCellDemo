using Xamarin.Forms;
using System.Linq;

namespace ImageCellDemo
{
	public class App : Application
	{
		public App ()
		{
			var imageCelltemplate = new DataTemplate (typeof (CustomImageCell));
			var viewCelltemplate = new DataTemplate (typeof (CustomViewCell));

			var listView = new ListView {
				ItemsSource = Enumerable.Range (0, 4000).Select (i => new ImageCellTest {
					Text = "Text " + i,
					TextColor = i % 2 == 0 ? Color.Red : Color.Blue,
					Detail = "Detail " + i,
					DetailColor = i % 2 == 0 ? Color.Red : Color.Blue,
					Image = "http://blog.xamarin.com/wp-content/uploads/2015/03/RDXWoY7W_400x400.png"
				}),
				ItemTemplate = viewCelltemplate
			};

			MainPage = new ContentPage { Content = listView };

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}

	public class CustomImageCell : ImageCell
	{
		public CustomImageCell ()
		{
			SetBinding (ImageCell.TextProperty, new Binding ("Text"));
			SetBinding (ImageCell.TextColorProperty, new Binding ("TextColor"));
			SetBinding (ImageCell.DetailProperty, new Binding ("Detail"));
			SetBinding (ImageCell.DetailColorProperty, new Binding ("DetailColor"));
			SetBinding (ImageCell.ImageSourceProperty, new Binding ("Image"));
		}
	}

	public class CustomViewCell : ViewCell
	{
		public CustomViewCell ()
		{
			var lbl = new Label();
			var img = new Image();
			lbl.SetBinding (Label.TextProperty, new Binding ("Text"));
			img.SetBinding (Image.SourceProperty, new Binding ("Image"));
			var root = new StackLayout { Orientation= StackOrientation.Horizontal,  Children = { img,lbl } };  
			View = root;
		}
	}

	public class ImageCellTest {
		public object Text { get; set; }
		public object TextColor { get; set; }
		public object Detail { get; set; }
		public object DetailColor { get; set; }
		public object Image { get; set; }
	}

}


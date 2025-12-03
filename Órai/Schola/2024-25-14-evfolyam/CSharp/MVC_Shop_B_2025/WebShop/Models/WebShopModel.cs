namespace WebShop.Models
{
	public class WebShopModel
	{
		public ShopIndexModel ShopIndex { get; set; }
		public LayoutModel Layout { get; set; }

		public WebShopModel()
		{
			Layout = new LayoutModel();
			ShopIndex = new ShopIndexModel();
		}
	}
}

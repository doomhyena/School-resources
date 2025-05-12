namespace WebShop_Core_2025_A.Models
{
	public class WebShopModel
	{
		public LayoutModel LayoutModel { get; set; }
		public ShopIndexModel ShopIndexModel { get; set; }

		public WebShopModel()
		{
			LayoutModel = new LayoutModel();
			ShopIndexModel = new ShopIndexModel();
		}
	}
}

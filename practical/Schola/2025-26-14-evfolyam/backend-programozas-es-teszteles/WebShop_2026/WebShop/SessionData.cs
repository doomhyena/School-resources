using System.Text.Json;

namespace WebShop
{
	public class SessionData
	{
		string loadedSession;
		public string SelectedCategory { get; set; }
		public int EmployeeID { get; set; }
		public DateTime? LoginTime { get; set; }
		public Dictionary<int, decimal> Cart { get; set; }

		public SessionData()
		{
			SelectedCategory=string.Empty;
			Cart = new Dictionary<int, decimal>();
		}

		public void Save(HttpContext ctx)
		{
			if (ctx != null)
			{
				ctx.Session.SetString("SessionData", JsonSerializer.Serialize(this));
			}
		}
		public bool Load(HttpContext ctx)
		{
			bool result = false;
			if (ctx != null)
			{
				try
				{
					ctx.Session.LoadAsync();
					if ((loadedSession = ctx.Session.GetString("SessionData")) != null)
					{
						SessionData temp = JsonSerializer.Deserialize<SessionData>(loadedSession);
						SelectedCategory = temp.SelectedCategory;
						Cart = temp.Cart;
						EmployeeID= temp.EmployeeID;
						LoginTime = temp.LoginTime;
						result = true;
					}

				}
				catch (Exception)
				{

					throw;
				}
			}
			return result;
		}
	}
}

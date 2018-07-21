using MaterialSkin;
using MaterialSkin.Controls;

namespace KraxbotOSS
{
	public abstract class Tools
	{
		public static void SetMaterialSkin(MaterialForm form)
		{
			// Material skin
			var skin = MaterialSkinManager.Instance;
			skin.AddFormToManage(form);
			skin.Theme = MaterialSkinManager.Themes.DARK;
			skin.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Blue200, TextShade.WHITE);
		}
	}
}
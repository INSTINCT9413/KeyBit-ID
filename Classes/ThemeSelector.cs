using KeyBit_ID.Properties;

namespace KeyBit_ID.Classes
{
    public class ThemeManager
    {

        public ThemeManager()
        {

        }

        // method that handles what theme to choose and save
        public string ThemeSelector(int themeIndex)
        {


            // if index 0 then set theme and save
            if (themeIndex == 0)
            {
                // set setting and save it
                Settings.Default.Theme = "Blue";
                Settings.Default.Save();
            }
            // if index 1 then set theme and save
            else if (themeIndex == 1)
            {
                // set setting and save it
                Settings.Default.Theme = "Red";
                Settings.Default.Save();
            }
            // if index 2 then set theme and save
            else if (themeIndex == 2)
            {
                // set setting and save it
                Settings.Default.Theme = "Green";
                Settings.Default.Save();
            }
            // clear
            return null;
        }


    }
}

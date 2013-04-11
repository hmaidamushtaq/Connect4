/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * author:      wieschoo
 * url:         http://www.wieschoo.com
 * copyright:   2013 by wieschoo
 * license:     http://www.wieschoo.com/license_agreement/
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
using connectfour.GameComponents;

namespace connectfour.Player
{
    interface IPlayer
    {
        int Play(Board CurrentGame);
        void SetStrength(int strength);
        void SetGUIMembers(System.Windows.Forms.ProgressBar T,System.Windows.Forms.TextBox L);
    }
}

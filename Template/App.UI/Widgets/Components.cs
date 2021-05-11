using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    class BackButton : ImageView
    {
        public BackButton()
        {
            this.Path("Images/Icons/ios-arrow-back.png").Size(24).Margin(horizontal: 15);
        }
    }
    class MainImage : ImageView { }
    class BoldText : TextView { }
    class Input : TextInput { }
    class MainLink : Link { }
    class PopupText : TextView { }
    class CollectionRow : Row { }

}

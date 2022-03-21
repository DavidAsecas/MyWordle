using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wordle
{
    public interface IContentSwitcher
    {
        void ChangeCurrentContent(ContentControl contentControl);
    }
}

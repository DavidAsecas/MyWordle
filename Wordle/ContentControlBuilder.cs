using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wordle.UI.View;

namespace Wordle.UI
{
    public static class ContentControlBuilder
    {
        public static ContentControl GetIntroContent()
        {
            return new IntroControl();
        }

        public static ContentControl GetWordleContent(string word)
        {
            return new WordleControl(word);
        }
    }
}

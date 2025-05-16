// Copyright (c) Corey Hayward. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Clipboard = System.Windows.Clipboard;

namespace Community.PowerToys.Run.Plugin.InputTyper
{
    internal sealed class Typer
    {
        private readonly char[] _specialCharacters = { '{', '}', '+', '^', '%', '~', '(', ')'  };

        public bool TypeEnter { get; set; } = true;

        public void Type(string str, int initTypeDelay = 2000, int interKeyDelay = 20)
        {
            Thread.Sleep(initTypeDelay);
            foreach (var c in str.ToCharArray())
            {
                // Some characters have special meaning and must be surrounded by '{}'
                // https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/sendkeys-statement
                if (_specialCharacters.Contains(c))
                {
                    SendKeys.SendWait("{" + c + "}");
                }
                else
                {
                    SendKeys.SendWait(c.ToString());
                }
               
                Thread.Sleep(interKeyDelay);
            }
        }

        internal void TypeClipboard(int beginTypeDelay)
        {
            if (!Clipboard.ContainsText())
            {
                return;
            }

            var text = Clipboard.GetText();
            Type(text, beginTypeDelay);
        }
    }
}

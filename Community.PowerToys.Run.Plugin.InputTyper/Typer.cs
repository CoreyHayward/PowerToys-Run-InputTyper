// Copyright (c) Corey Hayward. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Community.PowerToys.Run.Plugin.InputTyper
{
    internal sealed class Typer
    {
        private readonly char[] _specialCharacters = { '{', '}', '+', '^', '%', '~', '(', ')'  };
        private const int INTERKEYDELAY = 20;

        public bool TypeEnter { get; set; } = true;

        public void Type(string str, int delay = 2000)
        {
            Thread.Sleep(delay);
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
               
                Thread.Sleep(INTERKEYDELAY);
            }
        }
    }
}

// Copyright (c) Corey Hayward. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ManagedCommon;
using Microsoft.PowerToys.Settings.UI.Library;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.InputTyper
{
    public class Main : IPlugin, ISettingProvider
    {
        private Typer _typer = new Typer();
        private PluginInitContext _context;
        private string _icon_path;
        private int _beginTypeDelay;

        public string Name => "InputTyper";

        public string Description => "Types the input text.";

        public static string PluginID => "10733f2de88e4348aa7a340d25ebcca2";

        public IEnumerable<PluginAdditionalOption> AdditionalOptions => new List<PluginAdditionalOption>()
        {
            new PluginAdditionalOption()
            {
                Key = "BeginTypeDelay",
                DisplayLabel = "Begin Type Delay (ms)",
                DisplayDescription = "Sets how long in milliseconds to wait before typing begins.",
                NumberValue = 200,
                PluginOptionType = PluginAdditionalOption.AdditionalOptionType.Numberbox,
            },
        };

        public void Init(PluginInitContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
            _context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(_context.API.GetCurrentTheme());
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            if (!string.IsNullOrWhiteSpace(query?.Search))
            {
                var text = query.Search.Trim();
                results.Add(new Result
                {
                    Title = $"Type: {text}",
                    IcoPath = _icon_path,
                    Action = c =>
                    {
                        Task.Run(() => _typer!.Type(text, _beginTypeDelay));
                        return true;
                    },
                });
            }

            return results;
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }

        private void UpdateIconPath(Theme theme)
        {
            if (theme == Theme.Light || theme == Theme.HighContrastWhite)
            {
                _icon_path = "Images/InputTyper.light.png";
            }
            else
            {
                _icon_path = "Images/InputTyper.dark.png";
            }
        }

        public System.Windows.Controls.Control CreateSettingPanel()
        {
            throw new NotImplementedException();
        }

        public void UpdateSettings(PowerLauncherPluginSettings settings)
        {
            if (settings?.AdditionalOptions is null)
            {
                return;
            }

            var typeDelay = settings.AdditionalOptions.FirstOrDefault(x => x.Key == "BeginTypeDelay");
            _beginTypeDelay = (int)(typeDelay?.NumberValue ?? 200);
        }
    }
}

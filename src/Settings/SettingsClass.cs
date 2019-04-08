using System.ComponentModel.DataAnnotations;

namespace Settings
{
    public class SettingsClass
    {
        public string SecretPhrase { get; set; }
        public string PublicValue { get; set; }
    }
}
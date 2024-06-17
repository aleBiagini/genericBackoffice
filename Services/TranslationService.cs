using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericBackoffice.Services
{
    public class TranslationService
    {

        private static Dictionary<string, string> italianTranslations = new Dictionary<string, string>
        {
            {"Passwords must have at least one non alphanumeric character.", "Le password devono contenere almeno un carattere non alfanumerico."},
            {"Passwords must have at least one digit ('0'-'9').", "Le password devono contenere almeno una cifra ('0'-'9')."},
            {"Passwords must have at least one uppercase ('A'-'Z').", "Le password devono contenere almeno una lettera maiuscola ('A'-'Z')." },
            {"The", "Il" },
            {"field", "campo" },
            // Aggiungi altre traduzioni necessarie qui
        };

        public string TranslateTextAsync(string text, string targetLanguage)
        {
            if (targetLanguage.ToLower() != "it")
            {
                return text; // Non tradurre se non è l'italiano
            }

            // Cerca la traduzione nel dizionario
            if (italianTranslations.TryGetValue(text, out string translatedText))
            {
                return translatedText;
            }

            // Se la traduzione non è disponibile, restituisci il testo originale
            return text;
        }

        public string? GetTranslatedMessageAsync(IEnumerable<IdentityError>? identityErrors)
        {
            if (identityErrors == null) return null;
            var descriptions = identityErrors.Select(error => error.Description);
            var translatedDescriptions = new List<string>();

            foreach (var description in descriptions)
            {
                var translatedDescription = TranslateTextAsync(description, "it");
                translatedDescriptions.Add(translatedDescription);
            }

            return $"{string.Join(" ", translatedDescriptions)}";
        }
    }

    // Utilizzo nel contesto della tua proprietà Message

}

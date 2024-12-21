namespace CerbDesk.API.Models.Surveys
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; } // Tytuł ankiety np. "Ocena obsługi"
        public string? Description { get; set; } // Opcjonalny opis
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data utworzenia

        public ICollection<SurveyResponse> SurveyResponses { get; set; } // Odpowiedzi na ankietę

    }
}

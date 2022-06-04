namespace TKTrialBot.Commands
{
    public class SubQuestion
    {
        public string Key;
        public string Question;
        public bool Processed;

        public SubQuestion(string key, string question)
        {
            Key = key;
            Question = question;
            Processed = false;
        }
    }
}

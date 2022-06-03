namespace TKTrialBot.Commands
{
    public abstract class MultiQuestionCommand : AbstractCommand
    {
        protected List<SubQuestion> subQuestions;        
        public abstract void InitCommand();
        public List<SubQuestion> Subquestions { get { return subQuestions; } }
    }
}

using System;

namespace DesignPatterns
{
    internal class ChainOfResposibility
    {
        private readonly ParticipantHistory _participantHistory = new ParticipantHistory();
        private readonly ParticipantMusic _participantMusic = new ParticipantMusic();

        public ChainOfResposibility()
        {
            _participantHistory.SetNextParticipant(_participantMusic);
        }

        public void AnswerQuiz(Question question)
        {
            _participantHistory.AnswerTheQuestion(question);
        }
    }

    internal abstract class Participant
    {
        protected Participant Nextparticipant;

        public void SetNextParticipant(Participant nextParticipant)
        {
            Nextparticipant = nextParticipant;
        }

        public abstract void AnswerTheQuestion(Question question);
    }

    internal class Question
    {
        public string IsRelatedTo { get; set; }
        public string Content { get; set; }
    }

    internal class QuizTopics
    {
        public const string History = "History";
        public const string Music = "Music";
    }


    internal class ParticipantHistory : Participant
    {
        public string HasKnowledgeIn = QuizTopics.History;

        public override void AnswerTheQuestion(Question question)
        {
            if (HasKnowledgeIn == question.IsRelatedTo)
            {
                Console.WriteLine($"Answered to question {question.IsRelatedTo}");
            }
            else
            {
                Nextparticipant?.AnswerTheQuestion(question);
            }
        }
    }

    internal class ParticipantMusic : Participant
    {
        public string HasKnowledgeIn = QuizTopics.Music;

        public override void AnswerTheQuestion(Question question)
        {
            if (HasKnowledgeIn == question.IsRelatedTo)
            {
                Console.WriteLine($"Answered to question {question.IsRelatedTo}");
            }
            else
            {
                Nextparticipant?.AnswerTheQuestion(question);
            }
        }
    }

}

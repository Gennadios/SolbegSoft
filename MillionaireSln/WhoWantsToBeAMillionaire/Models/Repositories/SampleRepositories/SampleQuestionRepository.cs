using System.Linq;

namespace WhoWantsToBeAMillionaire.Models.Repositories
{
    public class SampleQuestionRepository : IQuestionRepository
    {
        public IQueryable<Question> Questions
        {
            get
            {
                return (new Question[]
                {
                    new Question {Id = 1, Content = "40-15 is a regular score in which sport?"},
                    new Question {Id = 2, Content = "A calf is the young of which animal?"},
                    new Question {Id = 3, Content = "A computer-game hero is Sonic the what?"},
                    new Question {Id = 4, Content = "A famous Paris landmark is the Eiffel what?"},
                    new Question {Id = 5, Content = "A Kiwi is a native of which country?"},
                    new Question {Id = 6, Content = "A series based on The Karate Kid Cobra Kai streams on what service?"},
                    new Question {Id = 7, Content = "An Egyptian sphinx has the head of a human and the body of which animal?"},
                    new Question {Id = 8, Content = "Complete the name of the well-known rock group, Radio...?"},
                    new Question {Id = 9, Content = "Complete the title of the US TV sci-fi series, 'Battlestar ...'?"},
                    new Question {Id = 10, Content = "What is the name of the Wookiees' homeland?"},
                    new Question {Id = 11, Content = "How old was Elvis Presley when he died in 1977?"},
                    new Question {Id = 12, Content = "In computers, SGML stands for 'Standard Generalised what Language'?"},
                    new Question {Id = 13, Content = "In Einstein's formula E=mc², what does the 'c' represent?"},
                    new Question {Id = 14, Content = "In the context of Internet domains, if the UK is .uk and France is .fr, which country is .cn?"},
                    new Question {Id = 15, Content = "Much of the area of which country corresponds with that of ancient Mesopotamia?"},
                    new Question {Id = 16, Content = "Of all the 50 US state capitals, which is the only one to share its name with its state?"},
                    new Question {Id = 17, Content = "Peter Gabriel was a lead vocalist for which group?"},
                    new Question {Id = 18, Content = "Robin Williams won an Oscar for his role in which film?"},
                    new Question {Id = 19, Content = "Softball is a variation on which game?"},
                    new Question {Id = 20, Content = "The author Lewis Carroll was known for writing about whose Adventure in Wonderland?"}
                }).AsQueryable<Question>();
            }
        }
    }
}

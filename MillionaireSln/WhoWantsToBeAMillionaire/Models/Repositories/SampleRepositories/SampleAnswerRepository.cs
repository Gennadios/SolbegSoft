using System.Linq;

namespace WhoWantsToBeAMillionaire.Models.Repositories.SampleRepositories
{
    public class SampleAnswerRepository : IAnswerRepository
    {
        public IQueryable<Answer> Answers
        {
            get
            {
                return (new Answer[]
                {
                    new Answer {QuestionId = 1, Content = "Basketball", IsCorrect = false},
                    new Answer {QuestionId = 1, Content = "Football", IsCorrect = false},
                    new Answer {QuestionId = 1, Content = "Golf", IsCorrect = false},
                    new Answer {QuestionId = 1, Content = "Tennis", IsCorrect = true},

                    new Answer {QuestionId = 2, Content = "Cat", IsCorrect = false},
                    new Answer {QuestionId = 2, Content = "Cow", IsCorrect = true},
                    new Answer {QuestionId = 2, Content = "Goat", IsCorrect = false},
                    new Answer {QuestionId = 2, Content = "Gorilla", IsCorrect = false},

                    new Answer {QuestionId = 3, Content = "Aardvark", IsCorrect = false},
                    new Answer {QuestionId = 3, Content = "Polecat", IsCorrect = false},
                    new Answer {QuestionId = 3, Content = "Hedgehog", IsCorrect = true},
                    new Answer {QuestionId = 3, Content = "Muskrat", IsCorrect = false},

                    new Answer {QuestionId = 4, Content = "Bridge", IsCorrect = false},
                    new Answer {QuestionId = 4, Content = "Tower", IsCorrect = true},
                    new Answer {QuestionId = 4, Content = "Square", IsCorrect = false},
                    new Answer {QuestionId = 4, Content = "Palace", IsCorrect = false},

                    new Answer {QuestionId = 5, Content = "Australia", IsCorrect = false},
                    new Answer {QuestionId = 5, Content = "South Africa", IsCorrect = false},
                    new Answer {QuestionId = 5, Content = "New Zealand", IsCorrect = true},
                    new Answer {QuestionId = 5, Content = "Canada", IsCorrect = false},

                    new Answer {QuestionId = 6, Content = "Netflix", IsCorrect = false},
                    new Answer {QuestionId = 6, Content = "YouTube Premium", IsCorrect = true},
                    new Answer {QuestionId = 6, Content = "Hulu", IsCorrect = false},
                    new Answer {QuestionId = 6, Content = "Twitch", IsCorrect = false},

                    new Answer {QuestionId = 7, Content = "Dog", IsCorrect = false},
                    new Answer {QuestionId = 7, Content = "Elephant", IsCorrect = false},
                    new Answer {QuestionId = 7, Content = "Lion", IsCorrect = true},
                    new Answer {QuestionId = 7, Content = "Snake", IsCorrect = false},

                    new Answer {QuestionId = 8, Content = "Arm", IsCorrect = false},
                    new Answer {QuestionId = 8, Content = "Leg", IsCorrect = false},
                    new Answer {QuestionId = 8, Content = "Foot", IsCorrect = false},
                    new Answer {QuestionId = 8, Content = "Head", IsCorrect = true},

                    new Answer {QuestionId = 9, Content = "Galactica", IsCorrect = true},
                    new Answer {QuestionId = 9, Content = "Stellar", IsCorrect = false},
                    new Answer {QuestionId = 9, Content = "Cosmos", IsCorrect = false},
                    new Answer {QuestionId = 9, Content = "Nebular", IsCorrect = false},

                    new Answer {QuestionId = 10, Content = "Tatooine", IsCorrect = false},
                    new Answer {QuestionId = 10, Content = "Naboo", IsCorrect = false},
                    new Answer {QuestionId = 10, Content = "Kashyyyk", IsCorrect = true},
                    new Answer {QuestionId = 10, Content = "Dagobah", IsCorrect = false},

                    new Answer {QuestionId = 11, Content = "42", IsCorrect = true},
                    new Answer {QuestionId = 11, Content = "50", IsCorrect = false},
                    new Answer {QuestionId = 11, Content = "36", IsCorrect = false},
                    new Answer {QuestionId = 11, Content = "62", IsCorrect = false},

                    new Answer {QuestionId = 12, Content = "Matrix", IsCorrect = false},
                    new Answer {QuestionId = 12, Content = "Markup", IsCorrect = true},
                    new Answer {QuestionId = 12, Content = "Modulated", IsCorrect = false},
                    new Answer {QuestionId = 12, Content = "Multi-user", IsCorrect = false},

                    new Answer {QuestionId = 13, Content = "Universal constant", IsCorrect = false},
                    new Answer {QuestionId = 13, Content = "Total capacity", IsCorrect = false},
                    new Answer {QuestionId = 13, Content = "Speed of Light", IsCorrect = true},
                    new Answer {QuestionId = 13, Content = "Magnetic Density", IsCorrect = false},

                    new Answer {QuestionId = 14, Content = "Canada", IsCorrect = false},
                    new Answer {QuestionId = 14, Content = "Congo", IsCorrect = false},
                    new Answer {QuestionId = 14, Content = "Croatia", IsCorrect = false},
                    new Answer {QuestionId = 14, Content = "China", IsCorrect = true},

                    new Answer {QuestionId = 15, Content = "Iraq", IsCorrect = true},
                    new Answer {QuestionId = 15, Content = "Saudi Arabia", IsCorrect = false},
                    new Answer {QuestionId = 15, Content = "Iran", IsCorrect = false},
                    new Answer {QuestionId = 15, Content = "Egypt", IsCorrect = false},

                    new Answer {QuestionId = 16, Content = "Kansas City", IsCorrect = false},
                    new Answer {QuestionId = 16, Content = "Montana City", IsCorrect = false},
                    new Answer {QuestionId = 16, Content = "Oklahoma city", IsCorrect = true},
                    new Answer {QuestionId = 16, Content = "Wyoming City", IsCorrect = false},

                    new Answer {QuestionId = 17, Content = "Roxy Music", IsCorrect = false},
                    new Answer {QuestionId = 17, Content = "Queen", IsCorrect = false},
                    new Answer {QuestionId = 17, Content = "Genesis", IsCorrect = true},
                    new Answer {QuestionId = 17, Content = "King Crimson", IsCorrect = false},

                    new Answer {QuestionId = 18, Content = "Jumanji", IsCorrect = false},
                    new Answer {QuestionId = 18, Content = "Good Will Hunting", IsCorrect = true},
                    new Answer {QuestionId = 18, Content = "Dead Poets Society", IsCorrect = false},
                    new Answer {QuestionId = 18, Content = "Good Morning, Vietnam!", IsCorrect = false},

                    new Answer {QuestionId = 19, Content = "Tennis", IsCorrect = false},
                    new Answer {QuestionId = 19, Content = "Volleyball", IsCorrect = false},
                    new Answer {QuestionId = 19, Content = "Basketball", IsCorrect = false},
                    new Answer {QuestionId = 19, Content = "Baseball", IsCorrect = true},

                    new Answer {QuestionId = 20, Content = "Mr. Bean's", IsCorrect = false},
                    new Answer {QuestionId = 20, Content = "Sherlock Holmes'", IsCorrect = false},
                    new Answer {QuestionId = 20, Content = "Harry Potter's", IsCorrect = false},
                    new Answer {QuestionId = 20, Content = "Alice's", IsCorrect = true}
                }).AsQueryable<Answer>();
            }
        }
    }
}

using Moq;
using Xunit;
using System.Linq;
using WhoWantsToBeAMillionaire.Models.Services;
using WhoWantsToBeAMillionaire.Models.Repositories;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Tests
{
    public class GameServiceTests
    {
        private readonly Mock<IQuestionRepository> _questionRepoMock = new Mock<IQuestionRepository>();
        private readonly Mock<IAnswerRepository> _answerRepoMock = new Mock<IAnswerRepository>();

        [Fact]
        public void Can_Reset_Game()
        {
            // arrange
            _questionRepoMock.Setup(x => x.Questions).Returns((new Question[]
            {
                new Question {Id = 1, Content = "Q1"},
                new Question {Id = 2, Content = "Q2"},
                new Question {Id = 3, Content = "Q3"},
                new Question {Id = 4, Content = "Q4"},
                new Question {Id = 5, Content = "Q5"}
            }).AsQueryable<Question>());
            _answerRepoMock.Setup(x => x.Answers).Returns((new Answer[]
            {
                new Answer {QuestionId = 1, Content = "1A", IsCorrect = true},
                new Answer {QuestionId = 1, Content = "1B", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1C", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1D", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2A", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2B", IsCorrect = true},
                new Answer {QuestionId = 2, Content = "2C", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3C", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "3D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4D", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5A", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5D", IsCorrect = false}
            }).AsQueryable<Answer>);

            var firstGameService = new GameService(_questionRepoMock.Object, _answerRepoMock.Object);
            var secondGameService = new GameService(_questionRepoMock.Object, _answerRepoMock.Object);

            secondGameService.NumberOfQuestions = 3;
            secondGameService.CurrentQuestionNumber = 2;
            secondGameService.CurrentPrize = 100_000;
            secondGameService.GameLost = true;

            // act
            secondGameService.ResetGame();

            // assert
            Assert.Equal(firstGameService.NumberOfQuestions, secondGameService.NumberOfQuestions);
            Assert.Equal(firstGameService.CurrentQuestionNumber, secondGameService.CurrentQuestionNumber);
            Assert.Equal(firstGameService.GameQuestions, secondGameService.GameQuestions);
            Assert.Equal(firstGameService.CurrentPrize, secondGameService.CurrentPrize);
            Assert.Equal(firstGameService.FiftyFiftyUsed, secondGameService.FiftyFiftyUsed);
            Assert.Equal(firstGameService.GameLost, secondGameService.GameLost);
        }

        [Fact]
        public void Can_Pick_Two_Wrong_Answers_With_ManageFiftyFifty()
        {
            // arrange
            _questionRepoMock.Setup(x => x.Questions).Returns((new Question[]
            {
                new Question {Id = 1, Content = "Q1"},
                new Question {Id = 2, Content = "Q2"},
                new Question {Id = 3, Content = "Q3"},
                new Question {Id = 4, Content = "Q4"},
                new Question {Id = 5, Content = "Q5"}
            }).AsQueryable<Question>());
            _answerRepoMock.Setup(x => x.Answers).Returns((new Answer[]
            {
                new Answer {QuestionId = 1, Content = "1A", IsCorrect = true},
                new Answer {QuestionId = 1, Content = "1B", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1C", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1D", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2A", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2B", IsCorrect = true},
                new Answer {QuestionId = 2, Content = "2C", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3C", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "3D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4D", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5A", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5D", IsCorrect = false}
            }).AsQueryable<Answer>);

            var testService = new GameService(_questionRepoMock.Object, _answerRepoMock.Object);
            testService.NumberOfQuestions = 3;
            // act
            testService.ManageFiftyFifty();

            var wrongAnswerCount = testService.CurrentAnswers.Where(a => a != null && a.IsCorrect == false).Count();
            var correctAnswerCount = testService.CurrentAnswers.Where(a => a != null && a.IsCorrect == true).Count();
            // assert
            Assert.Equal(1, wrongAnswerCount);
            Assert.Equal(1, correctAnswerCount);
        }

        [Fact]
        public void Can_Remove_First_Question_From_GameQuestions()
        {
            // arrange
            _questionRepoMock.Setup(x => x.Questions).Returns((new Question[]
            {
                new Question {Id = 1, Content = "Q1"},
                new Question {Id = 2, Content = "Q2"},
                new Question {Id = 3, Content = "Q3"},
                new Question {Id = 4, Content = "Q4"},
                new Question {Id = 5, Content = "Q5"}
            }).AsQueryable<Question>());
            _answerRepoMock.Setup(x => x.Answers).Returns((new Answer[]
            {
                new Answer {QuestionId = 1, Content = "1A", IsCorrect = true},
                new Answer {QuestionId = 1, Content = "1B", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1C", IsCorrect = false},
                new Answer {QuestionId = 1, Content = "1D", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2A", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2B", IsCorrect = true},
                new Answer {QuestionId = 2, Content = "2C", IsCorrect = false},
                new Answer {QuestionId = 2, Content = "2D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "3C", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "3D", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4A", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "4D", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5A", IsCorrect = true},
                new Answer {QuestionId = 3, Content = "5B", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5C", IsCorrect = false},
                new Answer {QuestionId = 3, Content = "5D", IsCorrect = false}
            }).AsQueryable<Answer>);

            var testService = new GameService(_questionRepoMock.Object, _answerRepoMock.Object);
            testService.NumberOfQuestions = 4;

            // act
            testService.RemoveFirstQuestion();

            // assert
            Assert.Equal(3, testService.GameQuestions.Count);
        }
    }
}

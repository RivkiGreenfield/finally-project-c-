using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pl_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PointTestController : ControllerBase
    {
        IBl _bl;

        public PointTestController(IBl blAnswersService)
        {
            _bl = blAnswersService;
        }


        [HttpPost]
        public async Task<bool> AddTest([FromBody] CompareTo[] value, [FromQuery]string id)
        {

            List<BlAnswers> Answers =await _bl.Answers.GetAll();
            List<BlQuestions> Questions =await _bl.Questions.GetAll();
            int AllScore = 0;
            BlTest newTest;
            newTest = new()
            {
                CustId = id, 
                Grade = ""
            };
            await _bl.Test.Create(newTest);
            for (int i = 0; i < value.Length;i++)
            {
                if (Questions.Find(x => x.Id == value[i].id && x.IsAmerican) != null)
                {
                    int Score = 0;
                    BlPointsTest newPointTest;
                    BlAnswers a = Answers.Find(x => x.QuestionId.Equals(value[i].id) && x.Id.ToString() == value[i].text && x.IsCorrect);
                    if (a != null)
                    {
                        Score = Questions.Find(x => x.Id == value[i].id).Score;
                    }


                    List<BlPointsTest> PointTest = _bl.PointsTest.GetAll().Result;
                    BlPointsTest q = PointTest.Find(x => x.PropertyId == Questions.Find(x => x.Id == value[i].id).PropertyId);
                    BlTest tes = _bl.Test.GetAll().Result.Find(x => x.CustId == newTest.CustId);
                    if (q != null)
                    {
                        newPointTest = new()
                        {
                            Id = q.Id,
                            TestId = tes.TestId,
                            PropertyId = q.PropertyId,
                            GradeProperty = Score + q.GradeProperty

                        };
                        await _bl.PointsTest.Update(newPointTest);
                    }
                    else
                    {
                        newPointTest = new()
                        {
                            TestId = tes.TestId,
                            PropertyId = Questions.Find(x => x.Id == value[i].id).PropertyId,
                            GradeProperty = Score

                        };
                        await _bl.PointsTest.Create(newPointTest);
                    }

                }
                else
                {
                    //פענוח תשובה לא אמריקאית
                }
            }
            return true;

        }
    }

}


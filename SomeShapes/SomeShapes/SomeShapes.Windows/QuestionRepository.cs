using SomeShapes.Letters;
using SomeShapes.Positions;
using SomeShapes.Shapes;
using System;

namespace SomeShapes
{
   public class QuestionRepository
   {
      private IQuestionGroup[] _questionGroups = GetQuestionGroups();

      public QuestionSlate GetNewQuestion()
      {
         var questionGroup = SelectRandomQuestionGroup();

         return questionGroup.GetQuestion();
      }

      private static IQuestionGroup[] GetQuestionGroups()
      {
         return new IQuestionGroup[]
         {
            new ShapeQuestionGroup(),
            new LetterQuestionGroup(),
            new PositionQuestionGroup()
         };
      }

      private IQuestionGroup SelectRandomQuestionGroup()
      {
         int index = Rng.Random.Next( _questionGroups.Length );

         return _questionGroups[index];
      }
   }
}

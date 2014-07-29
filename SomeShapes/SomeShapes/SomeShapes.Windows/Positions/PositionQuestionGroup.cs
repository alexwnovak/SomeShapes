using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SomeShapes.Positions
{
   public class PositionQuestionGroup : IQuestionGroup
   {
      public QuestionSlate GetQuestion()
      {
         var questionSlate = new QuestionSlate();

         var positions = new[]
         {
            PositionType.Left,
            PositionType.Middle,
            PositionType.Right
         };

         var randomColor = GetRandomColor();

         questionSlate.Option1 = GetPositionGrid( randomColor );
         questionSlate.Option2 = GetPositionGrid( randomColor );
         questionSlate.Option3 = GetPositionGrid( randomColor );

         questionSlate.CorrectAnswer = Rng.Random.Next( 3 );

         var correctPosition = positions[questionSlate.CorrectAnswer];

         if ( correctPosition == PositionType.Middle )
         {
            questionSlate.SpeechString = "Touch the square in the middle";
         }
         else
         {
            questionSlate.SpeechString = string.Format( "Touch the square on the {0}", correctPosition);
         }

         return questionSlate;
      }
      
      private UIElement GetPositionGrid( Color color )
      {
         var grid = new Grid();

         grid.Background = new SolidColorBrush( color );

         return grid;
      }

      private Color GetRandomColor()
      {
         var colors = new[]
         {
            Colors.Black,
            Colors.Red,
            Colors.Orange,
            Colors.Yellow,
            Colors.Green,
            Colors.Blue,
            Colors.Purple,
            Colors.Pink,
         };

         int index = Rng.Random.Next( colors.Length );

         return colors[index];

      }
   }
}

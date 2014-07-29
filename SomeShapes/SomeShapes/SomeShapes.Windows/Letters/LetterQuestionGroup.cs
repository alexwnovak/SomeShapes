using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SomeShapes.Letters
{
   public class LetterQuestionGroup : IQuestionGroup
   {
      public QuestionSlate GetQuestion()
      {
         var questionSlate = new QuestionSlate();

         var letters = GetNextLetters();

         questionSlate.Option1 = GetLetterGrid( letters[0] );
         questionSlate.Option2 = GetLetterGrid( letters[1] );
         questionSlate.Option3 = GetLetterGrid( letters[2] );

         questionSlate.CorrectAnswer = Rng.Random.Next( 3 );

         char correctLetter = letters[questionSlate.CorrectAnswer];

         questionSlate.SpeechString = string.Format( "Touch the letter {0}", correctLetter );

         return questionSlate;
      }

      private UIElement GetLetterGrid( char letter )
      {
         var grid = new Grid();
         grid.Background = new SolidColorBrush( Color.FromArgb( 255, 230, 230, 230 ) );  

         var textBlock = new TextBlock();
         textBlock.Foreground = new SolidColorBrush( Colors.Black );
         textBlock.FontSize = 112;
         textBlock.Text = letter.ToString().ToUpper();
         textBlock.HorizontalAlignment = HorizontalAlignment.Center;
         textBlock.VerticalAlignment = VerticalAlignment.Center;

         grid.Children.Add( textBlock );

         return grid;
      }

      public char[] GetNextLetters()
      {
         var letters = new List<char>();

         for ( int index = 0; index < 3; index++ )
         {
            char randomLetter;

            do
            {
               randomLetter = (char) Rng.Random.Next( 97, 123 );
            }
            while ( letters.Contains( randomLetter ) );

            letters.Add( randomLetter );
         }

         return letters.ToArray();
      }
   }
}

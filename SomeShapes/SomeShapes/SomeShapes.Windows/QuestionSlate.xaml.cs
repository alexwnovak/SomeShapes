using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SomeShapes
{
   public sealed partial class QuestionSlate : UserControl
   {
      public event RoutedEventHandler AnsweredCorrectly = null;

      public event RoutedEventHandler AnsweredIncorrectly = null;

      public int CorrectAnswer
      {
         get;
         set;
      }

      public string SpeechString
      {
         get;
         set;
      }

      public UIElement Option1
      {
         set
         {
            Slot1.Children.Clear();
            Slot1.Children.Add( value );
         }
      }

      public UIElement Option2
      {
         set
         {
            Slot2.Children.Clear();
            Slot2.Children.Add( value );
         }
      }

      public UIElement Option3
      {
         set
         {
            Slot3.Children.Clear();
            Slot3.Children.Add( value );
         }
      }

      public QuestionSlate()
      {
         InitializeComponent();
      }

      private void OnCorrectAnswer()
      {
         var handler = AnsweredCorrectly;

         if ( handler != null )
         {
            AnsweredCorrectly( this, new RoutedEventArgs() );
         }
      }

      private void OnIncorrectAnswer()
      {
         var handler = AnsweredIncorrectly;

         if ( handler != null )
         {
            AnsweredIncorrectly( this, new RoutedEventArgs() );
         }
      }

      private void Slot1_OnTapped( object sender, TappedRoutedEventArgs e )
      {
         if ( CorrectAnswer == 0 )
         {
            OnCorrectAnswer();
         }
         else
         {
            OnIncorrectAnswer();
         }
      }

      private void Slot2_OnTapped( object sender, TappedRoutedEventArgs e )
      {
         if ( CorrectAnswer == 1 )
         {
            OnCorrectAnswer();
         }
         else
         {
            OnIncorrectAnswer();
         }
      }

      private void Slot3_OnTapped( object sender, TappedRoutedEventArgs e )
      {
         if ( CorrectAnswer == 2 )
         {
            OnCorrectAnswer();
         }
         else
         {
            OnIncorrectAnswer();
         }
      }
   }
}

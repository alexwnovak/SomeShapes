using System;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SomeShapes
{
   public sealed partial class MainPage : Page
   {
      private readonly QuestionRepository _questionRepository = new QuestionRepository();
      private QuestionSlate _currentQuestionSlate;

      public MainPage()
      {
         InitializeComponent();
         FlashGrid.Opacity = 0;
      }

      private async void MainPage_OnLoaded( object sender, RoutedEventArgs e )
      {
         await DoQuestion();
      }

      private async Task DoQuestion()
      {
         var questionSlate = GetNewQuestion();

         await SayString( questionSlate.SpeechString );

         VisualStateManager.GoToState( this, "Normal", false );
      }

      private QuestionSlate GetNewQuestion()
      {
         DetachPreviousQuestion();

         var questionSlate = _questionRepository.GetNewQuestion();
         questionSlate.AnsweredCorrectly += OnAnsweredCorrectly;
         questionSlate.AnsweredIncorrectly += OnAnsweredIncorrectly;

         Grid.SetColumn( questionSlate, 1 );

         QuestionGrid.Children.Clear();
         QuestionGrid.Children.Add( questionSlate );

         return questionSlate;
      }

      private void DetachPreviousQuestion()
      {
         if ( _currentQuestionSlate == null )
         {
            return;
         }

         _currentQuestionSlate.AnsweredCorrectly -= OnAnsweredCorrectly;
         _currentQuestionSlate.AnsweredIncorrectly -= OnAnsweredIncorrectly;
         _currentQuestionSlate = null;
      }

      private async void OnAnsweredCorrectly( object sender, RoutedEventArgs e )
      {
         VisualStateManager.GoToState( this, "AnsweredCorrectly", false );
         await DoQuestion();
      }

      private void OnAnsweredIncorrectly( object sender, RoutedEventArgs e )
      {
      }

      private async Task SayString( string speechString )
      {
         var synth = new SpeechSynthesizer();

         SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync( speechString );

         MediaElement.SetSource( stream, stream.ContentType );
         MediaElement.Play();
      }
   }
}

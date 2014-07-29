using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace SomeShapes.Shapes
{
   public class ShapeQuestionGroup : IQuestionGroup
   {
      private readonly Tuple<Color, string>[] _colors = GenerateColors();

      public QuestionSlate GetQuestion()
      {
         var questionSlate = new QuestionSlate();

         var shapes = GetNextShape();
         var colors = GetNextColors();

         questionSlate.Option1 = GetShape( shapes[0], colors[0] );
         questionSlate.Option2 = GetShape( shapes[1], colors[1] );
         questionSlate.Option3 = GetShape( shapes[2], colors[2] );

         questionSlate.CorrectAnswer = Rng.Random.Next( 3 );

         string correctColor = colors[questionSlate.CorrectAnswer].Item2;
         string correctShape = shapes[questionSlate.CorrectAnswer].ToString();
         questionSlate.SpeechString = string.Format( "Touch the {0} {1}", correctColor, correctShape );

         return questionSlate;
      }

      private static Tuple<Color, string>[] GenerateColors()
      {
         return new[]
         {
            new Tuple<Color, string>( Colors.Black, "Black" ), 
            new Tuple<Color, string>( Colors.Red, "Red" ),
            new Tuple<Color, string>( Colors.Orange, "Orange" ),
            new Tuple<Color, string>( Colors.Yellow, "Yellow" ),
            new Tuple<Color, string>( Colors.Green, "Green" ),
            new Tuple<Color, string>( Colors.Blue, "Blue" ),
            new Tuple<Color, string>( Colors.Purple, "Purple" ),
            new Tuple<Color, string>( Colors.Pink, "Pink" )
         };
      }

      private UIElement GetShape( ShapeType shape, Tuple<Color, string> color )
      {
         switch ( shape )
         {
            case ShapeType.Square:
               return CreateSquare( color.Item1 );
            case ShapeType.Circle:
               return CreateCircle( color.Item1 );
            case ShapeType.Triangle:
               return CreateTriangle( color.Item1 );
            case ShapeType.Diamond:
               return CreateDiamond( color.Item1 );
         }

         return null;
      }

      private UIElement CreateDiamond( Color color )
      {
         var points = new PointCollection();

         points.Add( new Point( 0, 100 ) );
         points.Add( new Point( 100, 0 ) );
         points.Add( new Point( 200, 100 ) );
         points.Add( new Point( 100, 200 ) );

         return new Polygon
         {
            Fill = new SolidColorBrush( color ),
            Points = points
         };
      }

      private UIElement CreateTriangle( Color color )
      {
         var points = new PointCollection();

         points.Add( new Point( 0, 200 ) );
         points.Add( new Point( 100, 0 ) );
         points.Add( new Point( 200, 200 ) );

         return new Polygon
         {
            Fill = new SolidColorBrush( color ),
            Points = points
         };
      }

      private UIElement CreateSquare( Color color )
      {
         return new Grid
         {
            Background = new SolidColorBrush( color )
         };
      }

      private UIElement CreateCircle( Color color )
      {
         return new Ellipse
         {
            Fill = new SolidColorBrush( color ),
            Height = 200,
            Width = 200
         };
      }

      //private UIElement CreateHeart( Color color )
      //{
      //   var path = new Path
      //   {
      //      Fill = new SolidColorBrush( color )
      //   };

      //   var pathGeometry = new PathGeometry();

      //   var pathFigure = new PathFigure();

      //   var lineSegment1 = new LineSegment();
      //   lineSegment1.Point = new Point( 

      //   var pathSegment = new PathSegment();

      //   pathFigure.Segments.Add( new PathSegment() );  

      //   pathGeometry.Figures.Add( pathFigure ); 

      //   path.Data = new 
      //   path.Data.

      //   //<Path Stroke="Red" StrokeThickness="3" 
      //   //        Data="M 241,200 
      //   //              A 20,20 0 0 0 200,240
      //   //              C 210,250 240,270 240,270
      //   //              C 240,270 260,260 280,240
      //   //              A 20,20 0 0 0 239,200
      //   //              " />         
      //}

      private ShapeType[] GetNextShape()
      {
         var shapes = new List<ShapeType>();

         for ( int index = 0; index < 3; index++ )
         {
            ShapeType randomShape;

            do
            {
               randomShape = GetRandomShape();
            }
            while ( shapes.Contains( randomShape ) );

            shapes.Add( randomShape );
         }

         return shapes.ToArray();
      }

      private Tuple<Color, string>[] GetNextColors()
      {
         var colors = new List<Tuple<Color, string>>();

         for ( int index = 0; index < 3; index++ )
         {
            Tuple<Color, string> randomColor;

            do
            {
               randomColor = GetRandomColor();
            }
            while ( colors.Contains( randomColor ) );

            colors.Add( randomColor );
         }

         return colors.ToArray();
      }

      private Tuple<Color, string> GetRandomColor()
      {
         int index = Rng.Random.Next( _colors.Length );

         return _colors[index];
      }

      private ShapeType GetRandomShape()
      {
         var values = (ShapeType[]) Enum.GetValues( typeof( ShapeType ) );

         int index = Rng.Random.Next( values.Length );

         return values[index];
      }
   }
}

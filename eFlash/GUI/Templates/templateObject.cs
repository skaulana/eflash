using System;
using System.Collections.Generic;
using System.Text;

namespace eFlash.GUI.Templates
{
	public class TemplateObject
	{
		int _x1, _y1, _x2, _y2;
		int _side;
		// Type of this object (textFile, imageFile, soundFile)
		string _type;
		// Quiz type of this object (questionPrefix, answerPrefix, nonePrefix)
		string _quizType;

		public TemplateObject(string newType, int newSide, string newQuizType, int newX1, int newX2, int newY1, int newY2)
		{
			_type = newType;
			_side = newSide;
			_quizType = newQuizType;
			_x1 = newX1;
			_y1 = newY1;
			_x2 = newX2;
			_y2 = newY2;
		}

		#region Accessors

		public string type
		{
			get { return _type; }
		}

		public string quizType
		{
			get { return _quizType; }
		}

		public int side
		{
			get { return _side; }
		}

		public int x1
		{
			get { return _x1; }
		}

		public int y1
		{
			get { return _y1; }
		}

		public int x2
		{
			get { return _x2; }
		}

		public int y2
		{
			get { return _y2; }
		}

		#endregion
	}
}

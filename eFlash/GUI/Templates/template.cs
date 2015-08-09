using System;
using System.Collections.Generic;
using System.Text;

namespace eFlash.GUI.Templates
{
	public class Template
	{
		#region Static stuff

		// Hashtable to hold all templates
		public static Dictionary<string, List<Template>> templates;

		public static void initTemplates()
		{
			// Initalize hashtable
			templates = new	Dictionary<string, List<Template>>();

			// Initialize each category of templates
			templates.Add(Constant.textDeck, new List<Template>());
			templates.Add(Constant.imageDeck, new List<Template>());
			templates.Add(Constant.soundDeck, new List<Template>());

			Template curTemplate;

			// Initialize text quiz templates
			// A 1 sided template with both question and answer on first side
			curTemplate = new Template(Constant.textDeck);
			curTemplate.addQuestionObject(0, 30, 70, 20, 40);
			curTemplate.addAnswerObject(0, 20, 80, 50, 90);
			templates[Constant.textDeck].Add(curTemplate);

			// A 2 sided template with question on front and answer on
			// back, with several other non-quiz objects
			// In this case, sides 1 and 2 have the same layout
			curTemplate = new Template(Constant.textDeck);
			curTemplate.addQuestionObject(0, 30, 70, 30, 70);
			curTemplate.addNoneObject(Constant.textFile, 0, 30, 70, 80, 90);
			curTemplate.addAnswerObject(1, 30, 70, 30, 70);
			curTemplate.addNoneObject(Constant.textFile, 1, 30, 70, 80, 90);
			templates[Constant.textDeck].Add(curTemplate);

            // A 2 sided template w/ question on front and answer on 
            // back, with two other non-quiz objects (picture and sound
            // In this case, side 1 can have the picture and sound on the front
            // with one question object and side 2 can just have the answer object
            curTemplate = new Template(Constant.textDeck);
            curTemplate.addQuestionObject(0, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.imageFile, 0, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.soundFile, 0, 70, 90, 30, 70);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            templates[Constant.textDeck].Add(curTemplate);

            // A 2 sided template w/ question on front and answer on
            // back, with 2 other non-quiz objs (pix and sound)
            // In this case, side 1 can have just the question, and side 2
            // can have picture and sound, and the answer object
            curTemplate = new Template(Constant.textDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addAnswerObject(1, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.imageFile, 1, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.soundFile, 1, 70, 90, 30, 70);
            templates[Constant.textDeck].Add(curTemplate);

            // A 2 sided template w/ question on front and answer on
            // back, with 4 other non-quiz objs (pix and sound)
            // In this case, side 1 and side 2 both have images and sounds on their cards
            curTemplate = new Template(Constant.textDeck);
            curTemplate.addQuestionObject(0, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.imageFile, 0, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.soundFile, 0, 70, 90, 30, 70);
            curTemplate.addAnswerObject(1, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.imageFile, 1, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.soundFile, 1, 70, 90, 30, 70);
            templates[Constant.textDeck].Add(curTemplate);


			// Initialize image quiz templates
			curTemplate = new Template(Constant.imageDeck);
			curTemplate.addQuestionObject(0, 30, 70, 20, 60);
			curTemplate.addAnswerObject(0, 30, 70, 70, 90);
			templates[Constant.imageDeck].Add(curTemplate);
            
            //a 2-sided image quiz template
            curTemplate = new Template(Constant.imageDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            templates[Constant.imageDeck].Add(curTemplate);
            
            //a 2-sided image quiz template with text on both sides
            curTemplate = new Template(Constant.imageDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
			curTemplate.addNoneObject(Constant.textFile, 0, 30, 70, 80, 90);
			curTemplate.addAnswerObject(1, 30, 70, 30, 70);
			curTemplate.addNoneObject(Constant.textFile, 1, 30, 70, 80, 90);
            templates[Constant.imageDeck].Add(curTemplate);
            
            //a 2-sided image quiz with 2 text noneobjects on the answer side
            curTemplate = new Template(Constant.imageDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addAnswerObject(1, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 1, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 1, 70, 90, 30, 70);
            templates[Constant.imageDeck].Add(curTemplate);
            
            //a 2-sided image quiz with 2 text noneobjects on the question side
            curTemplate = new Template(Constant.imageDeck);
            curTemplate.addQuestionObject(0, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 0, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 0, 70, 90, 30, 70);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            templates[Constant.imageDeck].Add(curTemplate);

			// Initialize sound quiz templates
			curTemplate = new Template(Constant.soundDeck);
			curTemplate.addQuestionObject(0, 30, 70, 20, 40);
			curTemplate.addAnswerObject(0, 20, 80, 50, 90);
			templates[Constant.soundDeck].Add(curTemplate);
            
            // a 2-sided sound quiz template
            curTemplate = new Template(Constant.soundDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            templates[Constant.soundDeck].Add(curTemplate);
            
            //a 2-sided sound quiz template with text on both sides
            curTemplate = new Template(Constant.soundDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 0, 30, 70, 80, 90);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 1, 30, 70, 80, 90);
            templates[Constant.soundDeck].Add(curTemplate);
            
            //a 2-sided sound quiz with 2 text noneobjects on the answer side
            curTemplate = new Template(Constant.soundDeck);
            curTemplate.addQuestionObject(0, 30, 70, 30, 70);
            curTemplate.addAnswerObject(1, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 1, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 1, 70, 90, 30, 70);
            templates[Constant.soundDeck].Add(curTemplate);

            //a 2-sided sound quiz with 2 text noneobjects on the question side
            curTemplate = new Template(Constant.soundDeck);
            curTemplate.addQuestionObject(0, 10, 30, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 0, 40, 60, 30, 70);
            curTemplate.addNoneObject(Constant.textFile, 0, 70, 90, 30, 70);
            curTemplate.addAnswerObject(1, 30, 70, 30, 70);
            templates[Constant.soundDeck].Add(curTemplate);
		}

		#endregion


		#region Instance stuff

		private List<TemplateObject> _objects;
		private bool hasQuestion, hasAnswer;

		// Quiz type of this template (textDeck, imageDeck, soundDeck, or noQuizDeck)
		string _templateType;

		public Template(string newType)
		{
			_templateType = newType;

			_objects = new List<TemplateObject>();
			hasQuestion = false;
			hasAnswer = false;
		}

		/// <summary>
		/// Adds a question to this template. Type of the object to add is
		/// determined by the template type.
		/// </summary>
		private void addQuestionObject(int side, int x1, int x2, int y1, int y2)
		{
			if (hasQuestion)
			{
				throw new Exception("Trying to add multiple questions to a flashcard");
			}
			else
			{
				string objType;
				switch (templateType)
				{
					case Constant.textDeck:
						objType = Constant.textFile;
						break;
					case Constant.imageDeck:
						objType = Constant.imageFile;
						break;
					case Constant.soundDeck:
						objType = Constant.soundFile;
						break;
					default:
						throw new Exception("Invalid template type");
				}
				objects.Add(new TemplateObject(objType, side, Constant.questionPrefix, x1, x2, y1, y2));
				hasQuestion = true;
			}
		}

		/// <summary>
		/// Add an answer to this template. Type of object to add is always
		/// a text object. 
		/// </summary>
		private void addAnswerObject(int side, int x1, int x2, int y1, int y2)
		{
			if (hasAnswer)
			{
				throw new Exception("Trying to add multiple questions to a flashcard");
			}
			else
			{
				objects.Add(new TemplateObject(Constant.textFile, side, Constant.answerPrefix, x1, x2, y1, y2));
				hasAnswer = true;
			}
		}

		/// <summary>
		/// Add an object that is neither question nor answer. This object will
		/// not be shown during quizzing. 
		/// </summary>
		private void addNoneObject(string type, int side, int x1, int x2, int y1, int y2)
		{
			objects.Add(new TemplateObject(type, side, Constant.nonePrefix, x1, x2, y1, y2));
		}

		#region Accessors

		public string templateType
		{
			get { return _templateType; }
		}

		public List<TemplateObject> objects
		{
			get
			{
				return _objects;
			}
		}

		#endregion

		#endregion
	}
}

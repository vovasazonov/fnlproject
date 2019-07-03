package src {
	
	import caurina.transitions.Tweener;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.media.Sound;
	import se.svt.caspar.template.CasparTemplate;
	
	public class Main extends CasparTemplate
	{
		// ------------------ Layers ------------------
		public var up_title:background;
		public var up_ltimer:AddTimeMin; //up_ltimer - is the whole object, AddTimeMin - layer.
		public var up_change:change;

		// ------------------ Layers ------------------
		
		// ------------------ Booleans ------------------
		// True if the clock are showing. This clock contains only the color, name and score team and logo of FNL in clock. Without timer.
		private var _clockIsVisible:Boolean = false;		
		private var _gameTimeStarted:Boolean = false;
		private var _changeIsVisible:Boolean = false;		
		// ------------------ Booleans ------------------
		
		public function Main() {
			// constructor code
			
		}
		
		override public function SetData(xmlData:XML):void 
		{
			super.SetData(xmlData);
			for each(var element:XML in xmlData.elements())
			{
				// ----- up_title -----
				if(element.@id == "team1Name")
				{
					 up_title.team1Name = element.data.@value;
				}
				if(element.@id == "team2Name")
				{
					 up_title.team2Name = element.data.@value;
				}
				if(element.@id == "team1Color")
				{
					up_title.team1Color = element.data.@value;
				}
				if(element.@id == "team2Color")
				{
					up_title.team2Color = element.data.@value;
				}
				if(element.@id == "team1Score")
				{
					 up_title.team1Score = element.data.@value;
				}
				if(element.@id == "team2Score")
				{
					 up_title.team2Score = element.data.@value;
				}
				// ----- up_title -----
				
				// ----- up_ltimer -----
				if(element.@id == "gameTime")
				{
					up_ltimer.gameTime = element.data.@value;
				}
				if(element.@id == "halfNum")
				{
					up_ltimer.halfNum = element.data.@value;
				}
				if(element.@id == "overtime") // it is additional minutes
				{
					up_ltimer.overTime = element.data.@value;
				}
				// ----- up_ltimer -----
				
			}
		}
		
		// Show or hide the main title.
		public function clockShowHide():void
		{
			// Hide clock
			if (_clockIsVisible)
			{
				up_title.clockHide();
				_clockIsVisible = false;
				
				// Hide all timer
				up_ltimer.hideAllTimers();
			}
			// Show clock.
			else
			{
				up_title.clockShow();
				_clockIsVisible = true;
			}
			
			// Inform timers about visible of clock.
			up_ltimer._clockIsShown = _clockIsVisible;
		}
		
		// Show or hide addtional minutes.
		public function ltimerShowHide():void
		{
			if (!up_ltimer._clockAddIsHidden)
			{
				up_ltimer.clockHideAddMinutes();
				up_ltimer._clockAddIsHidden = true;

			}
			else
			{
				if(_clockIsVisible)
				{
					up_ltimer.clockShowAddMinutes();
					//up_ltimer._clockAddIsHidden = false;
				}
			}
		}
		
		
		public function changeShowHide():void
		{
			if (_changeIsVisible)
			{
				up_change.changeHide();
				_changeIsVisible = false;

			}
			else
			{
				up_change.changeShow();
				_changeIsVisible = true;
			}
		}
		
		
		// Show or hide the classic timer.
		public function clockShowHideTimer():void
		{
			if (!up_ltimer._clockTimerIsHidden)
			{
				up_ltimer.clockHideTimer();
				up_ltimer._clockTimerIsHidden = true;

			}
			else
			{
				// Show clock
				if(_clockIsVisible)
				{
					up_ltimer.clockShowTimer();
					up_ltimer._clockTimerIsHidden = false;
				}
			}
		}
		
		// Strat the timer or stop it.
		public function gameTimeStartStop():void
		{
			if (_gameTimeStarted)
			{
				up_ltimer.gameTimeStop();
				_gameTimeStarted = false;
			}
			else
			{
				up_ltimer.gameTimeStart();
				_gameTimeStarted = true;
			}
		}
		
		
	}
	
}

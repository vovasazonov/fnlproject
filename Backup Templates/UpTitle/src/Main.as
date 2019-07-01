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
		// True if extra minutes that judje give to game are showing.
		private var _clockAddIsVisible:Boolean = false;		
		
		// True if the classic timer is showing. It is not an extra timer after 45 min or 90 min.		
		private var _clockTimerIsVisible:Boolean = false;
		// True if the extra timer is showing.
		//private var _clockTimerExtraIsVisible:Boolean = false;
		private var _gameTimeStarted:Boolean = false;
		//
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
				if(element.@id == "team1Name")
				{
					 up_title.team1Name = element.data.@value;
				}
				if(element.@id == "team2Name")
				{
					 up_title.team2Name = element.data.@value;
				}
				if(element.@id == "team1Score")
				{
					 up_title.team1Score = element.data.@value;
				}
				if(element.@id == "team2Score")
				{
					 up_title.team2Score = element.data.@value;
				}
				//if(element.@id == "gameTime")
				//{
				//	 up_ltimer.gameTime = element.data.@value;
				//}
			}
		}
		
		// Show or hide the main title.
		public function clockShowHide():void
		{
			if (_clockIsVisible)
			{
				up_title.clockHide();
				_clockIsVisible = false;
				
				//Hide timer
				_clockAddIsVisible = false;
				_clockTimerIsVisible = false;
				up_ltimer.clockHideTimer();
			}
			else
			{
				up_title.clockShow();
				_clockIsVisible = true;
			}
		}
		
		// Show or hide addtional minutes.
		public function ltimerShowHide():void
		{
			if (_clockAddIsVisible)
			{
				up_ltimer.clockHideAddMinutes();
				_clockAddIsVisible = false;

			}
			else
			{
				if(_clockIsVisible)
				{
					up_ltimer.clockShowAddMinutes();
					_clockAddIsVisible = true;
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
			if (_clockTimerIsVisible)
			{
				up_ltimer.clockHideTimer();
				_clockTimerIsVisible = false;

			}
			else
			{
				// Show clock
				if(_clockIsVisible)
				{
					up_ltimer.clockShowTimer();
					_clockTimerIsVisible = true;
				}
			}
		}
		
		// Strat the timer
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
		/*
		// Show or hide the extra timer.
		public function clockShowHideTimerExtra():void
		{
			trace("clockShowHideTimerExtra");
			if (_clockTimerExtraIsVisible)
			{
				up_addTime.clockShowTimerExtra();
				_clockTimerExtraIsVisible = false;

			}
			else
			{
				up_addTime.clockHideTimerExtra();
				_clockTimerExtraIsVisible = true;
			}
		}
		*/
		
	}
	
}

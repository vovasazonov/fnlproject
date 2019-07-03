package src {
	
	import caurina.transitions.Equations;
	import flash.display.MovieClip;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import caurina.transitions.Tweener;
	import flash.geom.ColorTransform;
	
	
	public class AddTimeMin extends MovieClip {
		
		public var extraTime:MovieClip; //Time after 45 min 90 and etc.
		public var time:MovieClip;
		public var extraTimeLeft:MovieClip;// It is additional minutes
		
		private var _timer:Timer;
		private var _timeMinutes:int = 0;
		private var _timeSeconds:int = 0;
		private var _extratimeMinutes:int = 0;
		private var _extratimeSeconds:int = 1;
		private var _gameTime:String;
		private var _overTime:int;
		private var _halfNum:uint = 1;
		
		public var _clockIsShown:Boolean = false;
		// Minutes that judje gives to game.
		public var _clockAddIsHidden:Boolean = true;
		// Timer classic.
		public var _clockTimerIsHidden:Boolean = true;
		// Extra timer that go after 45 min and after 90 min.
		public var _clockTimerExtraIsHidden:Boolean = true;
		
		
		
		public function AddTimeMin() {
			// constructor code
			_timer = new Timer(1000);
			_timer.addEventListener(TimerEvent.TIMER, onTimer);
		}
		
		private function onTimer(e:TimerEvent):void 
		{
			_timeSeconds++;
			updateTime();
		}
		
		public function gameTimeStart():void
		{
			_timer.start();
		}
		
		public function gameTimeStop():void
		{
			_timer.stop();
		}
		
		public function set halfNum(value:uint):void 
		{
			_halfNum = value;
		}
		
		public function set overTime(value:int):void 
		{
			_overTime = value;
			if (value == 0)
			{
				extraTimeLeft.xtf.text = " ";
			
			}
			else
			{
				extraTimeLeft.xtf.text = "+ " + value.toString();
			}
		}
		
		private function updateTime():void
		{
			if ((_timeMinutes == 45 && _halfNum == 1) || (_timeMinutes == 90 && _halfNum == 2) || (_timeMinutes == 105 && _halfNum == 3) || (_timeMinutes == 120 && _halfNum == 4))
			{
				var eminutes:String;
				var eseconds:String;
				
				if (_extratimeSeconds == 60)
				{
					_extratimeSeconds = 0; 
					_extratimeMinutes++;
				}
				
				
				eseconds = _extratimeSeconds.toString();
				eminutes = _extratimeMinutes.toString();
				
				if (_extratimeSeconds < 10) eseconds = "0" + _extratimeSeconds.toString();
				
				extraTime.xtf.text = eminutes + ":" + eseconds;
				_extratimeSeconds++;
				
				// Show extra timer if it is not showing yet
				if(_clockTimerExtraIsHidden && _clockIsShown && !_clockTimerIsHidden)
				{
					clockShowExtraTimer();
				}
				
			}
			else
			{
				//normal update
				var minutes:String;
				var seconds:String;
				extraTime.xtf.text = "";
				
				_extratimeSeconds = 1;
				_extratimeMinutes = 0;
				if (((_timeSeconds == 60 && _timeMinutes == 44) && _halfNum == 1) || ((_timeSeconds == 60 && _timeMinutes == 89) && _halfNum == 2) || ((_timeSeconds == 60 && _timeMinutes == 104) && _halfNum == 3) || ((_timeSeconds == 60 && _timeMinutes == 119) && _halfNum == 4))
				{
					//extra time, dont increment clock but extra time
					_timeSeconds = 0;
					_timeMinutes++;
					
					
					//Tweener.addTween(extraTime, { time: .4, alpha: 1, transition: Equations.easeOutCirc } );
					extraTime.xtf.text = "00:00";
				}
				else
				{
					if (_timeSeconds == 60)
					{
						_timeSeconds = 0; 
						_timeMinutes++;
					}
				}
				
				seconds = _timeSeconds.toString();
				minutes = _timeMinutes.toString();
				
				if (_timeSeconds < 10) seconds = "0" + _timeSeconds.toString();
				if (_timeMinutes < 10) minutes = "0" + _timeMinutes.toString();
				
				
				time.xtf.text = minutes + ":" + seconds;
				
				// Hide extra timer if it showing
				if(!_clockTimerExtraIsHidden)
				{
					clockHideExtraTimer();
				}
			}
		}
		
		public function set gameTime(value:String):void 
		{
			
			_gameTime = value;
			var a:Array = value.split(":");
			_timeMinutes = a[0];
			_timeSeconds = a[1];
			
			if (_timeMinutes >= 45 && _halfNum == 1)
			{
				//extra time
				_extratimeMinutes = _timeMinutes - 45;
				_extratimeSeconds = _timeSeconds;
				
				_timeMinutes = 45;
				_timeSeconds = 0;

				time.xtf.text = "45.00";
			}
			else if (_timeMinutes >= 90 && _halfNum == 2)
			{
				//extra time
				_extratimeMinutes = _timeMinutes - 90;
				_extratimeSeconds = _timeSeconds;
				
				_timeMinutes = 90;
				_timeSeconds = 0;

				time.xtf.text = "90.00";
			}
			else if (_timeMinutes >= 105 && _halfNum == 3)
			{
				//extra time
				_extratimeMinutes = _timeMinutes - 105;
				_extratimeSeconds = _timeSeconds;
				
				_timeMinutes = 105;
				_timeSeconds = 0;

				time.xtf.text = "105.00";
			}
			else if (_timeMinutes >= 120 && _halfNum == 4)
			{
				//extra time
				_extratimeMinutes = _timeMinutes - 120;
				_extratimeSeconds = _timeSeconds;
				
				_timeMinutes = 120;
				_timeSeconds = 0;

				time.xtf.text = "120.00";
			}
			else
			{
				//extraTime.alpha = 0;
				
			}
			updateTime();
		}
		
		// Show additional minutes.
		public function clockShowAddMinutes():void
		{
			// Show additional minutus only if extra time are showing.
			if(!_clockTimerExtraIsHidden)
			{
				_clockAddIsHidden = false;			
				_clockTimerIsHidden = false;
				_clockTimerExtraIsHidden = false;
				
				this.gotoAndPlay("in3");
			}
		}
		// Hide additional minutes.
		public function clockHideAddMinutes():void
		{
			_clockAddIsHidden = true;
			
			this.gotoAndStop("in3");
		}
		// Hide timer.
		public function clockHideTimer():void
		{
			hideAllTimers();
		}
		// Show timer.
		public function clockShowTimer():void
		{
			_clockTimerIsHidden = true;
			this.gotoAndPlay("in1");
		}
		// Show extra timer.
		public function clockShowExtraTimer():void
		{
			_clockTimerExtraIsHidden = false;
			_clockTimerIsHidden = false;
			
			this.gotoAndPlay("in2");
		}
		// Hide extra timer.
		public function clockHideExtraTimer():void
		{
			_clockTimerExtraIsHidden = true;
			_clockAddIsHidden = true;
			
			this.gotoAndStop("in2");
		}
		// Hide all timers.
		public function hideAllTimers():void
		{
			_clockAddIsHidden = true;
			_clockTimerIsHidden = true;
			_clockTimerExtraIsHidden = true;
			
			this.gotoAndStop("in1");
		}
		
		
	}
	
}

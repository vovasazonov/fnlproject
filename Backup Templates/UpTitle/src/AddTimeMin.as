package src {
	
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
		private var _overTimeVisible:Boolean = false;
		private var _overTimeLeftVisible:Boolean = false;
		private var _halfNum:uint = 1;
		
		// Minutes that judje gives to game.
		private var _clockAddIsHidden:Boolean = true;
		
		// Timer classic.
		private var _clockTimerIsHidden:Boolean = true;
		// Extra timer that go after 45 min and after 90 min.
		//private var _clockTimerExtraIsHidden:Boolean = true;
		
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
					extraTime.xtf.text = "0.00";
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
				
				
				time.xtf.text = minutes + "." + seconds;
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
				extraTime.alpha = 0;
				
			}
			updateTime();
		}
		
		public function clockShowAddMinutes():void
		{
			_clockAddIsHidden = false;
			this.gotoAndPlay("in3");
		}
		
		public function clockHideAddMinutes():void
		{
			_clockAddIsHidden = true;
			this.gotoAndPlay("out");
		}
		
		public function clockHideTimer():void
		{
			_clockTimerIsHidden = false;
			this.gotoAndPlay("out");
		}
		
		public function clockShowTimer():void
		{
			_clockTimerIsHidden = true;
			this.gotoAndPlay("in1");
		}
		
		
	}
	
}

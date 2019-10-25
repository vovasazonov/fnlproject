package scr {
	
	import caurina.transitions.Equations;
	import flash.display.MovieClip;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import caurina.transitions.Tweener;
	
	
	public class background extends MovieClip {
		
		
		private var _overTimeVisible:Boolean = false;
		private var _clockIsHidden:Boolean = true;
		
		public function background() {
			// constructor code
			super();
		}
		
		public function clockShow():void
		{
			_clockIsHidden = false;

			if (_overTimeVisible)
			{
				Tweener.addTween(extraTime, { time: .4, alpha: 1, delay: .8, transition: Equations.easeOutCirc } );
			}
			if (_overTimeLeftVisible)
			{
				Tweener.addTween(extraTimeLeft, { time: .4, alpha: 1, delay: .8, transition: Equations.easeOutCirc } );
			}
			this.gotoAndPlay("in");
		}
		
		public function clockHide():void
		{
			_clockIsHidden = true;
			this.gotoAndPlay("out");
			if (extraTime.alpha == 1)
			{
				Tweener.addTween(extraTime, { time: .4, alpha: 0, transition: Equations.easeOutCirc } );
				_overTimeVisible = true;
			}
			else
			{
				_overTimeVisible = false;
			}
			if (extraTimeLeft.alpha == 1)
			{
				Tweener.addTween(extraTimeLeft, { time: .4, alpha: 0, transition: Equations.easeOutCirc } );
				_overTimeLeftVisible = true;
			}
			else
			{
				_overTimeLeftVisible = false;
			}
			Tweener.addTween(extraTimeSign.sign, { time: .3, y: -35, transition: Equations.easeOutSine, onComplete: function() { extraTimeSign.alpha = 0; } } );
		}
	}
	
}

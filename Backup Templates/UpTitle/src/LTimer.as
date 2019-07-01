package src {
	
	import flash.display.MovieClip;
	
	
	public class LTimer extends MovieClip {
		
		
		// Minutes that judje gives to game.
		private var _clockLTIsHidden:Boolean = true;
		/*
		// Timer classic.
		private var _clockTimerIsHidden:Boolean = true;
		// Extra timer that go after 45 min and after 90 min.
		private var _clockTimerExtraIsHidden:Boolean = true;
		*/
		
		public function LTimer() {
			// constructor code
		}
		
		public function clockShowLTimer():void
		{
			_clockLTIsHidden = false;
			this.gotoAndPlay("in3");
		}
		
		public function clockHideLTimer():void
		{
			_clockLTIsHidden = true;
			this.gotoAndPlay("out");
		}
	}
	
}

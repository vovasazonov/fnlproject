package src {
	
	import flash.display.MovieClip;
	
	
	public class AddTime extends MovieClip {
		
		// Minutes that judje gives to game.
		private var _clockAddIsHidden:Boolean = true;
		/*
		// Timer classic.
		private var _clockTimerIsHidden:Boolean = true;
		// Extra timer that go after 45 min and after 90 min.
		private var _clockTimerExtraIsHidden:Boolean = true;
		*/
		
		public function AddTime() {
			// constructor code
			super();
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
		
		/*
		public function clockShowTimer():void
		{
			_clockTimerIsHidden = false;
			this.gotoAndPlay("in1");
		}
		
		public function clockHideTimer():void
		{
			_clockTimerIsHidden = true;
			this.gotoAndPlay("out");
		}
		
		public function clockShowTimerExtra():void
		{
			_clockTimerExtraIsHidden = false;
			this.gotoAndPlay("in2");
		}
		
		public function clockHideTimerExtra():void
		{
			_clockTimerExtraIsHidden = true;
			this.gotoAndPlay("out");
		}
		*/
	}
	
}

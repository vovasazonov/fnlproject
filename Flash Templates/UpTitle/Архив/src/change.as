package src {
	
	import flash.display.MovieClip;
	
	
	public class change extends MovieClip {
		
		
		private var _changeIsHidden:Boolean = true;
		
		public function change() {
			// constructor code
		}
		
		public function changeShow():void
		{
			_changeIsHidden = false;
			this.gotoAndPlay("in");
		}
		
		public function changeHide():void
		{
			_changeIsHidden = true;
			this.gotoAndPlay("out");
			
		}
	}
	
}

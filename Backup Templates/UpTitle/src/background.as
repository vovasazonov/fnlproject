package src {
	
	import caurina.transitions.Equations;
	import flash.display.MovieClip;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import caurina.transitions.Tweener;
	import fl.motion.easing.Back;
	import flash.geom.ColorTransform;
	import fl.motion.Color;
	
	
	public class background extends MovieClip {
		
		public var scoreTeam1:MovieClip;
		public var scoreTeam2:MovieClip;
		public var team1:MovieClip;				//Name of team 1
		public var team2:MovieClip;				//Name of team 2
		public var colorTeam1:MovieClip;
		public var colorTeam2:MovieClip;
		
		private var _team1Name:String;
		private var _team2Name:String;
		private var _team1Score:String;
		private var _team2Score:String;
		
		private var _clockIsHidden:Boolean = true;
		
		public function background() {
			// constructor code
			
		}
		
		public function clockShow():void
		{
			_clockIsHidden = false;
			this.gotoAndPlay("in");
			
		}
		
		public function clockHide():void
		{
			_clockIsHidden = true;
			this.gotoAndPlay("out");
			
			// ******** for test color changing ******** delete after test
			//team1Color();
			//team2Color();
			// ******** for test color changing ******** delete after test
		}
		
		public function set team1Name(value:String):void 
		{
			_team1Name = value;
			team1.xtf.text = value;
		}
		
		public function set team2Name(value:String):void 
		{
			_team2Name = value;
			team2.xtf.text = value;
		}
		
		public function set team1Score(value:String):void 
		{
			_team1Score = value;
			scoreTeam1.xtf.text = value;
		}
		
		public function set team2Score(value:String):void 
		{
			_team2Score = value;
			scoreTeam2.xtf.text = value;
		}
		
		// ******** work function but needs to modify like in example to change colors by value ********
		//public function set team1Color(value:ColorTransform):void
		public function team1Color():void 
		{
			// new ColorTransform object
			var obj_color:ColorTransform = new ColorTransform();

			// setting the new color we want (in this case, red)
			obj_color.color = 0xFF4669;

			colorTeam1.transform.colorTransform = obj_color;
		}
		
		//public function set team2Color(value:ColorTransform):void 		
		public function team2Color():void 
		{
			// new ColorTransform object
			var obj_color:ColorTransform = new ColorTransform();

			// setting the new color we want (in this case, blue)
			obj_color.color = 0x0000ff;

			colorTeam2.transform.colorTransform = obj_color;
		}
		// ******** work function but needs to modify like in example to change colors by value ********
		
	}
	
}

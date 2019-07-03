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
		private var _team1Color:String;
		private var _team2Color:String;
		
		public function background() {
			// constructor code
			
		}
		
		public function clockShow():void
		{
			this.gotoAndPlay("in");
		}
		
		public function clockHide():void
		{
			this.gotoAndPlay("out");
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
		
		public function set team1Color(value:String):void 
		{
			// new ColorTransform object
			var obj_color:ColorTransform = new ColorTransform();
			
			// set the new color
			_team1Color = value;
			obj_color.color = parseInt(value,10);
			colorTeam1.transform.colorTransform = obj_color;
			
		}
				
		public function set team2Color(value:String):void 
		{
			// new ColorTransform object
			var obj_color:ColorTransform = new ColorTransform();
			
			// set the new color
			_team2Color = value;
			obj_color.color = parseInt(value,10);
			colorTeam2.transform.colorTransform = obj_color;
		}
		
	}
	
}

package src {
	
	import caurina.transitions.Equations;
	import flash.display.MovieClip;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import caurina.transitions.Tweener;
	import fl.motion.easing.Back;
	import flash.geom.ColorTransform;
	import flash.geom.Transform;
	import fl.motion.Color;
	import flash.events.Event;
	import flashx.textLayout.events.ModelChange;
	
	public class background extends MovieClip {
		
		public var scoreTeam1:MovieClip;
		public var scoreTeam2:MovieClip;
		public var team1:MovieClip;				//Name of team 1
		public var team2:MovieClip;				//Name of team 2
		public var colorTeam1:MovieClip;
		public var colorTeam2:MovieClip;
		public var NamePlayerText:MovieClip;
		public var backNameTeamLeft:MovieClip;
		public var backNameTeamRight:MovieClip;
		public var squareRedLeft:MovieClip;
		public var squareRedRight:MovieClip;
		public var logoFNL:MovieClip;
		
		
		private var _team1Name:String;
		private var _team2Name:String;
		private var _team1Score:String;
		private var _team2Score:String;
		private var _team1Color:String;
		private var _team2Color:String;
		
		
		private function SetVisibleMovieClips(isVisible:Boolean):void
		{
			scoreTeam1.visible = isVisible;
		  	scoreTeam2.visible = isVisible;
		  	team1.visible = isVisible;				
		  	team2.visible = isVisible;				
		  	colorTeam1.visible = isVisible;
		  	colorTeam2.visible = isVisible;
		  	NamePlayerText.visible = isVisible;
		  	backNameTeamLeft.visible = isVisible;
		  	backNameTeamRight.visible = isVisible;
			squareRedLeft.visible = isVisible;
			squareRedRight.visible = isVisible;
			logoFNL.visible = isVisible;
		}
		
		private function OnEnterFrame(e:Event):void
		{
			if(this.currentFrameLabel == "finish"){
				SetVisibleMovieClips(false);
			}
		}
		
		public function background() {
			// constructor code
			SetVisibleMovieClips(false);
			this.addEventListener(Event.ENTER_FRAME,OnEnterFrame);
		}
		
		public function clockShow():void
		{
			this.gotoAndPlay("in");
			SetVisibleMovieClips(true);
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
			colorTeam1.theColor.transform.colorTransform = obj_color;
			
		}
				
		public function set team2Color(value:String):void 
		{
			// new ColorTransform object
			var obj_color:ColorTransform = new ColorTransform();
			
			// set the new color
			_team1Color = value;
			obj_color.color = parseInt(value,10);
			colorTeam2.theColor.transform.colorTransform = obj_color;

		
		}
		
		public function set namePlayerBackround(value:String):void 
		{
			NamePlayerText.xtf.text = value;
		}
		
		public function playerRightTeamShow():void
		{
			this.gotoAndPlay("inrp");
		}
		
		public function playerLeftTeamShow():void
		{
			this.gotoAndPlay("inlp");
			
		}
		public function playerRightTeamHide():void
		{
			this.gotoAndPlay("outrp");
		}
		
		public function playerLeftTeamHide():void
		{
			this.gotoAndPlay("outlp");
		}
		
		public function ShowLeftRedCard1():void
		{
			backNameTeamLeft.redCard1.visible = true;
		}
		public function HideLeftRedCard1():void
		{
			backNameTeamLeft.redCard1.visible = false;
		}
		
		public function ShowRightRedCard1():void
		{
			backNameTeamRight.redCard1.visible = true;
		}
		public function HideRightRedCard1():void
		{
			backNameTeamRight.redCard1.visible = false;
		}
		public function ShowLeftRedCard2():void
		{
			
		}
		public function HideLeftRedCard2():void
		{
			
		}
		public function ShowRightRedCard2():void
		{
			
		}
		public function HideRightRedCard2():void
		{
			
		}
		
	}
	
}

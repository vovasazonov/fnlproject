﻿package src {
	
	import flash.display.MovieClip;
	import flash.net.URLRequest;
	import flash.display.DisplayObject;
	import flash.display.Loader;
	import flash.display.LoaderInfo;
	import flash.system.JPEGLoaderContext;
	import flash.events.EventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.events.Event;
	import flash.net.URLLoader;
	import flashx.textLayout.events.ModelChange;
	import flash.events.Event;
	import flash.display.Bitmap;
	
	public class replacementPlayers extends MovieClip {
		private var MainEx:Main;
		
		public var LogoTeam:MovieClip;
		public var RedLine:MovieClip;
		public var GreenLine:MovieClip;
		public var eventName:MovieClip;
		public var eventValue:MovieClip;
		public var eventCard:MovieClip;
		public var secondEventName:MovieClip;
		public var secondEventValue:MovieClip;
		
		private var _isLogo:Boolean = false;
		private var _loaderLogo:Loader=new Loader();
		private var _logoTeamPath:String;
		private var _nameRedLine:String;
		private var _numberRedLine:String;
		private var _nameGreenLine:String;
		private var _numberGreenLine:String;
		
		private function SetVisibleMovieClips(isVisible:Boolean):void{
			SetVisibleReplacement(isVisible);
			SetVisibleEvent(isVisible);
		}
		
		private function SetVisibleReplacement(isVisible:Boolean):void{
			LogoTeam.visible = isVisible;
			RedLine.visible = isVisible;
			GreenLine.visible = isVisible;
		}
		
		private function SetVisibleEvent(isVisible:Boolean):void{
			eventName.visible = isVisible;
			eventValue.visible = isVisible;
			eventCard.visible = isVisible;
		}
		
		private function OnEnterFrame(e:Event):void
		{
			if(this.currentFrameLabel == "finishout"){
				SetVisibleMovieClips(false);
			}
		}
		
		public function replacementPlayers() {
			// constructor code
			SetVisibleMovieClips(false);
			this.addEventListener(Event.ENTER_FRAME,OnEnterFrame);
		}
		
		// ----- Set methods. -----
		public function set nameRedLine(value:String):void 
		{
			RedLine.NameText.text = value;
			_nameRedLine = value;
		}
		public function set numberRedLine(value:String):void 
		{
			RedLine.NumberText.text = value;
			_numberRedLine = value;
		}
		public function set nameGreenLine(value:String):void 
		{
			GreenLine.NameText.text = value;
			_nameGreenLine = value;
		}
		public function set numberGreenLine(value:String):void 
		{
			GreenLine.NumberText.text = value;
			_numberGreenLine = value;
		}
		public function set logoTeam(value:String):void 
		{
			// Remove another logo if exist.
			if(_isLogo){
				LogoTeam.removeChild(_loaderLogo);
				_isLogo = false;
			}
			
			// Create new logo.
			_logoTeamPath = value;
			
			_loaderLogo=new Loader();
			_loaderLogo.contentLoaderInfo.addEventListener(Event.COMPLETE, onCompliteLoadLogo);
			LogoTeam.addChild(_loaderLogo);
			_loaderLogo.load(new URLRequest(_logoTeamPath));
			_isLogo = true;
			
			// Catch error.
			_loaderLogo.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR,ioErrorLogo,false,0,true);
		}
		function ioErrorLogo(evt:IOErrorEvent):void{
			trace("Error input output of logo!!!");
		}
		function onCompliteLoadLogo(event:Event):void
		{
   			 EventDispatcher(event.target).removeEventListener(event.type, arguments.callee);
			 
			 Bitmap((event.target as LoaderInfo).content).smoothing = true;
   			 var image:DisplayObject = (event.target as LoaderInfo).content;

   			 image.width = 45;
   			 image.height = 45;
		}
		public function set eventNameLine(value:String):void 
		{
			eventName.valueText.text = value;
		}
		public function set eventValueLine(value:String):void 
		{
			eventValue.valueText.text = value;
		}
		public function set secondEventNameLine(value:String):void 
		{
			secondEventName.valueText.text = value;
		}
		public function set secondsEventValueLine(value:String):void 
		{
			secondEventValue.valueText.text = value;
		}
		// ----- Set methods. -----
		
		public function ReplacementShow():void
		{
			SetVisibleMovieClips(false);
			
			this.gotoAndPlay("in");
			SetVisibleReplacement(true);
		}
		
		public function RedCardShow(mainExamp:Main):void
		{
			SetVisibleMovieClips(false);
			MainEx = mainExamp;
			
			this.gotoAndPlay("inrc");
			SetVisibleEvent(true);
			
			this.addEventListener(Event.ENTER_FRAME,HideNamePlayer);
		}
		public function YellowCardShow(mainExamp:Main):void
		{
			SetVisibleMovieClips(false);
			MainEx = mainExamp;
			
			this.gotoAndPlay("inyc");
			SetVisibleEvent(true);
			
			this.addEventListener(Event.ENTER_FRAME,HideNamePlayer);
		}
		public function GoalShow(mainExamp:Main):void
		{
			SetVisibleMovieClips(false);
			MainEx = mainExamp;
			
			this.gotoAndPlay("ingoals");
			SetVisibleEvent(true);
			
			this.addEventListener(Event.ENTER_FRAME,HideNamePlayer);
		}
		private function HideNamePlayer(e:Event):void
		{
			if(this.currentFrameLabel == "stop1" || this.currentFrameLabel == "stop2" || this.currentFrameLabel == "stop3")
			{
				MainEx.PlayerClockShowHide();
				this.removeEventListener(Event.ENTER_FRAME,HideNamePlayer);
			}
		}
		
	}
	
}

package src {
	
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
	
	public class replacementPlayers extends MovieClip {
		
		public var LogoTeam:MovieClip;
		public var RedLine:MovieClip;
		public var GreenLine:MovieClip;
		
		private var _isLogo:Boolean = false;
		private var _loaderLogo:Loader=new Loader();
		private var _logoTeamPath:String;
		private var _nameRedLine:String;
		private var _numberRedLine:String;
		private var _nameGreenLine:String;
		private var _numberGreenLine:String;
		
		public function replacementPlayers() {
			// constructor code
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
   			 var image:DisplayObject = (event.target as LoaderInfo).content;

   			 image.width = 45;
   			 image.height = 45;
		}

		// ----- Set methods. -----
		
		public function ReplacementShow():void
		{
			this.gotoAndPlay("in");
		}
		
	}
	
}

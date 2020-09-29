package src
{

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
	import flash.display.Bitmap;


	public class LowerWindow extends MovieClip
	{
		private var MainEx:Main;

		public var Up:MovieClip;
		public var Down:MovieClip;

		private var _loaderLogoHome:Loader=new Loader();
		private var _loaderLogoGuest:Loader=new Loader();
		private var _isLogoHome:Boolean=false;
		private var _isLogoGuest:Boolean=false;
		private var _logoTeamPath:String;
		
		private function SetVisibleMovieClips(isVisible:Boolean):void{
			Up.visible = isVisible;
			Down.visible = isVisible;
		}
		
		public function LowerWindow()
		{
			// constructor code
			SetVisibleMovieClips(false);
		}

		// ----- Set methods. -----
		public function set titleName(value:String):void
		{
			Up.Title.text = value;
		}
		public function set scoreHomeTeam(value:String):void
		{
			Down.ScoreHome.text = value;
		}
		public function set scoreGuestTeam(value:String):void
		{
			Down.ScoreGuest.text = value;
		}
		public function set nameHomeTeam(value:String):void
		{
			Down.NameHome.text = value;
		}
		public function set nameGuestTeam(value:String):void
		{
			Down.NameGuest.text = value;
		}
		
		public function set logoHomeTeam(value:String):void
		{
			if(_isLogoHome)
			{
				Down.LogoHome.removeChild(_loaderLogoHome);
				_isLogoHome = false;
			}
			setLogo(value,_loaderLogoHome,Down.LogoHome);
			_isLogoHome = true;
		}

		public function set logoGuestTeam(value:String):void
		{
			if(_isLogoGuest)
			{
				Down.LogoGuest.removeChild(_loaderLogoGuest);
				_isLogoGuest = false;
			}
			setLogo(value,_loaderLogoGuest,Down.LogoGuest);
			_isLogoGuest = true;
		}
		// ----- Set methods. -----
		
		public function WindowShow():void
		{
			this.gotoAndPlay("in");
			SetVisibleMovieClips(true);
		}
		public function WindowHide():void
		{
			this.gotoAndPlay("out");
			SetVisibleMovieClips(false);
		}
		
		private function setLogo(logoTeamPath:String,loaderLogo:Loader,movieLogo:MovieClip):void
		{		
			loaderLogo=new Loader();
			loaderLogo.contentLoaderInfo.addEventListener(Event.COMPLETE, onCompliteLoadLogo);
			movieLogo.addChild(loaderLogo);
			loaderLogo.load(new URLRequest(logoTeamPath));

			// Catch error.
			loaderLogo.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR,ioErrorLogo,false,0,true);
		}
		private function ioErrorLogo(evt:IOErrorEvent):void{
			trace("Error input output of logo!!!");
		}
		private function onCompliteLoadLogo(event:Event):void
		{
   			 EventDispatcher(event.target).removeEventListener(event.type, arguments.callee);

			 Bitmap((event.target as LoaderInfo).content).smoothing = true;
   			 var image:DisplayObject = (event.target as LoaderInfo).content;

   			 image.width = 101;
   			 image.height = 101;
		}
	}
}
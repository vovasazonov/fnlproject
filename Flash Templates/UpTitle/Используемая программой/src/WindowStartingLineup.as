package src{
	
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
	import se.svt.caspar.templateHost.LoadedTemplateItem;
	
	public class WindowStartingLineup extends MovieClip {
		
		public var UpLine:MovieClip;
		public var CenterLine:MovieClip;
		public var CenterLineSmall:MovieClip;
		public var DownLine:MovieClip;
		
		// ---- 	Logo&Titles 	----
		private var _isLogo:Boolean = false;
		private var _loaderLogo:Loader=new Loader();
		private var _logoTeamPath:String;
		private var _nameTitle:String;
		private var _nameSeason:String;
		// -----------------------------
		// ----Name people& numbers ----
		private var _nameTrainer:String;
		private var _ampluaPlayer1:String;
		private var _namePlayer1:String;
		private var _namePlayer2:String;
		private var _namePlayer3:String;
		private var _namePlayer4:String;
		private var _namePlayer5:String;
		private var _namePlayer6:String;
		private var _namePlayer7:String;
		private var _namePlayer8:String;
		private var _namePlayer9:String;
		private var _namePlayer10:String;
		private var _namePlayer11:String;
		private var _numPlayer1:String;
		private var _numPlayer2:String;
		private var _numPlayer3:String;
		private var _numPlayer4:String;
		private var _numPlayer5:String;
		private var _numPlayer6:String;
		private var _numPlayer7:String;
		private var _numPlayer8:String;
		private var _numPlayer9:String;
		private var _numPlayer10:String;
		private var _numPlayer11:String;
		private var _nameSparePlayer1:String;
		private var _nameSparePlayer2:String;
		private var _nameSparePlayer3:String;
		private var _nameSparePlayer4:String;
		private var _nameSparePlayer5:String;
		private var _nameSparePlayer6:String;
		private var _nameSparePlayer7:String;
		private var _nameSparePlayer8:String;
		private var _nameSparePlayer9:String;
		private var _nameSparePlayer10:String;
		private var _nameSparePlayer11:String;
		private var _numSparePlayer1:String;
		private var _numSparePlayer2:String;
		private var _numSparePlayer3:String;
		private var _numSparePlayer4:String;
		private var _numSparePlayer5:String;
		private var _numSparePlayer6:String;
		private var _numSparePlayer7:String;
		private var _numSparePlayer8:String;
		private var _numSparePlayer9:String;
		private var _numSparePlayer10:String;
		private var _numSparePlayer11:String;
		// -----------------------------
		
		public function WindowStartingLineup() {
			// constructor code
		}
		
		// ----- Set methods. -----
		public function set nameTitle(value:String):void 
		{
			UpLine.TextUp.text = value;
			_nameTitle = value;
		}
		public function set nameSeason(value:String):void 
		{
			DownLine.NameSeason.text = value;
			_nameSeason = value;
		}
		public function set nameTrainer(value:String):void 
		{
			CenterLine.NameTrainer.text = value;
			_nameTrainer = value;
		}
		public function set logoTeam(value:String):void 
		{
			// Remove another logo if exist.
			if(_isLogo){
				UpLine.LogoTeam.removeChild(_loaderLogo);
				_isLogo = false;
			}
			
			// Create new logo.
			_logoTeamPath = value;
			//var url:URLRequest=new URLRequest(_logoTeamPath);
			
			_loaderLogo=new Loader();
			_loaderLogo.contentLoaderInfo.addEventListener(Event.COMPLETE, onCompliteLoadLogo);
			//var context:JPEGLoaderContext=new JPEGLoaderContext(1);
			//_loaderLogo.load(url,context);
			UpLine.LogoTeam.addChild(_loaderLogo);
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

   			 image.width = 90;
   			 image.height = 90;
		}
		public function set ampluaPlayer1(value:String):void 
		{
			CenterLine.AmpluaPlayer1.text = value;
			_ampluaPlayer1 = value;
		}
		public function set namePlayer1(value:String):void 
		{
			CenterLine.NamePlayer1.text = value;
			_namePlayer1 = value;
			
			// Move amplua text.
			CenterLine.AmpluaPlayer1.x = CenterLine.NamePlayer1.x + CenterLine.NamePlayer1.textWidth + 10;
		}
		public function set namePlayer2(value:String):void 
		{
			CenterLine.NamePlayer2.text = value;
			_namePlayer2 = value;
		}
		public function set namePlayer3(value:String):void 
		{
			CenterLine.NamePlayer3.text = value;
			_namePlayer3 = value;
		}
		public function set namePlayer4(value:String):void 
		{
			CenterLine.NamePlayer4.text = value;
			_namePlayer4 = value;
		}
		public function set namePlayer5(value:String):void 
		{
			CenterLine.NamePlayer5.text = value;
			_namePlayer5 = value;
		}
		public function set namePlayer6(value:String):void 
		{
			CenterLine.NamePlayer6.text = value;
			_namePlayer6 = value;
		}
		public function set namePlayer7(value:String):void 
		{
			CenterLine.NamePlayer7.text = value;
			_namePlayer7 = value;
		}
		public function set namePlayer8(value:String):void 
		{
			CenterLine.NamePlayer8.text = value;
			_namePlayer8 = value;
		}
		public function set namePlayer9(value:String):void 
		{
			CenterLine.NamePlayer9.text = value;
			_namePlayer9 = value;
		}
		public function set namePlayer10(value:String):void 
		{
			CenterLine.NamePlayer10.text = value;
			_namePlayer10 = value;
		}
		public function set namePlayer11(value:String):void 
		{
			CenterLine.NamePlayer11.text = value;
			_namePlayer1 = value;
		}
		public function set numPlayer1(value:String):void 
		{
			CenterLine.NumPlayer1.text = value;
			_numPlayer1 = value;
		}
		public function set numPlayer2(value:String):void 
		{
			CenterLine.NumPlayer2.text = value;
			_numPlayer2 = value;
		}
		public function set numPlayer3(value:String):void 
		{
			CenterLine.NumPlayer3.text = value;
			_numPlayer3 = value;
		}
		public function set numPlayer4(value:String):void 
		{
			CenterLine.NumPlayer4.text = value;
			_numPlayer4 = value;
		}
		public function set numPlayer5(value:String):void 
		{
			CenterLine.NumPlayer5.text = value;
			_numPlayer5 = value;
		}
		public function set numPlayer6(value:String):void 
		{
			CenterLine.NumPlayer6.text = value;
			_numPlayer6 = value;
		}
		public function set numPlayer7(value:String):void 
		{
			CenterLine.NumPlayer7.text = value;
			_numPlayer7 = value;
		}
		public function set numPlayer8(value:String):void 
		{
			CenterLine.NumPlayer8.text = value;
			_numPlayer8 = value;
		}
		public function set numPlayer9(value:String):void 
		{
			CenterLine.NumPlayer9.text = value;
			_numPlayer9 = value;
		}
		public function set numPlayer10(value:String):void 
		{
			CenterLine.NumPlayer10.text = value;
			_numPlayer10 = value;
		}
		public function set numPlayer11(value:String):void 
		{
			CenterLine.NumPlayer11.text = value;
			_numPlayer11 = value;
		}
		public function set nameSparePlayer1(value:String):void 
		{
			CenterLineSmall.NamePlayer1.text = value;
			_nameSparePlayer1 = value;
		}
		public function set nameSparePlayer2(value:String):void 
		{
			CenterLineSmall.NamePlayer2.text = value;
			_nameSparePlayer2 = value;
		}
		public function set nameSparePlayer3(value:String):void 
		{
			CenterLineSmall.NamePlayer3.text = value;
			_nameSparePlayer3 = value;
		}
		public function set nameSparePlayer4(value:String):void 
		{
			CenterLineSmall.NamePlayer4.text = value;
			_nameSparePlayer4 = value;
		}
		public function set nameSparePlayer5(value:String):void 
		{
			CenterLineSmall.NamePlayer5.text = value;
			_nameSparePlayer5 = value;
		}
		public function set nameSparePlayer6(value:String):void 
		{
			CenterLineSmall.NamePlayer6.text = value;
			_nameSparePlayer6 = value;
		}
		public function set nameSparePlayer7(value:String):void 
		{
			CenterLineSmall.NamePlayer7.text = value;
			_nameSparePlayer7 = value;
		}
		public function set nameSparePlayer8(value:String):void 
		{
			CenterLineSmall.NamePlayer8.text = value;
			_nameSparePlayer8 = value;
		}
		public function set nameSparePlayer9(value:String):void 
		{
			CenterLineSmall.NamePlayer9.text = value;
			_nameSparePlayer9 = value;
		}
		public function set nameSparePlayer10(value:String):void 
		{
			CenterLineSmall.NamePlayer10.text = value;
			_nameSparePlayer10 = value;
		}
		public function set nameSparePlayer11(value:String):void 
		{
			CenterLineSmall.NamePlayer11.text = value;
			_nameSparePlayer1 = value;
		}
		public function set numSparePlayer1(value:String):void 
		{
			CenterLineSmall.NumPlayer1.text = value;
			_numSparePlayer1 = value;
		}
		public function set numSparePlayer2(value:String):void 
		{
			CenterLineSmall.NumPlayer2.text = value;
			_numSparePlayer2 = value;
		}
		public function set numSparePlayer3(value:String):void 
		{
			CenterLineSmall.NumPlayer3.text = value;
			_numSparePlayer3 = value;
		}
		public function set numSparePlayer4(value:String):void 
		{
			CenterLineSmall.NumPlayer4.text = value;
			_numSparePlayer4 = value;
		}
		public function set numSparePlayer5(value:String):void 
		{
			CenterLineSmall.NumPlayer5.text = value;
			_numSparePlayer5 = value;
		}
		public function set numSparePlayer6(value:String):void 
		{
			CenterLineSmall.NumPlayer6.text = value;
			_numSparePlayer6 = value;
		}
		public function set numSparePlayer7(value:String):void 
		{
			CenterLineSmall.NumPlayer7.text = value;
			_numSparePlayer7 = value;
		}
		public function set numSparePlayer8(value:String):void 
		{
			CenterLineSmall.NumPlayer8.text = value;
			_numSparePlayer8 = value;
		}
		public function set numSparePlayer9(value:String):void 
		{
			CenterLineSmall.NumPlayer9.text = value;
			_numSparePlayer9 = value;
		}
		public function set numSparePlayer10(value:String):void 
		{
			CenterLineSmall.NumPlayer10.text = value;
			_numSparePlayer10 = value;
		}
		public function set numSparePlayer11(value:String):void 
		{
			CenterLineSmall.NumPlayer11.text = value;
			_numSparePlayer11 = value;
		}
		// ----- Set methods. -----
		
		public function PlayersShow():void
		{
			this.gotoAndPlay("in1");
		}
		
		public function PlayersHide():void
		{
			this.gotoAndPlay("out1");
		}
		
		public function SparePlayersShow():void
		{
			this.gotoAndPlay("in2");
		}
		public function SparePlayersHide():void
		{
			this.gotoAndPlay("out2");
		}
	}
	
}

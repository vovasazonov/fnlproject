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
		// -----------------------------
		
		public function WindowStartingLineup() {
			// constructor code
		}
		
		// ----- Set methods. -----
		public function set nameTitle(value:String):void 
		{
			UpLine.TextUp.text = value;
		}
		public function set nameSeason(value:String):void 
		{
			DownLine.NameSeason.text = value;
		}
		public function set nameTrainer(value:String):void 
		{
			CenterLine.NameTrainer.text = value;
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
		}
		public function set namePlayer1(value:String):void 
		{
			CenterLine.NamePlayer1.text = value;
			
			// Move text.
			CenterLine.AmpluaPlayer1.x = CenterLine.NamePlayer1.x + CenterLine.NamePlayer1.textWidth + 10;
		}
		public function set namePlayer2(value:String):void 
		{
			CenterLine.NamePlayer2.text = value;
			
		}
		public function set namePlayer3(value:String):void 
		{
			CenterLine.NamePlayer3.text = value;
			
		}
		public function set namePlayer4(value:String):void 
		{
			CenterLine.NamePlayer4.text = value;
			
		}
		public function set namePlayer5(value:String):void 
		{
			CenterLine.NamePlayer5.text = value;
			
		}
		public function set namePlayer6(value:String):void 
		{
			CenterLine.NamePlayer6.text = value;
			
		}
		public function set namePlayer7(value:String):void 
		{
			CenterLine.NamePlayer7.text = value;
			
		}
		public function set namePlayer8(value:String):void 
		{
			CenterLine.NamePlayer8.text = value;
			
		}
		public function set namePlayer9(value:String):void 
		{
			CenterLine.NamePlayer9.text = value;
			
		}
		public function set namePlayer10(value:String):void 
		{
			CenterLine.NamePlayer10.text = value;
			
		}
		public function set namePlayer11(value:String):void 
		{
			CenterLine.NamePlayer11.text = value;
			
		}
		public function set numPlayer1(value:String):void 
		{
			CenterLine.NumPlayer1.text = value;
			
		}
		public function set numPlayer2(value:String):void 
		{
			CenterLine.NumPlayer2.text = value;
			
		}
		public function set numPlayer3(value:String):void 
		{
			CenterLine.NumPlayer3.text = value;
			
		}
		public function set numPlayer4(value:String):void 
		{
			CenterLine.NumPlayer4.text = value;
			
		}
		public function set numPlayer5(value:String):void 
		{
			CenterLine.NumPlayer5.text = value;
			
		}
		public function set numPlayer6(value:String):void 
		{
			CenterLine.NumPlayer6.text = value;
			
		}
		public function set numPlayer7(value:String):void 
		{
			CenterLine.NumPlayer7.text = value;
			
		}
		public function set numPlayer8(value:String):void 
		{
			CenterLine.NumPlayer8.text = value;
			
		}
		public function set numPlayer9(value:String):void 
		{
			CenterLine.NumPlayer9.text = value;
			
		}
		public function set numPlayer10(value:String):void 
		{
			CenterLine.NumPlayer10.text = value;
			
		}
		public function set numPlayer11(value:String):void 
		{
			CenterLine.NumPlayer11.text = value;
			
		}
		public function set nameSparePlayer1(value:String):void 
		{
			CenterLineSmall.NamePlayer1.text = value;
			
		}
		public function set nameSparePlayer2(value:String):void 
		{
			CenterLineSmall.NamePlayer2.text = value;
			
		}
		public function set nameSparePlayer3(value:String):void 
		{
			CenterLineSmall.NamePlayer3.text = value;
			
		}
		public function set nameSparePlayer4(value:String):void 
		{
			CenterLineSmall.NamePlayer4.text = value;
			
		}
		public function set nameSparePlayer5(value:String):void 
		{
			CenterLineSmall.NamePlayer5.text = value;
			
		}
		public function set nameSparePlayer6(value:String):void 
		{
			CenterLineSmall.NamePlayer6.text = value;
			
		}
		public function set nameSparePlayer7(value:String):void 
		{
			CenterLineSmall.NamePlayer7.text = value;
			
		}
		public function set nameSparePlayer8(value:String):void 
		{
			CenterLineSmall.NamePlayer8.text = value;
			
		}
		public function set nameSparePlayer9(value:String):void 
		{
			CenterLineSmall.NamePlayer9.text = value;
			
		}
		public function set nameSparePlayer10(value:String):void 
		{
			CenterLineSmall.NamePlayer10.text = value;
			
		}
		public function set nameSparePlayer11(value:String):void 
		{
			CenterLineSmall.NamePlayer11.text = value;
			
		}
		public function set numSparePlayer1(value:String):void 
		{
			CenterLineSmall.NumPlayer1.text = value;
			
		}
		public function set numSparePlayer2(value:String):void 
		{
			CenterLineSmall.NumPlayer2.text = value;
			
		}
		public function set numSparePlayer3(value:String):void 
		{
			CenterLineSmall.NumPlayer3.text = value;
			
		}
		public function set numSparePlayer4(value:String):void 
		{
			CenterLineSmall.NumPlayer4.text = value;
			
		}
		public function set numSparePlayer5(value:String):void 
		{
			CenterLineSmall.NumPlayer5.text = value;
			
		}
		public function set numSparePlayer6(value:String):void 
		{
			CenterLineSmall.NumPlayer6.text = value;
			
		}
		public function set numSparePlayer7(value:String):void 
		{
			CenterLineSmall.NumPlayer7.text = value;
			
		}
		public function set numSparePlayer8(value:String):void 
		{
			CenterLineSmall.NumPlayer8.text = value;
			
		}
		public function set numSparePlayer9(value:String):void 
		{
			CenterLineSmall.NumPlayer9.text = value;
			
		}
		public function set numSparePlayer10(value:String):void 
		{
			CenterLineSmall.NumPlayer10.text = value;
			
		}
		public function set numSparePlayer11(value:String):void 
		{
			CenterLineSmall.NumPlayer11.text = value;

		}
		public function set titleMainJudje(value:String):void
		{
			CenterLineSmall.TitleMainJudje.text = value;
		}
		public function set titleHelperJudje(value:String):void
		{
			CenterLineSmall.TitleHelperJudje.text = value;
		}
		public function set titlePairJudje(value:String):void
		{
			CenterLineSmall.TitlePairJudje.text = value;
		}
		public function set titleInsepcotor(value:String):void
		{
			CenterLineSmall.TitleInsepcotor.text = value;
		}
		public function set titleDelegat(value:String):void
		{
			CenterLineSmall.TitleDelegat.text = value;
		}
		public function set nameMainJudje(value:String):void
		{
			CenterLineSmall.NameMainJudje.text = value;
			// Move text.
			CenterLineSmall.CityMainJudje.x = CenterLineSmall.NameMainJudje.x + CenterLineSmall.NameMainJudje.textWidth + 10;
		}
		public function set nameHelperJudje1(value:String):void
		{
			CenterLineSmall.NameHelperJudje1.text = value;
			// Move text.
			CenterLineSmall.CityHelperJudje1.x = CenterLineSmall.NameHelperJudje1.x + CenterLineSmall.NameHelperJudje1.textWidth + 10;
		}
		public function set nameHelperJudje2(value:String):void
		{
			CenterLineSmall.NameHelperJudje2.text = value;
			// Move text.
			CenterLineSmall.CityHelperJudje2.x = CenterLineSmall.NameHelperJudje2.x + CenterLineSmall.NameHelperJudje2.textWidth + 10;
		}
		public function set namePairJudje(value:String):void
		{
			CenterLineSmall.NamePairJudje.text = value;
			// Move text.
			CenterLineSmall.CityPairJudje.x = CenterLineSmall.NamePairJudje.x + CenterLineSmall.NamePairJudje.textWidth + 10;
		}
		public function set nameInsepcotor(value:String):void
		{
			CenterLineSmall.NameInsepcotor.text = value;
			// Move text.
			CenterLineSmall.CityInsepcotor.x = CenterLineSmall.NameInsepcotor.x + CenterLineSmall.NameInsepcotor.textWidth + 10;
		}
		public function set nameDelegat(value:String):void
		{
			CenterLineSmall.NameDelegat.text = value;
			// Move text.
			CenterLineSmall.CityDelegat.x = CenterLineSmall.NameDelegat.x + CenterLineSmall.NameDelegat.textWidth + 10;
		}
		public function set cityMainJudje(value:String):void
		{
			CenterLineSmall.CityMainJudje.text = value;
		}
		public function set cityHelperJudje1(value:String):void
		{
			CenterLineSmall.CityHelperJudje1.text = value;
		}
		public function set cityHelperJudje2(value:String):void
		{
			CenterLineSmall.CityHelperJudje2.text = value;
		}
		public function set cityPairJudje(value:String):void
		{
			CenterLineSmall.CityPairJudje.text = value;
		}
		public function set cityInsepcotor(value:String):void
		{
			CenterLineSmall.CityInsepcotor.text = value;
		}
		public function set cityDelegat(value:String):void
		{
			CenterLineSmall.CityDelegat.text = value;
		}
		// ----- Set methods. -----
		
		public function PlayersShow():void
		{
			DownLine.Logo.visible = true;
			this.gotoAndPlay("in1");
		}
		
		public function PlayersHide():void
		{
			this.gotoAndPlay("out1");
		}
		
		public function SparePlayersShow():void
		{
			DownLine.Logo.visible = true;
			this.gotoAndPlay("in2");
		}
		public function SparePlayersHide():void
		{
			this.gotoAndPlay("out2");
		}
		public function OfficialFacesShow():void
		{
			DownLine.Logo.visible = false;
			this.gotoAndPlay("in2");
		}
		public function OfficialFacesHide():void
		{
			this.gotoAndPlay("out2");
		}
	}
	
}

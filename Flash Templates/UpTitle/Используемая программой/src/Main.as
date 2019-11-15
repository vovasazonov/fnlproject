package src {
	
	import caurina.transitions.Tweener;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.media.Sound;
	import se.svt.caspar.template.CasparTemplate;
	import flash.utils.Timer;
    import flash.events.TimerEvent;
	
	public class Main extends CasparTemplate
	{
		// ------------------ Layers ------------------
		public var up_title:background;
		public var up_ltimer:AddTimeMin; //up_ltimer - is the whole object (name of object created by symbol in layer), AddTimeMin - script name of symbol.
		public var up_change:change;
		public var winStartLineup:WindowStartingLineup;
		public var replacement:replacementPlayers;
		// ------------------ Layers ------------------
		
		// ------------------ Booleans ------------------
		// True if the clock are showing. This clock contains only the color, name and score team and logo of FNL in clock. Without timer.
		private var _clockIsVisible:Boolean = false;		
		private var _gameTimeStarted:Boolean = false;
		private var _changeIsVisible:Boolean = false;		
		private var _playersSpareIsVisible:Boolean = false;
		private var _playersIsVisible:Boolean = false;
		private var _officialFacesIsVisible:Boolean = false;
		private var _isRightTeam:Boolean = false;
		private var _isPlayerClockVisible:Boolean = false;
		private var _isVisibleRedCard1Left:Boolean = false;
		private var _isVisibleRedCard2Left:Boolean = false;
		private var _isVisibleRedCard1Right:Boolean = false;
		private var _isVisibleRedCard2Right:Boolean = false;
		private var _welWinIsVisible:Boolean = false;
		// ------------------ Booleans ------------------
		
		public function Main() {
			// constructor code
			
		}
		
		override public function SetData(xmlData:XML):void 
		{
			super.SetData(xmlData);
			for each(var element:XML in xmlData.elements())
			{
				// ----- up_title -----
				if(element.@id == "team1Name")
				{
					 up_title.team1Name = element.data.@value;
				}
				if(element.@id == "team2Name")
				{
					 up_title.team2Name = element.data.@value;
				}
				if(element.@id == "team1Color")
				{
					up_title.team1Color = element.data.@value;
				}
				if(element.@id == "team2Color")
				{
					up_title.team2Color = element.data.@value;
				}
				if(element.@id == "team1Score")
				{
					 up_title.team1Score = element.data.@value;
				}
				if(element.@id == "team2Score")
				{
					 up_title.team2Score = element.data.@value;
				}
				// ----- up_title -----
				
				// ----- up_ltimer -----
				if(element.@id == "gameTime")
				{
					up_ltimer.gameTime = element.data.@value;
				}
				if(element.@id == "halfNum")
				{
					up_ltimer.halfNum = element.data.@value;
				}
				if(element.@id == "overtime") // it is additional minutes
				{
					up_ltimer.overTime = element.data.@value;
				}
				// ----- up_ltimer -----
	
				// ----- WindowStartingLineup -----
				if(element.@id == "dateTimeTitle") 
				{
					winStartLineup.dateTimeTitle = element.data.@value;
				}
				if(element.@id == "nameStadium") 
				{
					winStartLineup.nameStadium = element.data.@value;
				}
				if(element.@id == "leftNameTeamWelWin") 
				{
					winStartLineup.leftNameTeamWelWin = element.data.@value;
				}
				if(element.@id == "rightNameTeamWelWin") 
				{
					winStartLineup.rightNameTeamWelWin = element.data.@value;
				}
				if(element.@id == "logoTeamLeftWelWinPath") 
				{
					winStartLineup.logoTeamLeftWelWin = element.data.@value;
				}
				if(element.@id == "logoTeamRightWelWinPath") 
				{
					winStartLineup.logoTeamRightWelWin = element.data.@value;
				}
				
				
				if(element.@id == "titleName") 
				{
					winStartLineup.nameTitle = element.data.@value;
				}
				if(element.@id == "seasonName") 
				{
					winStartLineup.nameSeason = element.data.@value;
				}
				if(element.@id == "trainerName") 
				{
					winStartLineup.nameTrainer = element.data.@value;
				}
				if(element.@id == "teamLogoPath") 
				{
					winStartLineup.logoTeam = element.data.@value;
				}
				if(element.@id == "ampluaPlayer1") 
				{
					winStartLineup.ampluaPlayer1 = element.data.@value;
				}
				if(element.@id == "namePlayer1") 
				{
					winStartLineup.namePlayer1 = element.data.@value;
				}
				if(element.@id == "namePlayer2") 
				{
					winStartLineup.namePlayer2 = element.data.@value;
				}
				if(element.@id == "namePlayer3") 
				{
					winStartLineup.namePlayer3 = element.data.@value;
				}
				if(element.@id == "namePlayer4") 
				{
					winStartLineup.namePlayer4 = element.data.@value;
				}
				if(element.@id == "namePlayer5") 
				{
					winStartLineup.namePlayer5 = element.data.@value;
				}
				if(element.@id == "namePlayer6")
				{
					winStartLineup.namePlayer6 = element.data.@value;
				}
				if(element.@id == "namePlayer7") 
				{
					winStartLineup.namePlayer7 = element.data.@value;
				}
				if(element.@id == "namePlayer8")
				{
					winStartLineup.namePlayer8 = element.data.@value;
				}
				if(element.@id == "namePlayer9") 
				{
					winStartLineup.namePlayer9 = element.data.@value;
				}
				if(element.@id == "namePlayer10")
				{
					winStartLineup.namePlayer10 = element.data.@value;
				}
				if(element.@id == "namePlayer11")
				{
					winStartLineup.namePlayer11 = element.data.@value;
				}
				if(element.@id == "numPlayer1")
				{
					winStartLineup.numPlayer1 = element.data.@value;
				}
				if(element.@id == "numPlayer2")
				{
					winStartLineup.numPlayer2 = element.data.@value;
				}
				if(element.@id == "numPlayer3")
				{
					winStartLineup.numPlayer3 = element.data.@value;
				}
				if(element.@id == "numPlayer4")
				{
					winStartLineup.numPlayer4 = element.data.@value;
				}
				if(element.@id == "numPlayer5") 
				{
					winStartLineup.numPlayer5 = element.data.@value;
				}
				if(element.@id == "numPlayer6")
				{
					winStartLineup.numPlayer6 = element.data.@value;
				}
				if(element.@id == "numPlayer7") 
				{
					winStartLineup.numPlayer7 = element.data.@value;
				}
				if(element.@id == "numPlayer8") 
				{
					winStartLineup.numPlayer8 = element.data.@value;
				}
				if(element.@id == "numPlayer9")
				{
					winStartLineup.numPlayer9 = element.data.@value;
				}
				if(element.@id == "numPlayer10") 
				{
					winStartLineup.numPlayer10 = element.data.@value;
				}
				if(element.@id == "numPlayer11")
				{
					winStartLineup.numPlayer11 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer1") 
				{
					winStartLineup.nameSparePlayer1 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer2")
				{
					winStartLineup.nameSparePlayer2 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer3")
				{
					winStartLineup.nameSparePlayer3 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer4")
				{
					winStartLineup.nameSparePlayer4 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer5")
				{
					winStartLineup.nameSparePlayer5 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer6") 
				{
					winStartLineup.nameSparePlayer6 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer7") 
				{
					winStartLineup.nameSparePlayer7 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer8")
				{
					winStartLineup.nameSparePlayer8 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer9") 
				{
					winStartLineup.nameSparePlayer9 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer10")
				{
					winStartLineup.nameSparePlayer10 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer11")
				{
					winStartLineup.nameSparePlayer11 = element.data.@value;
				}
				if(element.@id == "nameSparePlayer12")
				{
					winStartLineup.nameSparePlayer12 = element.data.@value;
				}
				if(element.@id == "numSparePlayer1")
				{
					winStartLineup.numSparePlayer1 = element.data.@value;
				}
				if(element.@id == "numSparePlayer2") 
				{
					winStartLineup.numSparePlayer2 = element.data.@value;
				}
				if(element.@id == "numSparePlayer3")
				{
					winStartLineup.numSparePlayer3 = element.data.@value;
				}
				if(element.@id == "numSparePlayer4") 
				{
					winStartLineup.numSparePlayer4 = element.data.@value;
				}
				if(element.@id == "numSparePlayer5") 
				{
					winStartLineup.numSparePlayer5 = element.data.@value;
				}
				if(element.@id == "numSparePlayer6")
				{
					winStartLineup.numSparePlayer6 = element.data.@value;
				}
				if(element.@id == "numSparePlayer7") 
				{
					winStartLineup.numSparePlayer7 = element.data.@value;
				}
				if(element.@id == "numSparePlayer8") 
				{
					winStartLineup.numSparePlayer8 = element.data.@value;
				}
				if(element.@id == "numSparePlayer9") 
				{
					winStartLineup.numSparePlayer9 = element.data.@value;
				}
				if(element.@id == "numSparePlayer10") 
				{
					winStartLineup.numSparePlayer10 = element.data.@value;
				}
				if(element.@id == "numSparePlayer11")
				{
					winStartLineup.numSparePlayer11 = element.data.@value;
				}
				if(element.@id == "numSparePlayer12")
				{
					winStartLineup.numSparePlayer12 = element.data.@value;
				}
				if(element.@id == "titleMainJudje")
				{
					winStartLineup.titleMainJudje = element.data.@value;
				}
				if(element.@id == "titleHelperJudje")
				{
					winStartLineup.titleHelperJudje = element.data.@value;
				}
				if(element.@id == "titlePairJudje")
				{
					winStartLineup.titlePairJudje = element.data.@value;
				}
				if(element.@id == "titleInsepcotor")
				{
					winStartLineup.titleInsepcotor = element.data.@value;
				}
				if(element.@id == "titleDelegat")
				{
					winStartLineup.titleDelegat = element.data.@value;
				}
				
				if(element.@id == "nameMainJudje")
				{
					winStartLineup.nameMainJudje = element.data.@value;
				}
				if(element.@id == "nameHelperJudje1")
				{
					winStartLineup.nameHelperJudje1 = element.data.@value;
				}
				if(element.@id == "nameHelperJudje2")
				{
					winStartLineup.nameHelperJudje2 = element.data.@value;
				}
				if(element.@id == "namePairJudje")
				{
					winStartLineup.namePairJudje = element.data.@value;
				}
				if(element.@id == "nameInsepcotor")
				{
					winStartLineup.nameInsepcotor = element.data.@value;
				}
				if(element.@id == "nameDelegat")
				{
					winStartLineup.nameDelegat = element.data.@value;
				}
				
				if(element.@id == "cityMainJudje")
				{
					winStartLineup.cityMainJudje = element.data.@value;
				}
				if(element.@id == "cityHelperJudje1")
				{
					winStartLineup.cityHelperJudje1 = element.data.@value;
				}
				if(element.@id == "cityHelperJudje2")
				{
					winStartLineup.cityHelperJudje2 = element.data.@value;
				}
				if(element.@id == "cityPairJudje")
				{
					winStartLineup.cityPairJudje = element.data.@value;
				}
				if(element.@id == "cityInsepcotor")
				{
					winStartLineup.cityInsepcotor = element.data.@value;
				}
				if(element.@id == "cityDelegat")
				{
					winStartLineup.cityDelegat = element.data.@value;
				}
				
				// ----- WindowStartingLineup -----
				// ----- replacementPlayers -----
				if(element.@id == "nameRedLine")
				{
					replacement.nameRedLine = element.data.@value;
				}
				if(element.@id == "numberRedLine")
				{
					replacement.numberRedLine = element.data.@value;
				}
				if(element.@id == "nameGreenLine")
				{
					replacement.nameGreenLine = element.data.@value;
				}
				if(element.@id == "numberGreenLine")
				{
					replacement.numberGreenLine = element.data.@value;
				}
				if(element.@id == "replacementTeamLogoPath") 
				{
					replacement.logoTeam = element.data.@value;
				}
				if(element.@id == "eventNameLine") 
				{
					replacement.eventNameLine = element.data.@value;
				}
				if(element.@id == "eventValueLine") 
				{
					replacement.eventValueLine = element.data.@value;
				}
				if(element.@id == "secondEventNameLine") 
				{
					replacement.secondEventNameLine = element.data.@value;
				}
				if(element.@id == "secondsEventValueLine") 
				{
					replacement.secondsEventValueLine = element.data.@value;
				}
				if(element.@id == "namePlayerBackround") 
				{
					up_title.namePlayerBackround = element.data.@value;
				}
				if(element.@id == "isRightTeam") 
				{
					if(element.data.@value == "0")
					{
						_isRightTeam = false;
					}
					else
					{
						_isRightTeam = true;
					}
				}
				// ----- replacementPlayers -----

			}
		}
		
		public function RedCard1LeftOnClockShowHide():void
		{
			// Hide Card
			if (_isVisibleRedCard1Left)
			{
				up_title.HideLeftRedCard1();
				_isVisibleRedCard1Left = false;
			}
			// Show
			else
			{
				up_title.ShowLeftRedCard1();
				_isVisibleRedCard1Left = true;
			}
		}
		public function RedCard2LeftOnClockShowHide():void
		{
			
		}
		public function RedCard1RightOnClockShowHide():void
		{
			// Hide Card
			if (_isVisibleRedCard1Right)
			{
				up_title.HideRightRedCard1();
				_isVisibleRedCard1Right = false;
			}
			// Show
			else
			{
				up_title.ShowRightRedCard1();
				_isVisibleRedCard1Right = true;
			}
		}
		public function RedCard2RightOnClockShowHide():void
		{
			
		}
		
		// Show or hide the main title.
		public function clockShowHide():void
		{
			// Hide clock
			if (_clockIsVisible)
			{
				up_title.clockHide();
				_clockIsVisible = false;
				
				// Hide all timer
				up_ltimer.hideAllTimers();
			}
			// Show clock.
			else
			{
				up_title.clockShow();
				_clockIsVisible = true;
			}
			
			// Inform timers about visible of clock.
			up_ltimer._clockIsShown = _clockIsVisible;
		}
		
		// Show or hide addtional minutes.
		public function ltimerShowHide():void
		{
			if (!up_ltimer._clockAddIsHidden)
			{
				up_ltimer.clockHideAddMinutes();
				up_ltimer._clockAddIsHidden = true;

			}
			else
			{
				if(_clockIsVisible)
				{
					up_ltimer.clockShowAddMinutes();
					//up_ltimer._clockAddIsHidden = false;
				}
			}
		}
		
		
		public function changeShowHide():void
		{
			if (_changeIsVisible)
			{
				up_change.changeHide();
				_changeIsVisible = false;

			}
			else
			{
				up_change.changeShow();
				_changeIsVisible = true;
			}
		}
		
		
		// Show or hide the classic timer.
		public function clockShowHideTimer():void
		{
			if (!up_ltimer._clockTimerIsHidden)
			{
				up_ltimer.clockHideTimer();
				up_ltimer._clockTimerIsHidden = true;

			}
			else
			{
				// Show clock
				if(_clockIsVisible)
				{
					up_ltimer.clockShowTimer();
					up_ltimer._clockTimerIsHidden = false;
				}
			}
		}
		
		// Strat the timer or stop it.
		public function gameTimeStartStop():void
		{
			if (_gameTimeStarted)
			{
				up_ltimer.gameTimeStop();
				_gameTimeStarted = false;
			}
			else
			{
				up_ltimer.gameTimeStart();
				_gameTimeStarted = true;
			}
		}
		// ----- WindowStartingLineup -----
		public function PlayersShowHide():void
		{
			if (_playersIsVisible)
			{
				winStartLineup.PlayersHide();
				//winStartLineup.PlayersHide();
				_playersIsVisible = false;

			}
			else
			{
				winStartLineup.PlayersShow();
				_playersIsVisible = true;
			}
		}
		
		public function PlayersSpareShowHide():void
		{
			if (_playersSpareIsVisible)
			{
				winStartLineup.SparePlayersHide();
				_playersSpareIsVisible = false;

			}
			else
			{
				winStartLineup.SparePlayersShow();
				_playersSpareIsVisible = true;
			}
		}
		public function OfficialFacesShowHide():void
		{
			if (_officialFacesIsVisible)
			{
				winStartLineup.OfficialFacesHide();
				_officialFacesIsVisible = false;

			}
			else
			{
				winStartLineup.OfficialFacesShow();
				_officialFacesIsVisible = true;
			}
		}
		public function WelWinShowHide():void
		{
			if (_welWinIsVisible)
			{
				winStartLineup.WelWinHide();
				_welWinIsVisible = false;

			}
			else
			{
				winStartLineup.WelWinShow();
				_welWinIsVisible = true;
			}
		}
		
		// ----- WindowStartingLineup -----
		// ----- replacementPlayers -----
		public function ReplacementShowHide():void
		{
			replacement.ReplacementShow();
		}
		public function RepYellowCardShowHide():void
		{
			if(!_clockIsVisible)
			{
				return;
			}
			PlayerClockShowHide();
			
			var timer:Timer = new Timer(3000,1);
			timer.addEventListener(TimerEvent.TIMER, timerHandlerYellowCardShow); // will call YellowCardShow()
			timer.start();
			
		
		}
		public function RepRedCardShowHide():void
		{
			if(!_clockIsVisible)
			{
				return;
			}
			PlayerClockShowHide();
			
			var timer:Timer = new Timer(3000,1);
			timer.addEventListener(TimerEvent.TIMER, timerHandlerRedCardShow); // will call RedCardShow()
			timer.start();
			
		}
		public function RepGoalShowHide():void
		{
			if(!_clockIsVisible)
			{
				return;
			}
			PlayerClockShowHide();
			
			var timer:Timer = new Timer(3000,1);
			timer.addEventListener(TimerEvent.TIMER, timerHandlerGoalShow); // will call GoalShow()
			timer.start();
		
		}
		private function timerHandlerRedCardShow(e:TimerEvent):void{
            replacement.RedCardShow(this);
        }
		private function timerHandlerYellowCardShow(e:TimerEvent):void{
            replacement.YellowCardShow(this);
        }
		private function timerHandlerGoalShow(e:TimerEvent):void{
            replacement.GoalShow(this);
        }

		
		public function PlayerClockShowHide():void
		{
			if(_isRightTeam)
			{
				if(_isPlayerClockVisible)
				{
					up_title.playerRightTeamHide();
					_isPlayerClockVisible = false;
				}
				else
				{
					up_title.playerRightTeamShow();
					_isPlayerClockVisible = true;
				}
			}
			else
			{
				if(_isPlayerClockVisible)
				{
					up_title.playerLeftTeamHide();
					_isPlayerClockVisible = false;
				}
				else
				{
					up_title.playerLeftTeamShow();
					_isPlayerClockVisible = true;
				}
			}
		}
		// ----- replacementPlayers -----
	}
	
}

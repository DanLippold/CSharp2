using CruiseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseControl
{
    public class Commander
    {
        public BoardStatus _currentBoard;

        public Commander()
        {
            _currentBoard = new BoardStatus();
        }

        public List<Command> GiveCommands()
        {
            var cmds = new List<Command>();

            foreach (var vessel in _currentBoard.MyVesselStatuses)
            {
                cmds.Add(new Command { vesselid = vessel.Id, action = "move:north" });
            }

            return cmds;
        }

        public void GetBoardStatus(BoardStatus board)
        {
            _currentBoard = board;
        }
    }
}